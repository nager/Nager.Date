using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nager.Date.Website.Context.Entities;
using Nager.Date.Website.Context.Utilities;
using Nager.Date.Website.Middleware;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Nager.Date.Website.Context
{
    public class ApiKeyManagement : IApiKeyLookup
    {
        private static readonly object _sqlLock = new();
        private readonly IServiceScopeFactory _scopeFactory;
        public ApiKeyManagement(IServiceScopeFactory scopeFactory)
        {
            this._scopeFactory = scopeFactory;
        }
        public async Task<bool> IsValidKey(string apiKey, IPAddress ipAddress)
        {
            apiKey = apiKey.ToUpperInvariant();
            var keyBytes = Base32.FromBase32(apiKey[0..^1]);
            if (keyBytes.Length != 8 || Checksum(keyBytes) != apiKey[^1]) { return false; }
            using var scope = this._scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<UserContext>();
            var usrId = await (from u in context.Users
                               where u.APIKey == keyBytes
                               select (int?)u.Id).SingleOrDefaultAsync();
            if (usrId.HasValue)
            {
                var ipBytes = GetIPBytes(ipAddress);
                if (context.Database.IsSqlServer())
                {
                    // not awaiting on purpose
                    _ = context.Database.ExecuteSqlRawAsync("EXEC AddHitByUserId {0}, {1}", usrId.Value, ipBytes);
                }
                else
                {
                    AddHitByUserId(context, usrId.Value, ipBytes);
                }
                return true;
            }
            return false;
        }

        public async Task AddHit(IPrincipal principal, IPAddress ipAddress)
        {
            var ipBytes = GetIPBytes(ipAddress);
            using var scope = this._scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<UserContext>();
            if (principal is ClaimsPrincipal cp)
            {
                var id = cp.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                if (id != null)
                {
                    await AddHitByUserId(context, int.Parse(id.Value), ipBytes);
                    return;
                }
            }
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<RegisteredConsumer>>();
            var usr = await userManager.FindByNameAsync(principal.Identity.Name);
            await AddHitByUserId(context, usr.Id, ipBytes);
        }

        public static byte[] GenerateNewApiKey(byte bytes = 8)
        {
            var rngCsp = new RNGCryptoServiceProvider();
            var byteArray = new byte[bytes];
            rngCsp.GetBytes(byteArray);
            return byteArray;
        }

        public static string KeyToString(byte[] bytes)
        {
            return (Base32.ToBase32(bytes) + Checksum(bytes)).ToLowerInvariant();
        }

        public static char Checksum(byte[] bytes)
        {
            var val = BitConverter.ToUInt64(bytes);
            var i = (int)(val % 37UL);
            const string Base37Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789$";
            return Base37Chars[i];
        }

        private static async Task AddHitByUserId(UserContext context, int userId, byte[] ipBytes, bool useSqlIfAvailable = true)
        {
            if (useSqlIfAvailable && context.Database.IsSqlServer())
            {
                await context.Database.ExecuteSqlRawAsync("EXEC [AddHitByUserId] {0}, {1}", userId, ipBytes);
            }
            else
            {
                var today = DateTime.UtcNow.Date;
                // we will have to lock sql calls from our app manually
                lock (_sqlLock)
                {
                    var todaysHits = context.ConsumerHits.SingleOrDefault(h => h.HitDate == today &&
                        h.UserId == userId &&
                        h.IPAddress == ipBytes);
                    if (todaysHits == null)
                    {
                        context.ConsumerHits.Add(new Entities.ConsumerHit
                        {
                            HitDate = today,
                            IPAddress = ipBytes,
                            UserId = userId,
                            HitCount = 1
                        });
                    }
                    else
                    {
                        todaysHits.HitCount += 1;
                    }
                    context.SaveChanges();
                }
            }
        }

        private static byte[] GetIPBytes(IPAddress ip)
        {
            var ipBytes = ip.GetAddressBytes() ?? new byte[16];
            if (ipBytes.Length == 4)
            {
                var ip6 = new byte[16];
                Buffer.BlockCopy(ipBytes, 0, ip6, 12, 4);
                return ip6;
            }
            return ipBytes;
        }
    }
}

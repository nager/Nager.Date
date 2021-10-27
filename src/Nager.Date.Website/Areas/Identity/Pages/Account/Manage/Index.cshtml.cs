using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nager.Date.Website.Context;
using Nager.Date.Website.Context.Entities;
using Nager.Date.Website.Helper;
using Nager.Date.Website.Models.User;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nager.Date.Website.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    public partial class IndexModel : PageModel // : Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Manage.Internal.IndexModel
    {
        private readonly UserManager<RegisteredConsumer> _userManager;
        private readonly UserContext _userContext;

        public UserDetailStatsDto UserDetails { get; set; }

        public string ExampleUrl { get; set; }
        public string ExampleLink { get; set; }

        public IndexModel(
            UserManager<RegisteredConsumer> userManager, UserContext userContext) : base()
        {
            _userManager = userManager;
            _userContext = userContext;
        }

        private async Task LoadAsync(RegisteredConsumer user)
        {
            var prior365 = DateTime.UtcNow.Date.AddDays(-365.0);
            var hits = await _userContext.ConsumerHits
                .Where(h => h.UserId == user.Id && h.HitDate >= prior365)
                .ToListAsync();
            user.ConsumerHits = hits;
            UserDetails = CalculatePerUserUsageStats.CreateDetailStats(user, Request);
            var baseUrlString = $"{Request.Scheme}://{Request.Host}";
            baseUrlString += "/api/v3/PublicHolidays/{0}/{1}?api_key=" + UserDetails.APIKey;
            ExampleUrl = string.Format(baseUrlString, "{Year}", "{CountryCode}");
            var countryCode = AcceptLanguageFormatter.GetOrderedLanguages(Request)
                .Select(l => {
                    var s = l.Split('-');
                    return s.Length >= 2 ? s[1].ToUpperInvariant() : null;
                })
                .FirstOrDefault(l => l != null && Enum.IsDefined(typeof(CountryCode), l)) ?? "US";
            ExampleLink = string.Format(baseUrlString,
                DateTime.Today.Year,
                countryCode);
        }

        public async Task<IActionResult> OnGetAsync([FromRoute] int? userId = null)
        {
            var vua = await this.ValidateUserAccess(userId);
            if (vua.ErrorResult != null)
            {
                return vua.ErrorResult;
            }
            await this.LoadAsync(vua.User);
            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync([FromRoute] int? userId = null)
        {
            var vua = await this.ValidateUserAccess(userId);
            if (vua.ErrorResult != null)
            {
                return vua.ErrorResult;
            }
            vua.User.APIKey = ApiKeyManagement.GenerateNewApiKey();
            await _userManager.UpdateAsync(vua.User);
            await this.LoadAsync(vua.User);
            return this.Page();
        }

        protected class ValidateUserAccessResult
        {
            public RegisteredConsumer User { get; set; }
            public IActionResult ErrorResult { get; set; }
        }
        protected async Task<ValidateUserAccessResult> ValidateUserAccess(int? userId)
        {
            var returnVar = new ValidateUserAccessResult();
            var currentUser = await _userManager.GetUserAsync(this.User);
            if (currentUser == null)
            {
                returnVar.ErrorResult = this.NotFound($"Unable to load current user with ID '{_userManager.GetUserId(this.User)}'.");
                return returnVar;
            }
            if (userId.HasValue)
            {
                if (userId.Value == currentUser.Id) {
                    returnVar.User = currentUser;
                }
                else if (await _userManager.IsInRoleAsync(currentUser, "Admin"))
                {
                    returnVar.User = await _userManager.FindByIdAsync(userId.Value.ToString());
                    if (returnVar.User == null)
                    {
                        returnVar.ErrorResult = this.NotFound($"Unable to load specified user with ID '{userId.Value}'.");
                    }
                }
                else
                {
                    returnVar.ErrorResult = this.Forbid();
                }
            }
            else
            {
                returnVar.User = currentUser;
            }
            return returnVar;
        }
    }
}

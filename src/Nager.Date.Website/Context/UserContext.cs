using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nager.Date.Website.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Nager.Date.Website.Context
{
    public class UserContext : IdentityDbContext<RegisteredConsumer, IdentityRole<int>, int>
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<ConsumerHit> ConsumerHits { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var rc = builder.Entity<RegisteredConsumer>();
            rc.HasCheckConstraint("CK_RegisteredConsumer_APIKey_NZ", "[APIKey] <> 0")
                .HasIndex(u => u.APIKey)
                .IsUnique();
            rc.Property(r => r.APIKey)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength();
            rc.HasMany(r => r.ConsumerHits)
                .WithOne(h => h.User)
                .HasForeignKey(h => h.UserId);
            rc.Property(r => r.UserSince)
                .HasColumnType("datetime2(0)");

            var ch = builder.Entity<ConsumerHit>();
            ch.ToTable("ConsumerHits");
            ch.HasKey(h => h.Id);
            ch.Property(h => h.HitDate)
                .HasColumnType("date");
            ch.Property(h => h.IPAddress)
                .HasMaxLength(16)
                .IsFixedLength()
                .IsRequired();
            ch.HasIndex(h => new { h.IPAddress, h.HitDate, h.UserId })
                .IsUnique();

            // seed data - used in first migration only

            rc.HasData(new RegisteredConsumer
            {
                Id=1,
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                UserName = "admin@example.com",
                NormalizedUserName = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                APIKey = BitConverter.GetBytes(0x4FE6FC5792B6A0A7),
                UserSince = DateTime.UtcNow,
                // password = "ChangeMeASAP"
                PasswordHash = "AQAAAAEAACcQAAAAEO48j+mNJ575k9WzfGUyRmkJMYJkuqaUbuAzSIGhnuz6l+sN4JzWGtS5T+PXFjFV7w==",
                SecurityStamp = "DDTKZ6V6T2RCA6GP6EBTCAXWKSRJ6I7O",
                ConcurrencyStamp = "2da10deb-cc88-4791-af1f-a9b38304b60a"
            });

            var ir = builder.Entity<IdentityRole<int>>();
            ir.HasData(new IdentityRole<int>
            {
                Id=1,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });
            ir.HasData(new IdentityRole<int>
            {
                Id=2,
                Name = "Sponsor",
                NormalizedName = "SPONSOR"
            });

            builder.Entity<IdentityUserRole<int>>()
                .HasData(new IdentityUserRole<int>
                {
                    RoleId = 1,
                    UserId = 1
                });
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            this.UpdatePropsIfRqd();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.UpdatePropsIfRqd();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        private void UpdatePropsIfRqd()
        {
            foreach (var e in this.ChangeTracker.Entries())
            {
                if (e.Entity is RegisteredConsumer u && e.State == EntityState.Added)
                {
                    UpdateNewUser(u);
                }
            }
        }

        private static void UpdateNewUser(RegisteredConsumer newUser)
        {
            newUser.UserSince = DateTime.UtcNow;
            if (newUser.APIKey == null)
            {
                newUser.APIKey = ApiKeyManagement.GenerateNewApiKey();
            }
        }
    }
}

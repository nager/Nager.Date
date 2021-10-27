using Microsoft.AspNetCore.Http;
using Nager.Date.Website.Context;
using Nager.Date.Website.Context.Entities;
using Nager.Date.Website.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Nager.Date.Website.Helper
{
    public static class CalculatePerUserUsageStats
    {
        public static IEnumerable<HitInfoDto> CreateHitSummary(IEnumerable<ConsumerHit> hits)
        {
            var returnVar = new[] {
                new HitInfoDto { DaysPrior = 0.0, DescribeDaysPrior = "Today" },
                new HitInfoDto { DaysPrior = -1.0, DescribeDaysPrior = "Yesterday" },
                new HitInfoDto { DaysPrior = -7.0, DescribeDaysPrior = "Last Week" },
                new HitInfoDto { DaysPrior = -30.0, DescribeDaysPrior = "Last 30 Days" },
                new HitInfoDto { DaysPrior = -365.0, DescribeDaysPrior = "Last Year" },
            };
            var today = DateTime.UtcNow.Date;
            var ipComparer = new IPComparer();
            foreach (var hi in returnVar)
            {
                var cutoff = today.AddDays(hi.DaysPrior);
                var hitsInRange = hits.Where(h => h.HitDate >= cutoff).ToList();
                hi.HitCount = hitsInRange.Sum(h => h.HitCount);
                hi.DistinctIPCount = hitsInRange.Select(h => h.IPAddress).Distinct(ipComparer).Count();
            }
            return returnVar;
        }

        public static ICollection<TopIPDto> GetTopIPDtos(IEnumerable<ConsumerHit> hits, int take = 5)
        {
            return hits.GroupBy(h => h.IPAddress, new IPComparer())
                       .Select(h => new TopIPDto
                       {
                           IPAddress = new IPAddress(h.Key).ToString(),
                           HitCount = h.Sum(c => c.HitCount)
                       })
                       .OrderByDescending(tip => tip.HitCount)
                       .Take(take)
                       .ToList();
        }

        public static ICollection<TopDateDto> GetTopDateDtos(IEnumerable<ConsumerHit> hits, IFormatProvider dateFormatter, int take = 5)
        {
            return hits.GroupBy(h => h.HitDate)
                       .Select(h => new TopDateDto
                       {
                           Date = DateTime.SpecifyKind(h.Key, DateTimeKind.Utc).ToString("d", dateFormatter),
                           HitCount = h.Sum(c => c.HitCount)
                       })
                       .OrderByDescending(td => td.HitCount)
                       .Take(take)
                       .ToList();
        }

        public static UserDetailStatsDto CreateDetailStats(RegisteredConsumer user, IFormatProvider dateFormatter)
        {
            return new UserDetailStatsDto
            {
                APIKey = ApiKeyManagement.KeyToString(user.APIKey),
                UserSince = DateTime.SpecifyKind(user.UserSince, DateTimeKind.Utc).ToString("d", dateFormatter),
                Hits = CreateHitSummary(user.ConsumerHits),
                PopularIPs = GetTopIPDtos(user.ConsumerHits),
                PopularDates = GetTopDateDtos(user.ConsumerHits, dateFormatter)
            };
        }
        public static UserDetailStatsDto CreateDetailStats(RegisteredConsumer user, HttpRequest request)
        {
            return CreateDetailStats(user, AcceptLanguageFormatter.GetDateFormatter(request));
        }
    }
}

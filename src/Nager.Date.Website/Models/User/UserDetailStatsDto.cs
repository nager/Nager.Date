using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Nager.Date.Website.Models.User
{
    public class UserDetailStatsDto
    {
        public string UserSince { get; set; }
        public string APIKey { get; set; }
        public IEnumerable<HitInfoDto> Hits { get; set; }
        public ICollection<TopIPDto> PopularIPs { get; set; }
        public ICollection<TopDateDto> PopularDates { get; set; }
    }

    public class HitInfoDto
    {
        public double DaysPrior { get; set; }
        public string DescribeDaysPrior { get; set; }
        public int HitCount { get; set; }
        public int DistinctIPCount { get; set; }
    }

    public class TopIPDto
    {
        public string IPAddress { get; set; }
        public int HitCount { get; set; }
    }

    public class TopDateDto
    {
        public string Date { get; set; }
        public int HitCount { get; set; }
    }
}

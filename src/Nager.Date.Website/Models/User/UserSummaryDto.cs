using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nager.Date.Website.Models.User
{
    public class UserSummaryDto
    {
        public string Email { get; set; }
        public int Id { get; set; }
        public DateTime UserSince { get; set; }
        public int Hits { get; set; }
    }
}

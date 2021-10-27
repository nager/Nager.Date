using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nager.Date.Website.Context;
using Nager.Date.Website.Models.User;

namespace Nager.Date.Website.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles="Admin")]
    public class AllUsersModel : PageModel
    {
        private readonly UserContext _userContext;

        public IEnumerable<UserSummaryDto> UsersDetails { get; set; }
        public int DaysPrior { get; set; }
        public AllUsersModel(
            UserContext userContext) : base()
        {
            _userContext = userContext;
        }

        private async Task LoadAsync(int daysPrior)
        {
            if (daysPrior < 0.0) { daysPrior = -daysPrior;  }
            var priorDate = DateTime.UtcNow.Date.AddDays(-daysPrior);
            UsersDetails = await (from u in _userContext.Users
                                  select new UserSummaryDto
                                  {
                                      Id = u.Id,
                                      Email = u.Email,
                                      UserSince = u.UserSince,
                                      Hits = u.ConsumerHits
                                                .Where(ch => ch.HitDate >= priorDate)
                                                .Sum(ch => ch.HitCount)
                                  }).OrderByDescending(us => us.Hits)
                                    .ToListAsync();
            DaysPrior = daysPrior;
        }
        public async Task<ActionResult> OnGet([FromQuery]int? daysPrior = 7)
        {
            await LoadAsync(daysPrior.Value);
            return this.Page();
        }
    }
}

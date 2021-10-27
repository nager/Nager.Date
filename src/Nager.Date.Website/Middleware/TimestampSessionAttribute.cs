using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nager.Date.Website.Middleware
{
    public class TimestampSessionAttribute: ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await context.HttpContext.Session.LoadAsync();
            context.HttpContext.Session.SetDateTime(AllowApiAccessMiddleware.MvcPageRequestedKey, DateTime.UtcNow);
            await next();
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nager.Date.Website.Middleware
{
    public class AllowApiAccessOptions
    {
        public double APIKeyBypassSeconds { get; set; }
    }
}

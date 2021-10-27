using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nager.Date.Website.Context.Entities
{
    public class RegisteredConsumer : IdentityUser<int>
    {
        public byte[] APIKey { get; set; }
        public DateTime UserSince { get; set; }
        public virtual ICollection<ConsumerHit> ConsumerHits { get; set; }
    }
}

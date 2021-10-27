using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nager.Date.Website.Context.Entities
{
    public class ConsumerHit
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime HitDate { get; set; }
        public byte[] IPAddress { get; set; }
        public int HitCount { get; set; }

        public virtual RegisteredConsumer User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nager.Date
{
    public class PublicHoliday
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CountryCode { get; set; }
        public bool Fixed { get; set; }

        public PublicHoliday(int day, int month, int year, string name, string description, string countryCode)
        {
            this.Date = new DateTime(year, month, day);
            this.Name = name;
            this.Description = description;
            this.CountryCode = countryCode;
            this.Fixed = true;
        }

        public PublicHoliday(DateTime date, string name, string description, string countryCode)
        {
            this.Date = date;
            this.Name = name;
            this.Description = description;
            this.CountryCode = countryCode;
            this.Fixed = false;
        }
    }
}

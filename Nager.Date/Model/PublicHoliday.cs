using System;

namespace Nager.Date.Model
{
    public class PublicHoliday
    {
        public DateTime Date { get; set; }
        public string LocalName { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public bool Fixed { get; set; }
        public bool Global { get { return this.Countys?.Length > 0 ? false : true; } }
        public string[] Countys { get; set; }

        public PublicHoliday(int day, int month, int year, string localName, string name, string countryCode, string[] countys = null)
        {
            this.Date = new DateTime(year, month, day);
            this.LocalName = localName;
            this.Name = name;
            this.CountryCode = countryCode;
            this.Fixed = true;
            if (countys?.Length > 0)
            {
                this.Countys = countys;
            }
        }

        public PublicHoliday(DateTime date, string localName, string name, string countryCode, string[] countys = null)
        {
            this.Date = date;
            this.LocalName = localName;
            this.Name = name;
            this.CountryCode = countryCode;
            this.Fixed = false;
            if (countys?.Length > 0)
            {
                this.Countys = countys;
            }
        }
    }
}
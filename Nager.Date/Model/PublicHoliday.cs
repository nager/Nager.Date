﻿using System;

namespace Nager.Date.Model
{
    public class PublicHoliday
    {
        public DateTime Date { get; set; }
        public string LocalName { get; set; }
        public string Name { get; set; }
        //ISO 3166-1 alpha-2
        public string CountryCode { get; set; }
        public bool Fixed { get; set; }
        public bool IsCountyOfficialHoliday { get; set; }
        public bool IsCountyAdministrationHoliday { get; set; }
        public bool Global { get { return this.Counties?.Length > 0 ? false : true; } }
        //ISO_3166-2
        public string[] Counties { get; set; }
        public int? LaunchYear { get; set; }

        public PublicHoliday(int day, int month, int year, string localName, string name, string countryCode, int? launchYear = null, string[] counties = null,
                                bool isCountyOfficialHoliday = true, bool isCountyAdministrationHoliday = true)
        {
            this.Date = new DateTime(year, month, day);
            this.LocalName = localName;
            this.Name = name;
            this.CountryCode = countryCode;
            this.Fixed = true;
            this.LaunchYear = launchYear;
            IsCountyOfficialHoliday = isCountyOfficialHoliday;
            IsCountyAdministrationHoliday = isCountyAdministrationHoliday;

            if (counties?.Length > 0)
            {
                this.Counties = counties;
            }
        }

        public PublicHoliday(DateTime date, string localName, string name, string countryCode, int? launchYear = null, string[] counties = null,
                                bool isCountyOfficialHoliday = true, bool isCountyAdministrationHoliday = true)
        {
            this.Date = date;
            this.LocalName = localName;
            this.Name = name;
            this.CountryCode = countryCode;
            this.Fixed = false;
            this.LaunchYear = launchYear;
            IsCountyOfficialHoliday = isCountyOfficialHoliday;
            IsCountyAdministrationHoliday = isCountyAdministrationHoliday;

            if (counties?.Length > 0)
            {
                this.Counties = counties;
            }
        }
    }
}
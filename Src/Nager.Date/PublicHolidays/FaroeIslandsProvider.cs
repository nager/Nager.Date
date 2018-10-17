﻿using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class FaroeIslandsProvider : CatholicBaseProvider
    {
        public FaroeIslandsProvider(IWeekendProvider weekendProvider) : base(weekendProvider)
        {
        }

        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Faroe Islands, adaptation of DenmarkProvider
            //https://en.wikipedia.org/wiki/Public_holidays_in_the_Faroe_Islands

            var countryCode = CountryCode.FO;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Nýggjársdagur", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-3), "Skírhósdagur", "Maundy Thursday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Langifríggjadagur", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Páskadagur", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "2. Páskadagur", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 4, 25, "Flaggdagur", "National Flag Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(26), "Store bededag", "General Prayer Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Kristi himmalsferðar dagur", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(49), "Hvítasunnudagur", "Pentecost", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "2. Hvítasunnudagur", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(year, 6, 5, "Grundlógardagur Danmarkar", "Constitution Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 28, "Ólavsøkuaftan", "Saint Olav's Eve", countryCode));
            items.Add(new PublicHoliday(year, 7, 29, "Ólavsøkudagur", "Saint Olav's Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Jólaaftanskvøld", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Jóladagur", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "2. Jóladagur", "St. Stephen's Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 31, "Nýggjársaftan", "New Year's Eve", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}

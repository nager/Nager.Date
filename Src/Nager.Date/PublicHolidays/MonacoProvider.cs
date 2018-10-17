﻿using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class MonacoProvider : CatholicBaseProvider
    {
        public MonacoProvider(IWeekendProvider weekendProvider) : base(weekendProvider)
        {
        }

        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Monaco
            //https://en.wikipedia.org/wiki/Public_holidays_in_Monaco

            var countryCode = CountryCode.MC;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();

            items.Add(new PublicHoliday(year, 1, 27, "La Sainte Dévote", "Saint Devota's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Easter Monday", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Le 1er mai", "May Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(40), "L’Ascension", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Le lundi de Pentecôte", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(60), "La Fête Dieu", "Corpus Christi", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "L'Assomption de Marie", "Assumption Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "L’Immaculée Conception", "The Immaculate Conception", countryCode));

            #region New Year's Day

            var newYearsDay = new DateTime(year, 1, 1).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(newYearsDay, "Le jour de l’An", "New Year's Day", countryCode));

            #endregion

            #region All Saints Day

            var allSaintsDay = new DateTime(year, 11, 1).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(allSaintsDay, "La Toussaint", "All Saints Day", countryCode));

            #endregion

            #region National Day / La Fête du Prince

            var nationalDay = new DateTime(year, 11, 19).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(nationalDay, "La Fête du Prince", "National Day", countryCode));

            #endregion

            #region Christmas Day

            var christmasDay = new DateTime(year, 12, 25).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(christmasDay, "Noël​", "​Christmas Day", countryCode));

            #endregion

            return items.OrderBy(o => o.Date);
        }
    }
}

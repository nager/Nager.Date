using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class BelizeProvider : CatholicBaseProvider
    {
        public BelizeProvider(IWeekendProvider weekendProvider) : base(weekendProvider)
        {
        }

        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Belize
            //https://en.wikipedia.org/wiki/Public_holidays_in_Belize

            var countryCode = CountryCode.BZ;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();

            #region New Year's Day

            var newYearsDay = new DateTime(year, 1, 1).Shift(saturday => saturday.AddDays(2), sunday => sunday);
            items.Add(new PublicHoliday(newYearsDay, "New Year's Day", "New Year's Day", countryCode));

            #endregion

            #region Baron Bliss Day

            var baronBlissDay = new DateTime(year, 3, 9).ShiftWeekdays(
                tuesday: tuesday => tuesday.AddDays(-1),
                wednesday: wednesday => wednesday.AddDays(-2),
                thursday: thursday => thursday.AddDays(-3)
                );
            items.Add(new PublicHoliday(baronBlissDay, "Baron Bliss Day", "Baron Bliss Day", countryCode));

            #endregion

            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-1), "Holy Saturday", "Holy Saturday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Easter Sunday", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Easter Monday", "Easter Monday", countryCode));

            #region Labour Day

            var labourDay = new DateTime(year, 5, 1).Shift(saturday => saturday.AddDays(2), sunday => sunday);
            items.Add(new PublicHoliday(labourDay, "Labour Day", "Labour Day", countryCode));

            #endregion

            #region Commonwealth Day

            var commonwealthDay = new DateTime(year, 5, 24).ShiftWeekdays(
                tuesday: tuesday => tuesday.AddDays(-1),
                wednesday: wednesday => wednesday.AddDays(-2),
                thursday: thursday => thursday.AddDays(-3)
                );
            items.Add(new PublicHoliday(commonwealthDay, "Commonwealth Day", "Commonwealth Day", countryCode));

            #endregion

            #region Saint George's Caye Day

            var saintGeorgesCayeDay = new DateTime(year, 9, 10).Shift(saturday => saturday.AddDays(2), sunday => sunday);
            items.Add(new PublicHoliday(saintGeorgesCayeDay, "Saint George's Caye Day", "Saint George's Caye Day", countryCode));

            #endregion

            #region Independence Day

            var independenceDay = new DateTime(year, 9, 21).Shift(saturday => saturday.AddDays(2), sunday => sunday);
            items.Add(new PublicHoliday(independenceDay, "Independence Day", "Independence Day", countryCode));

            #endregion

            #region Day of the Americas

            var dayOfTheAmericas = new DateTime(year, 10, 12).ShiftWeekdays(
                tuesday: tuesday => tuesday.AddDays(-1),
                wednesday: wednesday => wednesday.AddDays(-2),
                thursday: thursday => thursday.AddDays(-3)
                );
            items.Add(new PublicHoliday(dayOfTheAmericas, "Day of the Americas", "Day of the Americas", countryCode));

            #endregion

            #region Garifuna Settlement Day

            var garifunaSettlementDay = new DateTime(year, 11, 19).Shift(saturday => saturday.AddDays(2), sunday => sunday);
            items.Add(new PublicHoliday(garifunaSettlementDay, "Garifuna Settlement Day", "Garifuna Settlement Day", countryCode));

            #endregion

            #region Christmas Day

            var christmasDay = new DateTime(year, 12, 25).Shift(saturday => saturday.AddDays(2), sunday => sunday);
            items.Add(new PublicHoliday(christmasDay, "Christmas Day", "Christmas Day", countryCode));

            #endregion

            #region Boxing Day

            var boxingDay = new DateTime(year, 12, 26).Shift(saturday => saturday.AddDays(2), sunday => sunday);
            items.Add(new PublicHoliday(boxingDay, "Boxing Day", "Boxing Day", countryCode));

            #endregion

            return items.OrderBy(o => o.Date);
        }
    }
}

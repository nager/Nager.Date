using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Belgium HolidayProvider
    /// </summary>
    internal sealed class BelgiumHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Belgium HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public BelgiumHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.BE;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Nieuwjaar",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Dag van de arbeid",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 21),
                    EnglishName = "Belgian National Day",
                    LocalName = "Nationale feestdag",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption Day",
                    LocalName = "Onze Lieve Vrouw hemelvaart",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints' Day",
                    LocalName = "Allerheiligen",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 11),
                    EnglishName = "Armistice Day",
                    LocalName = "Wapenstilstand",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Kerstdag",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Bank,
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(40),
                    EnglishName = "Day after Ascension Day",
                    LocalName = "Day after Ascension Day",
                    HolidayTypes = HolidayTypes.Bank,
                },
                this._catholicProvider.GoodFriday("Goede Vrijdag", year).SetHolidayTypes(HolidayTypes.Bank),
                this._catholicProvider.EasterSunday("Pasen", year),
                this._catholicProvider.EasterMonday("Paasmaandag", year),
                this._catholicProvider.AscensionDay("Onze Lieve Heer hemel", year),
                this._catholicProvider.WhitMonday("Pinkstermaandag", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Nieuwjaar", "New Year's Day", countryCode, 1967));
            //items.Add(this._catholicProvider.GoodFriday("Goede Vrijdag", year, countryCode).SetType(HolidayTypes.Bank));
            //items.Add(this._catholicProvider.EasterSunday("Pasen", year, countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Paasmaandag", year, countryCode).SetLaunchYear(1642));
            //items.Add(new Holiday(year, 5, 1, "Dag van de arbeid", "Labour Day", countryCode));
            //items.Add(this._catholicProvider.AscensionDay("Onze Lieve Heer hemel", year, countryCode));
            //items.Add(new Holiday(easterSunday.AddDays(40), "Day after Ascension Day", "Day after Ascension Day", countryCode).SetType(HolidayTypes.Bank));
            //items.Add(this._catholicProvider.WhitMonday("Pinkstermaandag", year, countryCode));
            //items.Add(new Holiday(year, 7, 21, "Nationale feestdag", "Belgian National Day", countryCode));
            //items.Add(new Holiday(year, 8, 15, "Onze Lieve Vrouw hemelvaart", "Assumption Day", countryCode));
            //items.Add(new Holiday(year, 11, 1, "Allerheiligen", "All Saints' Day", countryCode));
            //items.Add(new Holiday(year, 11, 11, "Wapenstilstand", "Armistice Day", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Kerstdag", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode).SetType(HolidayTypes.Bank));

            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Belgium",
                "https://www.nbb.be/en/about-national-bank/national-bank-belgium/public-holidays",
                "https://www.bnpparibasfortis.be/public/nl/public/particulieren/sluitingsdagen"
            };
        }
    }
}

using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Cyprus HolidayProvider
    /// </summary>
    internal sealed class CyprusHolidayProvider : AbstractHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// Cyprus HolidayProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public CyprusHolidayProvider(
            IOrthodoxProvider orthodoxProvider) : base(CountryCode.CY)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var easterSunday = this._orthodoxProvider.EasterSunday(year);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Πρωτοχρονιά",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Epiphany",
                    LocalName = "Θεοφάνεια",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 25),
                    EnglishName = "Greek Independence Day",
                    LocalName = "Επέτειος Ελληνικής Ανεξαρτησίας",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 1),
                    EnglishName = "Cyprus National Day",
                    LocalName = "Κυπριακή Εθνική Επέτειος",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Πρωτομαγιά",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption of the Virgin Mary",
                    LocalName = "Η Κοίμησις της Θεοτόκου",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 1),
                    EnglishName = "Cyprus Independence Day",
                    LocalName = "Επέτειος Κυπριακής Ανεξαρτησίας",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 28),
                    EnglishName = "Ohi Day",
                    LocalName = "Το Όχι",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Παραμονή Χριστουγέννων",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Χριστούγεννα",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Δεύτερη μέρα των Χριστουγέννων",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(-48),
                    EnglishName = "Green Monday",
                    LocalName = "Καθαρή Δευτέρα",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(2),
                    EnglishName = "Easter Tuesday",
                    LocalName = "Τρίτη της Διακαινησίμου",
                    HolidayTypes = HolidayTypes.Bank
                },
                this._orthodoxProvider.GoodFriday("Μεγάλη Παρασκευή", year),
                this._orthodoxProvider.EasterMonday("Δευτέρα της Διακαινησίμου", year),
                this._orthodoxProvider.Pentecost("Αγίου Πνεύματος", year),
                this._orthodoxProvider.WhitMonday("Δευτέρα Πεντηκοστής", year)
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Cyprus",
            ];
        }
    }
}

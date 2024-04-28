using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Greece HolidayProvider
    /// </summary>
    internal sealed class GreeceHolidayProvider : AbstractHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// Greece HolidayProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public GreeceHolidayProvider(
            IOrthodoxProvider orthodoxProvider) : base(CountryCode.GR)
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
                    EnglishName = "Annunciation",
                    LocalName = "Ευαγγελισμός της Θεοτόκου",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 25),
                    EnglishName = "Independence Day",
                    LocalName = "Εικοστή Πέμπτη Μαρτίου",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption Day",
                    LocalName = "Κοίμηση της Θεοτόκου",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 28),
                    EnglishName = "Ochi Day",
                    LocalName = "Το Όχι",
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
                    LocalName = "Σύναξις Υπεραγίας Θεοτόκου Μαρίας",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(-48),
                    EnglishName = "Clean Monday",
                    LocalName = "Καθαρά Δευτέρα",
                    HolidayTypes = HolidayTypes.Public
                },
                this._orthodoxProvider.GoodFriday("Μεγάλη Παρασκευή", year),
                this._orthodoxProvider.EasterSunday("Κυριακή του Πάσχα", year),
                this._orthodoxProvider.EasterMonday("Δευτέρα του Πάσχα", year),
                this._orthodoxProvider.Pentecost("Πεντηκοστή", year),
                this._orthodoxProvider.WhitMonday("Δευτέρα Πεντηκοστής", year)
            };

            holidaySpecifications.AddIfNotNull(this.LabourDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification LabourDay(int year)
        {
            var englishName = "Labour Day";
            var localName = "Εργατική Πρωτομαγιά";

            // Government Gazette B' 1406/4.3.2024 - 15102
            if (year == 2024)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 7),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public
                };
            }

            return new HolidaySpecification
            {
                Date = new DateTime(year, 5, 1),
                EnglishName = englishName,
                LocalName = localName,
                HolidayTypes = HolidayTypes.Public
            };
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Greece",
            ];
        }
    }
}

using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Georgia HolidayProvider
    /// </summary>
    internal sealed class GeorgiaHolidayProvider : AbstractHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// Georgia HolidayProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public GeorgiaHolidayProvider(
            IOrthodoxProvider orthodoxProvider) : base(CountryCode.GE)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "ახალი წელი",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 2),
                    EnglishName = "New Year's Day",
                    LocalName = "ახალი წელი",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 7),
                    EnglishName = "Orthodox Christmas",
                    LocalName = "ქრისტეშობა",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 19),
                    EnglishName = "Orthodox Epiphany",
                    LocalName = "ნათლისღება",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 3),
                    EnglishName = "Mother's Day",
                    LocalName = "დედის დღე",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "International Women's Day",
                    LocalName = "ქალთა საერთაშორისო დღე",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 9),
                    EnglishName = "National Unity Day",
                    LocalName = "ეროვნული ერთიანობის დღე",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 9),
                    EnglishName = "Day of Victory over Fascism",
                    LocalName = "ფაშიზმზე გამარჯვების დღე",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 12),
                    EnglishName = "Saint Andrew the First-Called Day",
                    LocalName = "წმინდა მოციქულის ანდრია პირველწოდებულის საქართველოში შემოსვლის დღე",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 26),
                    EnglishName = "Independence Day",
                    LocalName = "დამოუკიდებლობის დღე",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 28),
                    EnglishName = "Saint Mary's Day",
                    LocalName = "მარიამობა",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 14),
                    EnglishName = "Day of Svetitskhoveli Cathedra",
                    LocalName = "სვეტიცხოვლობა",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 23),
                    EnglishName = "Saint George's Day",
                    LocalName = "გიორგობა",
                    HolidayTypes = HolidayTypes.Public
                },
                this._orthodoxProvider.GoodFriday("ძველი პარასკევი", year),
                this._orthodoxProvider.HolySaturday("დიდი შაბათი", year),
                this._orthodoxProvider.EasterSunday("აღდგომის კვირა", year),
                this._orthodoxProvider.EasterMonday("აღდგომის ორშაბათი", year),
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Georgia",
            ];
        }
    }
}

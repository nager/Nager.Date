using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Eritrea HolidayProvider
    /// </summary>
    internal sealed class EritreaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Eritrea HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public EritreaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.ER)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Amet ሓዲሽ ዓመት",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ORTHODOXCHRISTMASDAY-01",
                    Date = new DateTime(year, 1, 7),
                    EnglishName = "Orthodox Christmas",
                    LocalName = "Lidet ልደት",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ORTHODOXEPIPHANY-01",
                    Date = new DateTime(year, 1, 19),
                    EnglishName = "Orthodox Epiphany",
                    LocalName = "Timket ጥምቀት",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "WOMENSDAY-01",
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "Women's Day",
                    LocalName = "Maelti Anesti መዓልቲ ኣነስቲ",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "MAYDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "May Day",
                    LocalName = "May Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 5, 24),
                    EnglishName = "Independence Day",
                    LocalName = "Maelti Natsinet መዓልቲ ናጽነት",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "MARTYRSDAY-01",
                    Date = new DateTime(year, 6, 20),
                    EnglishName = "Martyrs' Day",
                    LocalName = "Maelti Siwuat መዓልቲ ስውኣት",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "REVOLUTIONDAY-01",
                    Date = new DateTime(year, 9, 1),
                    EnglishName = "Revolution Day",
                    LocalName = "Bahti Meskerem ባሕቲ መስከረም",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._catholicProvider.GoodFriday("Arbi Siklet ዓርቢ ስቅለት", year),
                this._catholicProvider.EasterSunday("Fasika ፋሲካ", year),
            };

            // Islamic Holidays in Eritrea
            // CalendarType: Lunar (Hijri)
            // DeterminationType: MoonSighting (By the Dar Al-Ifta / Mufti of Eritrea)
            // Astronomical calculation: No (Used only as a guide; official announcement depends on actual physical sighting of the crescent moon)
            //variable	Birth of the Prophet		observed by adherents of Sunni Islam
            //variable	Eid al-Fitr		observed by adherents of Sunni Islam
            //variable	Eid al-Adha		observed by adherents of Sunni Islam

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Eritrea",
            ];
        }
    }
}

using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Ethiopia HolidayProvider
    /// </summary>
    internal sealed class EthiopiaHolidayProvider : AbstractHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// Ethiopia HolidayProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public EthiopiaHolidayProvider(
            IOrthodoxProvider orthodoxProvider) : base(CountryCode.ET)
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
                    Id = "ADWAVICTORYDAY-01",
                    Date = new DateTime(year, 3, 2),
                    EnglishName = "Adwa Victory Day",
                    LocalName = "የዓድዋ ድል በዓል",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INTERNATIONALWORKERSDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "International Workers' Day",
                    LocalName = "ዓለም አቀፍ የሠራተኞች ቀን",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "VICTORYDAY-01",
                    Date = new DateTime(year, 5, 5),
                    EnglishName = "Ethiopian Patriots' Victory Day",
                    LocalName = "የአርበኞች ቀን",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "DOWNFALLOFTHEDERG-01",
                    Date = new DateTime(year, 5, 28),
                    EnglishName = "Downfall of the Derg",
                    LocalName = "ደርግ የወደቀበት ቀን",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "OCHRISTMAS-01",
                    Date = new DateTime(year, 1, 7),
                    EnglishName = "Christmas Day (Orthodox)",
                    LocalName = "ልደተ-ለእግዚእነ/ ገና",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._orthodoxProvider.GoodFriday("ስቅለት", year),
                this._orthodoxProvider.EasterSunday("ብርሃነ-ትንሣኤ/ፋሲካ", year),
            };

            holidaySpecifications.AddIfNotNull(this.Enkutatash(year));
            holidaySpecifications.AddIfNotNull(this.Epiphany(year));
            holidaySpecifications.AddIfNotNull(this.Meskel(year));

            holidaySpecifications.AddIfNotNull(this.RevolutionDay(year));
            holidaySpecifications.AddIfNotNull(this.DefenseDay(year));
            holidaySpecifications.AddIfNotNull(this.OctoberRevolutionDay(year));

            //TODO: Islamic Holidays
            //CalendarType: Lunar
            //DeterminationType: MoonSighting (Ethiopian Islamic Affairs Supreme Council (EIASC))
            //Astronomical calculation: No (Used only as a guide; official announcement depends on actual sighting)
            //Moveable	Ramadan	Ramadaan	Ninth month, devoted to fasting
            //12 Rabi' al-awwal (Sunni)	Mawlid	Mawliid	Birth of the Prophet
            //17 Rabi' al-awwal (Shia)	Mawlid	Mawliid	Birth of the Prophet
            //1 Shawwal	Eid al-Fitr	Iid al-Fitrii	Breaking of the Fast
            //10 Dhu al-Hijjah	Eid al-Adha	Iid al-Adhaa	Feast of the Sacrifice

            return holidaySpecifications;
        }

        private HolidaySpecification Epiphany(
            int year)
        {
            var holidayDate = new DateTime(year, 1, 19);

            if (DateTime.IsLeapYear(year))
            {
                holidayDate = holidayDate.AddDays(1);
            }

            return new HolidaySpecification
            {
                Id = "OEPIPHANY-01",
                Date = holidayDate,
                EnglishName = "Epiphany (Orthodox)",
                LocalName = "ნათლისღება",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification Meskel(
            int year)
        {
            var holidayDate = new DateTime(year, 9, 27);

            if (DateTime.IsLeapYear(year))
            {
                holidayDate = holidayDate.AddDays(1);
            }

            return new HolidaySpecification
            {
                Id = "OMESKEL-01",
                Date = holidayDate,
                EnglishName = "Meskel (Orthodox)",
                LocalName = "መስቀል",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification Enkutatash(
            int year)
        {
            var holidayDate = new DateTime(year, 9, 11);

            if (DateTime.IsLeapYear(year))
            {
                holidayDate = holidayDate.AddDays(1);
            }

            return new HolidaySpecification
            {
                Id = "ENKUTATASH-01",
                Date = holidayDate,
                EnglishName = "Enkutatash",
                LocalName = "እንቁጣጣሽ/የዘመን መለወጫ/አዲስ አመት",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification? RevolutionDay(
            int year)
        {
            if (year >= 1974 && year <= 1991)
            {
                return new HolidaySpecification
                {
                    Id = "REVOLUTIONDAY-01",
                    Date = new DateTime(year, 9, 12),
                    EnglishName = "Revolution Day",
                    LocalName = "የአብዮት ቀን",
                    HolidayTypes = HolidayTypes.Public,
                };
            }

            return null;
        }

        private HolidaySpecification? DefenseDay(
            int year)
        {
            if (year >= 1974 && year <= 1991)
            {
                return new HolidaySpecification
                {
                    Id = "DEFENSEDAY-01",
                    Date = new DateTime(year, 10, 26),
                    EnglishName = "Defense Day",
                    LocalName = "የመከላከያ ቀን",
                    HolidayTypes = HolidayTypes.Public,
                };
            }

            return null;
        }

        private HolidaySpecification? OctoberRevolutionDay(
            int year)
        {
            if (year >= 1974 && year <= 1991)
            {
                return new HolidaySpecification
                {
                    Id = "OCTOBERREVOLUTIONDAY-01",
                    Date = new DateTime(year, 11, 7),
                    EnglishName = "October Revolution Day",
                    LocalName = "የጥቅምት አብዮት ቀን",
                    HolidayTypes = HolidayTypes.Public,
                };
            }

            return null;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Ethiopia",
            ];
        }
    }
}

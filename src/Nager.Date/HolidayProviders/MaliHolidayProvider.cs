using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Mali HolidayProvider
    /// </summary>
    internal sealed class MaliHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Mali HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public MaliHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.ML)
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
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ARMEDFORCESDAY-01",
                    Date = new DateTime(year, 1, 20),
                    EnglishName = "Armed Forces Day",
                    LocalName = "Armed Forces Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "MARTYRSDAY-01",
                    Date = new DateTime(year, 3, 25),
                    EnglishName = "Martyrs' Day",
                    LocalName = "Martyrs' Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "WORKERSDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Workers' Day",
                    LocalName = "Workers' Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "AFRICADAY-01",
                    Date = new DateTime(year, 5, 25),
                    EnglishName = "Africa Day",
                    LocalName = "Africa Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 9, 22),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._catholicProvider.EasterMonday("Easter Monday", year),
            };

            holidaySpecifications.AddRangeIfNotNull(this.GetIslamicCalendarHolidays(year));

            return holidaySpecifications;
        }

        private HolidaySpecification[] GetIslamicCalendarHolidays(int year)
        {
            // TODO: Implement Hijri adjustment mechanism (similar to TürkiyeHolidayProvider, but with specific Mali offset values).

            var items = new List<HolidaySpecification>();

            void AddHoliday(DateTime date, string id, string englishName, string localName)
            {
                if (date.Year != year)
                {
                    return;
                }

                items.Add(new HolidaySpecification
                {
                    Id = id,
                    EnglishName = $"{englishName} (Roughly Date)",
                    LocalName = $"{localName} (Roughly Date)",
                    Date = date,
                    HolidayTypes = HolidayTypes.Public
                });
            }

            var hijriCalendar = new HijriCalendar();
            if (year > hijriCalendar.MinSupportedDateTime.Year && year < hijriCalendar.MaxSupportedDateTime.Year)
            {
                var startHijriYear = hijriCalendar.GetYear(new DateTime(year, 1, 1));

                for (var hijriYear = startHijriYear; hijriYear <= startHijriYear + 2; hijriYear++)
                {
                    AddHoliday(hijriCalendar.ToDateTime(hijriYear, 1, 10, 0, 0, 0, 0),
                        $"ASHURA-{hijriYear}-01",
                        "Ashura",
                        "Ashura");

                    AddHoliday(hijriCalendar.ToDateTime(hijriYear, 3, 12, 0, 0, 0, 0),
                        $"MAWLOUD-{hijriYear}-01",
                        "Mawloud",
                        "Mawloud");

                    AddHoliday(hijriCalendar.ToDateTime(hijriYear, 3, 19, 0, 0, 0, 0),
                        $"BAPTISMOFTHEPROPHET-{hijriYear}-01",
                        "Baptism of the Prophet",
                        "Baptism of the Prophet");

                    AddHoliday(hijriCalendar.ToDateTime(hijriYear, 9, 27, 0, 0, 0, 0),
                        $"LEYLATOULQADR-{hijriYear}-01",
                        "Leylatoul Qadr",
                        "Leylatoul Qadr");

                    AddHoliday(hijriCalendar.ToDateTime(hijriYear, 10, 1, 0, 0, 0, 0),
                        $"KORITE-{hijriYear}-01",
                        "Korité",
                        "Korité");

                    AddHoliday(hijriCalendar.ToDateTime(hijriYear, 12, 10, 0, 0, 0, 0),
                        $"TABASKI-{hijriYear}-01",
                        "Tabaski",
                        "Tabaski");
                }
            }

            return [.. items];
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Mali",
            ];
        }
    }
}

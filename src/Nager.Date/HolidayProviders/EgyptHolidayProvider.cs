using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Egypt HolidayProvider
    /// </summary>
    internal sealed class EgyptHolidayProvider : AbstractHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;
        private readonly UmAlQuraCalendar _umAlQuraCalendar;

        public EgyptHolidayProvider(IOrthodoxProvider orthodoxProvider) : base(CountryCode.EG)
        {
            this._orthodoxProvider = orthodoxProvider;
            this._umAlQuraCalendar = new UmAlQuraCalendar();
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "عيد العمال",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = new ObservedRuleSet
                    {
                        Monday = date => date.AddDays(3),
                        Tuesday = date => date.AddDays(2),
                        Wednesday = date => date.AddDays(4),
                        Friday = date => date.AddDays(6),
                    }
                },
                this._orthodoxProvider.EasterMonday("Sham El-Nessim", year)
            };

            holidaySpecifications.AddIfNotNull(this.ChristmasDay(year));
            holidaySpecifications.AddIfNotNull(this.ArmedForcesDay(year));
            holidaySpecifications.AddIfNotNull(this.SinaiLiberationDay(year));
            holidaySpecifications.AddIfNotNull(this.June30Revolution(year));
            holidaySpecifications.AddIfNotNull(this.RevolutionDay(year));
            holidaySpecifications.AddIfNotNull(this.RevolutionDay2011(year));
            holidaySpecifications.AddRangeIfNotNull(this.IslamicNewYear(year));
            holidaySpecifications.AddRangeIfNotNull(this.ProphetMuhammadsBirthday(year));
            holidaySpecifications.AddRangeIfNotNull(this.EidAlAdha(year));

            return holidaySpecifications;
        }

        private HolidaySpecification[] IslamicNewYear(int year)
        {
            if (year >= this._umAlQuraCalendar.MinSupportedDateTime.Year && year <= this._umAlQuraCalendar.MaxSupportedDateTime.Year)
            {
                var startHijriYear = this._umAlQuraCalendar.GetYear(new DateTime(year, 1, 1));

                var month = 1; //Muharram
                var items = new List<HolidaySpecification>();

                for (var hijriYear = startHijriYear; hijriYear <= startHijriYear + 2; hijriYear++)
                {
                    if (hijriYear > this._umAlQuraCalendar.TwoDigitYearMax)
                    {
                        break;
                    }

                    var newYearDate = this._umAlQuraCalendar.ToDateTime(hijriYear, month, 1, 0, 0, 0, 0);

                    if (newYearDate.Year == year)
                    {
                        items.Add(new HolidaySpecification
                        {
                            Id = $"ISLAMICNEWYEAR-{hijriYear}-01",
                            Date = newYearDate,
                            EnglishName = "Islamic New Year",
                            LocalName = "Islamic New Year",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Monday = date => date.AddDays(3),
                                Tuesday = date => date.AddDays(2),
                                Sunday = date => date.AddDays(4),
                            }
                        });
                    }
                }

                return [.. items];
            }

            return [];
        }

        private HolidaySpecification[] EidAlAdha(int year)
        {
            DateTime[] holidayDates = year switch
            {
                2021 => [new DateTime(2021, 7, 17), new DateTime(2021, 7, 23)],
                2022 => [new DateTime(2022, 7, 9), new DateTime(2022, 7, 14)],
                2023 => [new DateTime(2023, 6, 27), new DateTime(2023, 7, 1)],
                2024 => [new DateTime(2024, 6, 15), new DateTime(2024, 6, 20)],
                2025 => [new DateTime(2025, 6, 6), new DateTime(2025, 6, 9)],
                2026 => [new DateTime(2026, 5, 27), new DateTime(2026, 5, 31)],
                _ => []
            };

            if (holidayDates.Length > 0)
            {
                var startDate = holidayDates.First();
                var endDate = holidayDates.Last();

                var allHolidayDates = Enumerable.Range(0, (endDate - startDate).Days + 1)
                    .Select(offset => startDate.AddDays(offset))
                    .ToArray();

                return [.. allHolidayDates.Select((date, index) => new HolidaySpecification
                {
                    Id = $"EIDALADHA-{(index + 1):00}",
                    Date = date,
                    EnglishName = "Eid Al-Adha",
                    LocalName = "Eid Al-Adha",
                    HolidayTypes = HolidayTypes.Public,
                })];
            }

            return [];
        }

        private HolidaySpecification[] ProphetMuhammadsBirthday(int year)
        {
            var minSupportedYear = 2021;
            if (year < minSupportedYear)
            {
                return [];
            }

            var holidayName = "Prophet Muhammad's Birthday";

            DateTime[] holidayDates = year switch
            {
                2021 => [new DateTime(2021, 10, 18)],
                2022 => [new DateTime(2022, 10, 8)],
                2023 => [new DateTime(2023, 9, 27)],
                2024 => [new DateTime(2024, 9, 16)],
                2025 => [new DateTime(2025, 9, 4)],
                2026 => [new DateTime(2026, 8, 26)],
                _ => []
            };

            if (holidayDates.Length > 0)
            {
                return [.. holidayDates.Select((date, index) => new HolidaySpecification
                {
                    Id = $"PROPHETMUHAMMADSBIRTHDAY-{(index +1):00}",
                    Date = date,
                    EnglishName = holidayName,
                    LocalName = holidayName,
                    HolidayTypes = HolidayTypes.Public,
                })];
            }

            if (year >= this._umAlQuraCalendar.MinSupportedDateTime.Year && year <= this._umAlQuraCalendar.MaxSupportedDateTime.Year)
            {
                var startHijriYear = this._umAlQuraCalendar.GetYear(new DateTime(year, 1, 1));

                var month = 3; //Rabi' al-Awwal
                var items = new List<HolidaySpecification>();

                for (var hijriYear = startHijriYear; hijriYear <= startHijriYear + 2; hijriYear++)
                {
                    if (hijriYear > this._umAlQuraCalendar.TwoDigitYearMax)
                    {
                        break;
                    }

                    var newYearDate = this._umAlQuraCalendar.ToDateTime(hijriYear, month, 12, 0, 0, 0, 0);

                    if (newYearDate.Year == year)
                    {
                        items.Add(new HolidaySpecification
                        {
                            Id = $"PROPHETMUHAMMADSBIRTHDAY-{hijriYear}-01",
                            Date = newYearDate,
                            EnglishName = $"{holidayName} (Tentative Date)",
                            LocalName = $"{holidayName} (Tentative Date)",
                            HolidayTypes = HolidayTypes.Public,
                        });
                    }
                }

                return [.. items];
            }

            return [];
        }

        private HolidaySpecification RevolutionDay2011(int year)
        {
            var holidayDate = year switch
            {
                2021 => new DateTime(year, 1, 28),
                2022 => new DateTime(year, 1, 27),
                2023 => new DateTime(year, 1, 26),
                2026 => new DateTime(year, 1, 29),
                _ => new DateTime(year, 1, 25)
            };

            return new HolidaySpecification
            {
                Id = "REVOLUTIONDAY2011-01",
                Date = holidayDate,
                EnglishName = "Revolution Day 2011 / National Police Day",
                LocalName = "عيد الثورة 25 يناير",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification RevolutionDay(int year)
        {
            var holidayDate = year switch
            {
                2021 => new DateTime(year, 7, 24),
                2024 => new DateTime(year, 7, 25),
                2025 => new DateTime(year, 7, 24),
                2026 => new DateTime(year, 7, 23),
                _ => new DateTime(year, 7, 23)
            };

            return new HolidaySpecification
            {
                Id = "REVOLUTIONDAY-01",
                Date = holidayDate,
                EnglishName = "Revolution Day",
                LocalName = "عيد ثورة 23 يوليو",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification ArmedForcesDay(int year)
        {
            var holidayDate = year switch
            {
                2021 => new DateTime(year, 10, 7),
                _ => new DateTime(year, 10, 6)
            };

            return new HolidaySpecification
            {
                Id = "ARMEDFORCESDAY-01",
                Date = holidayDate,
                EnglishName = "Armed Forces Day",
                LocalName = "عيد القوات المسلحة",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification ChristmasDay(int year)
        {
            var holidayDate = year switch
            {
                2022 => new DateTime(year, 1, 6),
                2023 => new DateTime(year, 1, 8),
                _ => new DateTime(year, 1, 7)
            };

            return new HolidaySpecification
            {
                Id = "ORTHODOXCHRISTMASDAY-01",
                Date = holidayDate,
                EnglishName = "Christmas Day (Orthodox)",
                LocalName = "عيد الميلاد المجيد",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification? June30Revolution(int year)
        {
            var id = "JUNE30REVOLUTION-01";
            var englishName = "June 30 Revolution";
            var localName = "ثورة 30 يونيو";

            if (year >= 2015 && year <= 2017)
            {
                return new HolidaySpecification
                {
                    Id = id,
                    Date = new DateTime(year, 6, 30),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                };
            }
            else if (year == 2018)
            {
                return new HolidaySpecification
                {
                    Id = id,
                    Date = new DateTime(year, 7, 1),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                };
            }
            else if (year >= 2019 && year <= 2020)
            {
                return new HolidaySpecification
                {
                    Id = id,
                    Date = new DateTime(year, 6, 30),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                };
            }
            else if (year >= 2021)
            {
                var observedRuleSet = new ObservedRuleSet
                {
                    Monday = date => date.AddDays(3),
                    Tuesday = date => date.AddDays(2),
                    Wednesday = date => date.AddDays(1),
                    //Friday = date => date.AddDays(2),
                };

                return new HolidaySpecification
                {
                    Id = id,
                    Date = new DateTime(year, 6, 30),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                };
            }

            return null;
        }

        private HolidaySpecification SinaiLiberationDay(int year)
        {
            var id = "SINAILIBERATIONDAY-01";
            var englishName = "Sinai Liberation Day";
            var localName = "عيد تحرير سيناء";

            var holidayDate = year switch
            {
                2021 => new DateTime(year, 4, 29),
                2025 => new DateTime(year, 4, 24),
                _ => new DateTime(year, 4, 25)
            };

            return new HolidaySpecification
            {
                Id = id,
                Date = holidayDate,
                EnglishName = englishName,
                LocalName = localName,
                HolidayTypes = HolidayTypes.Public,
            };
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Egypt",
                "https://www.sis.gov.eg/Story/207089/Egypt-sets-April-21%2C-April-24%2C-May-1-as-public-holidays?lang=en-us",
            ];
        }
    }
}

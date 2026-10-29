using Nager.Date.Extensions;
using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Mongolia HolidayProvider
    /// </summary>
    internal sealed class MongoliaHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Mongolia HolidayProvider
        /// </summary>
        public MongoliaHolidayProvider() : base(CountryCode.MN)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            //TODO:Add Mongolian lunar calendar support (Tsagaan Sar, Buddha Day, Chinggis Khaan's Birthday are maintained manually)

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Шинэ жил (Shine jil)",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INTERNATIONALWOMENSDAY-01",
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "International Women's Day",
                    LocalName = "Олон Улсын Эмэгтэйчүүдийн Баяр",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHILDRENSDAY-01",
                    Date = new DateTime(year, 6, 1),
                    EnglishName = "Children’s Day",
                    LocalName = "хүүхдийн баяр",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "REPUBLICDAY-01",
                    Date = new DateTime(year, 11, 26),
                    EnglishName = "Republic Day",
                    LocalName = "Улс тунхагласны өдөр",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 12, 29),
                    EnglishName = "Independence Day",
                    LocalName = "Тусгаар Тогтнолын Өдөр",
                    HolidayTypes = HolidayTypes.Public,
                }
            };

            holidaySpecifications.AddRange(this.NaadamHoliday(year));
            holidaySpecifications.AddRange(this.TsagaanSarHoliday(year));
            holidaySpecifications.AddIfNotNull(this.BuddhaDay(year));
            holidaySpecifications.AddIfNotNull(this.ChinggisKhaansBirthday(year));

            return holidaySpecifications;
        }

        private HolidaySpecification[] NaadamHoliday(int year)
        {
            var holidaySpecifications = new List<HolidaySpecification>();

            // Amendment of the Law on Public Holidays and Anniversaries (28 June 2022, in force since 8 July 2022)
            // extended Naadam to 10 – 15 July
            if (year >= 2022)
            {
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "NAADAM-06",
                    Date = new DateTime(year, 7, 10),
                    EnglishName = "Naadam Holiday",
                    LocalName = "Наадам",
                    HolidayTypes = HolidayTypes.Public,
                });
            }

            // 11 – 13 July, the original three-day Naadam holiday
            holidaySpecifications.AddRange(
            [
                new HolidaySpecification
                {
                    Id = "NAADAM-01",
                    Date = new DateTime(year, 7, 11),
                    EnglishName = "Naadam Holiday",
                    LocalName = "Наадам",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NAADAM-02",
                    Date = new DateTime(year, 7, 12),
                    EnglishName = "Naadam Holiday",
                    LocalName = "Наадам",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NAADAM-03",
                    Date = new DateTime(year, 7, 13),
                    EnglishName = "Naadam Holiday",
                    LocalName = "Наадам",
                    HolidayTypes = HolidayTypes.Public,
                },
            ]);

            // Amendment of the Law on Public Holidays and Anniversaries (20 December 2019)
            // extended Naadam to five days (11 – 15 July) starting 2020
            if (year >= 2020)
            {
                holidaySpecifications.AddRange(
                [
                    new HolidaySpecification
                    {
                        Id = "NAADAM-04",
                        Date = new DateTime(year, 7, 14),
                        EnglishName = "Naadam Holiday",
                        LocalName = "Наадам",
                        HolidayTypes = HolidayTypes.Public,
                    },
                    new HolidaySpecification
                    {
                        Id = "NAADAM-05",
                        Date = new DateTime(year, 7, 15),
                        EnglishName = "Naadam Holiday",
                        LocalName = "Наадам",
                        HolidayTypes = HolidayTypes.Public,
                    },
                ]);
            }

            return holidaySpecifications.ToArray();
        }

        private HolidaySpecification[] TsagaanSarHoliday(int year)
        {
            // 1st day of the first spring month of the Mongolian lunar calendar (2027 provisional)
            DateTime? firstDay = year switch
            {
                2020 => new DateTime(2020, 2, 24),
                2021 => new DateTime(2021, 2, 12),
                2022 => new DateTime(2022, 2, 2),
                2023 => new DateTime(2023, 2, 21),
                2024 => new DateTime(2024, 2, 10),
                2025 => new DateTime(2025, 3, 1),
                2026 => new DateTime(2026, 2, 18),
                2027 => new DateTime(2027, 2, 7),
                _ => null,
            };

            if (firstDay is null)
            {
                return [];
            }

            return
            [
                new HolidaySpecification
                {
                    Id = "TSAGAANSAR-01",
                    Date = firstDay.Value,
                    EnglishName = "Lunar New Year (Tsagaan Sar)",
                    LocalName = "Цагаан сар",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "TSAGAANSAR-02",
                    Date = firstDay.Value.AddDays(1),
                    EnglishName = "Lunar New Year (Tsagaan Sar)",
                    LocalName = "Цагаан сар",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "TSAGAANSAR-03",
                    Date = firstDay.Value.AddDays(2),
                    EnglishName = "Lunar New Year (Tsagaan Sar)",
                    LocalName = "Цагаан сар",
                    HolidayTypes = HolidayTypes.Public,
                },
            ];
        }

        private HolidaySpecification? BuddhaDay(int year)
        {
            // 15th day of the first summer month of the Mongolian lunar calendar, public holiday since 2020 (2027 provisional)
            DateTime? date = year switch
            {
                2020 => new DateTime(2020, 6, 5),
                2021 => new DateTime(2021, 5, 26),
                2022 => new DateTime(2022, 6, 14),
                2023 => new DateTime(2023, 6, 4),
                2024 => new DateTime(2024, 5, 23),
                2025 => new DateTime(2025, 6, 11),
                2026 => new DateTime(2026, 5, 31),
                2027 => new DateTime(2027, 5, 20),
                _ => null,
            };

            if (date is null)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "BUDDHADAY-01",
                Date = date.Value,
                EnglishName = "Buddha Day",
                LocalName = "Бурхан багшийн Их дүйчин өдөр",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification? ChinggisKhaansBirthday(int year)
        {
            // 1st day of the first winter month of the Mongolian lunar calendar, public holiday since 2012 (2027 provisional)
            DateTime? date = year switch
            {
                2020 => new DateTime(2020, 11, 16),
                2021 => new DateTime(2021, 11, 5),
                2022 => new DateTime(2022, 11, 24),
                2023 => new DateTime(2023, 11, 14),
                2024 => new DateTime(2024, 11, 2),
                2025 => new DateTime(2025, 11, 21),
                2026 => new DateTime(2026, 11, 10),
                2027 => new DateTime(2027, 11, 29),
                _ => null,
            };

            if (date is null)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "CHINGGISKHAANSBIRTHDAY-01",
                Date = date.Value,
                EnglishName = "Chinggis Khaan's Birthday",
                LocalName = "Их эзэн Чингис хааны өдөр",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Mongolia",
                "https://investmongolia.gov.mn/mongolia-at-a-glance/",
                "https://investmongolia.gov.mn/wp-content/uploads/2023/11/GUIDEBOOK-2023.pdf", //2023 - Table 3. Public holidays list
                "https://drive.google.com/file/d/14hhcIKLc7EUAnKWu5l8BJY4ixQjRB4z1/view", //2024 - Table 3. Public holidays list
                "https://drive.google.com/file/d/1obQHCJz5xF_TJmJHF9ggxSpV0buAcKzv/view", //2025 - Table 3. Public holidays
                "https://investmongolia.gov.mn/investor-guide/", //Investor Guide - PDF Files
            ];
        }
    }
}

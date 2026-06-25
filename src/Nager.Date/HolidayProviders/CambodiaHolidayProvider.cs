using Nager.Date.Extensions;
using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Cambodia HolidayProvider
    /// </summary>
    internal sealed class CambodiaHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Cambodia HolidayProvider
        /// </summary>
        public CambodiaHolidayProvider() : base(CountryCode.KH)
        {
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
                    LocalName = "ទិវាបុណ្យចូលឆ្នាំសកល",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "VICTORYDAY-01",
                    Date = new DateTime(year, 1, 7),
                    EnglishName = "Victory over Genocide Day",
                    LocalName = "ទិវាជ័យជម្នះលើរបបប្រល័យពូជសាសន៍",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "WOMENDAY-01",
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "International Women's Day",
                    LocalName = "ទិវានារីអន្តរជាតិ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "ទិវាពលកម្មអន្តរជាតិ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "KINGBIRTHDAY-01",
                    Date = new DateTime(year, 5, 14),
                    EnglishName = "King Sihamoni's Birthday",
                    LocalName = "ព្រះរាជពិធីបុណ្យចម្រើនព្រះជន្ម ព្រះករុណា នរោត្តម សីហមុនី",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "QUEENMOTHERBIRTHDAY-01",
                    Date = new DateTime(year, 6, 18),
                    EnglishName = "Queen Mother's Birthday",
                    LocalName = "ព្រះរាជពិធីបុណ្យចម្រើនព្រះជន្ម សម្តេចព្រះមហាក្សត្រី នរោត្តម មុនិនាថ សីហនុ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "CONSTITUTIONDAY-01",
                    Date = new DateTime(year, 9, 24),
                    EnglishName = "Constitution Day",
                    LocalName = "ទិវាប្រកាសរដ្ឋធម្មនុញ្ញ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "KINGFATHERMOURNINGDAY-01",
                    Date = new DateTime(year, 10, 15),
                    EnglishName = "Commemoration Day of the King's Father",
                    LocalName = "ព្រះរាជពិធីគោរពព្រះវិញ្ញាណក្ខន្ធព្រះករុណាព្រះបាទសម្ដេចព្រះ នរោត្ដម សីហនុ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "KINGCORONATIONDAY-01",
                    Date = new DateTime(year, 10, 29),
                    EnglishName = "Coronation Day of King Sihamoni",
                    LocalName = "ព្រះរាជពិធីគ្រងព្រះបរមរាជសម្បត្តិរបស់ព្រះករុណាព្រះបាទសម្ដេចព្រះបរមនាថ នរោត្ដម សីហមុនី",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "NATIONALINDEPENDENCEDAY-01",
                    Date = new DateTime(year, 11, 9),
                    EnglishName = "National Independence Day",
                    LocalName = "ទិវាបុណ្យឯករាជ្យជាតិ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "PEACEDAY-01",
                    Date = new DateTime(year, 12, 29),
                    EnglishName = "Cambodia Peace Day",
                    LocalName = "ទិវាសន្តិភាពនៅកម្ពុជា",
                    HolidayTypes = HolidayTypes.Public
                }
            };

            holidaySpecifications.AddRangeIfNotNull(this.WaterFestival(year));
            holidaySpecifications.AddRangeIfNotNull(this.PchumBen(year));
            holidaySpecifications.AddRangeIfNotNull(this.KhmerNewYear(year));
            holidaySpecifications.AddIfNotNull(this.RoyalPloughing(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? RoyalPloughing(int year)
        {
            var date = year switch
            {
                2024 => new DateTime(2024, 5, 26),
                2025 => new DateTime(2025, 5, 15),
                2026 => new DateTime(2026, 5, 5),
                2027 => new DateTime(2027, 5, 24),
                2028 => new DateTime(2028, 5, 12),
                2029 => new DateTime(2029, 5, 1),
                2030 => new DateTime(2030, 5, 20),
                2031 => new DateTime(2031, 5, 10),
                2032 => new DateTime(2032, 5, 28),
                2033 => new DateTime(2033, 5, 17),
                2034 => new DateTime(2034, 5, 6),
                2035 => new DateTime(2035, 5, 25),
                _ => DateTime.MinValue
            };

            if (date == DateTime.MinValue)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "ROYALPLOUGHINGDAY-01",
                Date = date,
                EnglishName = "Royal Ploughing Ceremony",
                LocalName = "ព្រះរាជពិធីច្រត់ព្រះនង្គ័ល",
                HolidayTypes = HolidayTypes.Public
            };
        }

        private HolidaySpecification[] KhmerNewYear(int year)
        {
            var firstDate = year switch
            {
                2024 => new DateTime(2024, 4, 14),
                2025 => new DateTime(2025, 4, 14),
                2026 => new DateTime(2026, 4, 14),
                2027 => new DateTime(2027, 4, 14),
                2028 => new DateTime(2028, 4, 13),
                2029 => new DateTime(2029, 4, 14),
                2030 => new DateTime(2030, 4, 14),
                2031 => new DateTime(2031, 4, 14),
                2032 => new DateTime(2032, 4, 14),
                2033 => new DateTime(2033, 4, 14),
                2034 => new DateTime(2034, 4, 14),
                2035 => new DateTime(2035, 4, 14),
                _ => DateTime.MinValue
            };

            if (firstDate == DateTime.MinValue)
            {
                return [];
            }

            return
            [
                new HolidaySpecification
                {
                    Id = "KHMERNEWYEARDAY-01",
                    Date = firstDate,
                    EnglishName = "Khmer New Year",
                    LocalName = "ពិធីបុណ្យចូលឆ្នាំថ្មី ប្រពៃណីជាតិ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "KHMERNEWYEARDAY-02",
                    Date = firstDate.AddDays(1),
                    EnglishName = "Khmer New Year",
                    LocalName = "ពិធីបុណ្យចូលឆ្នាំថ្មី ប្រពៃណីជាតិ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "KHMERNEWYEARDAY-03",
                    Date = firstDate.AddDays(2),
                    EnglishName = "Khmer New Year",
                    LocalName = "ពិធីបុណ្យចូលឆ្នាំថ្មី ប្រពៃណីជាតិ",
                    HolidayTypes = HolidayTypes.Public
                }
            ];
        }

        private HolidaySpecification[] PchumBen(int year)
        {
            var firstDate = year switch
            {
                2024 => new DateTime(2024, 10, 1),
                2025 => new DateTime(2025, 9, 21),
                2026 => new DateTime(2026, 10, 10),
                2027 => new DateTime(2027, 9, 29),
                2028 => new DateTime(2028, 9, 17),
                2029 => new DateTime(2029, 10, 6),
                2030 => new DateTime(2030, 9, 26),
                2031 => new DateTime(2031, 10, 15),
                2032 => new DateTime(2032, 10, 3),
                2033 => new DateTime(2033, 9, 22),
                2034 => new DateTime(2034, 10, 11),
                2035 => new DateTime(2035, 10, 1),
                _ => DateTime.MinValue
            };

            if (firstDate == DateTime.MinValue)
            {
                return [];
            }

            return
            [
                new HolidaySpecification
                {
                    Id = "PCHUMBENDAY-01",
                    Date = firstDate,
                    EnglishName = "Pchum Ben",
                    LocalName = "ពិធីបុណ្យភ្ផុំបិណ្ឌ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "PCHUMBENDAY-02",
                    Date = firstDate.AddDays(1),
                    EnglishName = "Pchum Ben",
                    LocalName = "ពិធីបុណ្យភ្ផុំបិណ្ឌ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "PCHUMBENDAY-03",
                    Date = firstDate.AddDays(2),
                    EnglishName = "Pchum Ben",
                    LocalName = "ពិធីបុណ្យភ្ផុំបិណ្ឌ",
                    HolidayTypes = HolidayTypes.Public
                }
            ];
        }

        private HolidaySpecification[] WaterFestival(int year)
        {
            var firstDate = year switch
            {
                2024 => new DateTime(2024, 11, 14),
                2025 => new DateTime(2025, 11, 4),
                2026 => new DateTime(2026, 11, 23),
                2027 => new DateTime(2027, 11, 12),
                2028 => new DateTime(2028, 10, 31),
                2029 => new DateTime(2029, 11, 19),
                2030 => new DateTime(2030, 11, 9),
                2031 => new DateTime(2031, 11, 28),
                2032 => new DateTime(2032, 11, 16),
                2033 => new DateTime(2033, 11, 5),
                2034 => new DateTime(2034, 11, 24),
                2035 => new DateTime(2035, 11, 14),
                _ => DateTime.MinValue
            };

            if (firstDate == DateTime.MinValue)
            {
                return [];
            }

            return
            [
                new HolidaySpecification
                {
                    Id = "WATERFESTIVALDAY-01",
                    Date = firstDate,
                    EnglishName = "Water Festival",
                    LocalName = "ពិធីបុណ្យអុំទូក បណ្ដែតប្រទីប អកអំបុក និងសំពះព្រះខែ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "WATERFESTIVALDAY-02",
                    Date = firstDate.AddDays(1),
                    EnglishName = "Water Festival",
                    LocalName = "ពិធីបុណ្យអុំទូក បណ្ដែតប្រទីប អកអំបុក និងសំពះព្រះខែ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "WATERFESTIVALDAY-03",
                    Date = firstDate.AddDays(2),
                    EnglishName = "Water Festival",
                    LocalName = "ពិធីបុណ្យអុំទូក បណ្ដែតប្រទីប អកអំបុក និងសំពះព្រះខែ",
                    HolidayTypes = HolidayTypes.Public
                }
            ];
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Cambodia"
            ];
        }
    }
}

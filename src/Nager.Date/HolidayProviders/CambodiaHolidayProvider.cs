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
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "VICTORYDAY-01",
                    Date = new DateTime(year, 1, 7),
                    EnglishName = "Victory over Genocide Day",
                    LocalName = "ទិវាជ័យជម្នះលើរបបប្រល័យពូជសាសន៍",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "WOMENDAY-01",
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "International Women's Day",
                    LocalName = "ទិវានារីអន្តរជាតិ",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "ទិវាពលកម្មអន្តរជាតិ",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "KINGBIRTHDAY-01",
                    Date = new DateTime(year, 5, 14),
                    EnglishName = "King Sihamoni's Birthday",
                    LocalName = "ព្រះរាជពិធីបុណ្យចម្រើនព្រះជន្ម ព្រះករុណា នរោត្តម សីហមុនី",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "QUEENMOTHERBIRTHDAY-01",
                    Date = new DateTime(year, 6, 18),
                    EnglishName = "Queen Mother's Birthday",
                    LocalName = "ព្រះរាជពិធីបុណ្យចម្រើនព្រះជន្ម សម្តេចព្រះមហាក្សត្រី នរោត្តម មុនិនាថ សីហនុ",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CONSTITUTIONDAY-01",
                    Date = new DateTime(year, 9, 24),
                    EnglishName = "Constitution Day",
                    LocalName = "ទិវាប្រកាសរដ្ឋធម្មនុញ្ញ",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "KINGFATHERMOURNINGDAY-01",
                    Date = new DateTime(year, 10, 15),
                    EnglishName = "Commemoration Day of the King's Father",
                    LocalName = "ព្រះរាជពិធីគោរពព្រះវិញ្ញាណក្ខន្ធព្រះករុណាព្រះបាទសម្ដេចព្រះ នរោត្ដម សីហនុ",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "KINGCORONATIONDAY-01",
                    Date = new DateTime(year, 10, 29),
                    EnglishName = "Coronation Day of King Sihamoni",
                    LocalName = "ព្រះរាជពិធីគ្រងព្រះបរមរាជសម្បត្តិរបស់ព្រះករុណាព្រះបាទសម្ដេចព្រះបរមនាថ នរោត្ដម សីហមុនី",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NATIONALINDEPENDENCEDAY-01",
                    Date = new DateTime(year, 11, 9),
                    EnglishName = "National Independence Day",
                    LocalName = "ទិវាបុណ្យឯករាជ្យជាតិ",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "PEACEDAY-01",
                    Date = new DateTime(year, 12, 29),
                    EnglishName = "Cambodia Peace Day",
                    LocalName = "ទិវាសន្តិភាពនៅកម្ពុជា",
                    HolidayTypes = HolidayTypes.Public,
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
                2000 => new DateTime(2000, 5, 21),
                2001 => new DateTime(2001, 5, 11),
                2002 => new DateTime(2002, 4, 30),
                2003 => new DateTime(2003, 5, 19),
                2004 => new DateTime(2004, 5, 7),
                2005 => new DateTime(2005, 5, 26),
                2006 => new DateTime(2006, 5, 16),
                2007 => new DateTime(2007, 5, 5),
                2008 => new DateTime(2008, 5, 23),
                2009 => new DateTime(2009, 5, 12),
                2010 => new DateTime(2010, 5, 2),
                2011 => new DateTime(2011, 5, 21),
                2012 => new DateTime(2012, 5, 9),
                2013 => new DateTime(2013, 5, 28),
                2014 => new DateTime(2014, 5, 17),
                2015 => new DateTime(2015, 5, 6),
                2016 => new DateTime(2016, 5, 24),
                2017 => new DateTime(2017, 5, 14),
                2018 => new DateTime(2018, 5, 3),
                2019 => new DateTime(2019, 5, 22),
                2020 => new DateTime(2020, 5, 10),
                2021 => new DateTime(2021, 4, 30),
                2022 => new DateTime(2022, 5, 19),
                2023 => new DateTime(2023, 5, 8),
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
                2036 => new DateTime(2036, 5, 14),
                2037 => new DateTime(2037, 5, 3),
                2038 => new DateTime(2038, 5, 22),
                2039 => new DateTime(2039, 5, 11),
                2040 => new DateTime(2040, 4, 29),
                2041 => new DateTime(2041, 5, 18),
                2042 => new DateTime(2042, 5, 8),
                2043 => new DateTime(2043, 5, 27),
                2044 => new DateTime(2044, 5, 15),
                2045 => new DateTime(2045, 5, 4),
                2046 => new DateTime(2046, 5, 23),
                2047 => new DateTime(2047, 5, 13),
                2048 => new DateTime(2048, 5, 1),
                2049 => new DateTime(2049, 5, 20),
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
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification[] KhmerNewYear(int year)
        {
            var firstDate = year switch
            {
                2028 => new DateTime(2028, 4, 13),
                >= 2000 and <= 2049 => new DateTime(year, 4, 14),
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
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "KHMERNEWYEARDAY-02",
                    Date = firstDate.AddDays(1),
                    EnglishName = "Khmer New Year",
                    LocalName = "ពិធីបុណ្យចូលឆ្នាំថ្មី ប្រពៃណីជាតិ",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "KHMERNEWYEARDAY-03",
                    Date = firstDate.AddDays(2),
                    EnglishName = "Khmer New Year",
                    LocalName = "ពិធីបុណ្យចូលឆ្នាំថ្មី ប្រពៃណីជាតិ",
                    HolidayTypes = HolidayTypes.Public,
                }
            ];
        }

        private HolidaySpecification[] PchumBen(int year)
        {
            var firstDate = year switch
            {
                2000 => new DateTime(2000, 9, 27),
                2001 => new DateTime(2001, 9, 16),
                2002 => new DateTime(2002, 10, 5),
                2003 => new DateTime(2003, 9, 24),
                2004 => new DateTime(2004, 10, 12),
                2005 => new DateTime(2005, 10, 2),
                2006 => new DateTime(2006, 9, 21),
                2007 => new DateTime(2007, 10, 10),
                2008 => new DateTime(2008, 9, 28),
                2009 => new DateTime(2009, 9, 18),
                2010 => new DateTime(2010, 10, 7),
                2011 => new DateTime(2011, 9, 26),
                2012 => new DateTime(2012, 10, 14),
                2013 => new DateTime(2013, 10, 3),
                2014 => new DateTime(2014, 9, 22),
                2015 => new DateTime(2015, 10, 11),
                2016 => new DateTime(2016, 9, 30),
                2017 => new DateTime(2017, 9, 19),
                2018 => new DateTime(2018, 10, 8),
                2019 => new DateTime(2019, 9, 27),
                2020 => new DateTime(2020, 9, 16),
                2021 => new DateTime(2021, 10, 5),
                2022 => new DateTime(2022, 9, 24),
                2023 => new DateTime(2023, 10, 13),
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
                2036 => new DateTime(2036, 9, 19),
                2037 => new DateTime(2037, 10, 8),
                2038 => new DateTime(2038, 9, 27),
                2039 => new DateTime(2039, 9, 16),
                2040 => new DateTime(2040, 10, 4),
                2041 => new DateTime(2041, 9, 24),
                2042 => new DateTime(2042, 10, 13),
                2043 => new DateTime(2043, 10, 2),
                2044 => new DateTime(2044, 9, 20),
                2045 => new DateTime(2045, 10, 9),
                2046 => new DateTime(2046, 9, 29),
                2047 => new DateTime(2047, 9, 18),
                2048 => new DateTime(2048, 10, 6),
                2049 => new DateTime(2049, 9, 25),
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
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "PCHUMBENDAY-02",
                    Date = firstDate.AddDays(1),
                    EnglishName = "Pchum Ben",
                    LocalName = "ពិធីបុណ្យភ្ផុំបិណ្ឌ",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "PCHUMBENDAY-03",
                    Date = firstDate.AddDays(2),
                    EnglishName = "Pchum Ben",
                    LocalName = "ពិធីបុណ្យភ្ផុំបិណ្ឌ",
                    HolidayTypes = HolidayTypes.Public,
                }
            ];
        }

        private HolidaySpecification[] WaterFestival(int year)
        {
            var firstDate = year switch
            {
                2000 => new DateTime(2000, 11, 10),
                2001 => new DateTime(2001, 10, 30),
                2002 => new DateTime(2002, 11, 18),
                2003 => new DateTime(2003, 11, 7),
                2004 => new DateTime(2004, 11, 25),
                2005 => new DateTime(2005, 11, 15),
                2006 => new DateTime(2006, 11, 4),
                2007 => new DateTime(2007, 11, 23),
                2008 => new DateTime(2008, 11, 11),
                2009 => new DateTime(2009, 11, 1),
                2010 => new DateTime(2010, 11, 20),
                2011 => new DateTime(2011, 11, 9),
                2012 => new DateTime(2012, 11, 27),
                2013 => new DateTime(2013, 11, 16),
                2014 => new DateTime(2014, 11, 5),
                2015 => new DateTime(2015, 11, 24),
                2016 => new DateTime(2016, 11, 13),
                2017 => new DateTime(2017, 11, 2),
                2018 => new DateTime(2018, 11, 21),
                2019 => new DateTime(2019, 11, 10),
                2020 => new DateTime(2020, 10, 30),
                2021 => new DateTime(2021, 11, 18),
                2022 => new DateTime(2022, 11, 7),
                2023 => new DateTime(2023, 11, 26),
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
                2036 => new DateTime(2036, 11, 2),
                2037 => new DateTime(2037, 11, 21),
                2038 => new DateTime(2038, 11, 10),
                2039 => new DateTime(2039, 10, 30),
                2040 => new DateTime(2040, 11, 17),
                2041 => new DateTime(2041, 11, 7),
                2042 => new DateTime(2042, 11, 26),
                2043 => new DateTime(2043, 11, 15),
                2044 => new DateTime(2044, 11, 3),
                2045 => new DateTime(2045, 11, 22),
                2046 => new DateTime(2046, 11, 12),
                2047 => new DateTime(2047, 11, 1),
                2048 => new DateTime(2048, 11, 19),
                2049 => new DateTime(2049, 11, 8),
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
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "WATERFESTIVALDAY-02",
                    Date = firstDate.AddDays(1),
                    EnglishName = "Water Festival",
                    LocalName = "ពិធីបុណ្យអុំទូក បណ្ដែតប្រទីប អកអំបុក និងសំពះព្រះខែ",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "WATERFESTIVALDAY-03",
                    Date = firstDate.AddDays(2),
                    EnglishName = "Water Festival",
                    LocalName = "ពិធីបុណ្យអុំទូក បណ្ដែតប្រទីប អកអំបុក និងសំពះព្រះខែ",
                    HolidayTypes = HolidayTypes.Public,
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

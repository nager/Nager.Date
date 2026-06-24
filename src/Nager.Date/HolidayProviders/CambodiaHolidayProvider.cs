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
                    Id = "KHMERNEWYEARDAY-01",
                    Date = new DateTime(year, 4, 14),
                    EnglishName = "Khmer New Year",
                    LocalName = "ពិធីបុណ្យចូលឆ្នាំថ្មី ប្រពៃណីជាតិ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "KHMERNEWYEARDAY-02",
                    Date = new DateTime(year, 4, 15),
                    EnglishName = "Khmer New Year",
                    LocalName = "ពិធីបុណ្យចូលឆ្នាំថ្មី ប្រពៃណីជាតិ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "KHMERNEWYEARDAY-03",
                    Date = new DateTime(year, 4, 16),
                    EnglishName = "Khmer New Year",
                    LocalName = "ពិធីបុណ្យចូលឆ្នាំថ្មី ប្រពៃណីជាតិ",
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
                    Id = "ROYALPLOUGHINGDAY-01",
                    Date = new DateTime(year, 5, 5),
                    EnglishName = "Royal Ploughing Ceremony",
                    LocalName = "ព្រះរាជពិធីច្រត់ព្រះនង្គ័ល",
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
                    Id = "PCHUMBENDAY-01",
                    Date = new DateTime(year, 10, 10),
                    EnglishName = "Pchum Ben",
                    LocalName = "ពិធីបុណ្យភ្ផុំបិណ្ឌ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "PCHUMBENDAY-02",
                    Date = new DateTime(year, 10, 11),
                    EnglishName = "Pchum Ben",
                    LocalName = "ពិធីបុណ្យភ្ផុំបិណ្ឌ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "PCHUMBENDAY-03",
                    Date = new DateTime(year, 10, 12),
                    EnglishName = "Pchum Ben",
                    LocalName = "ពិធីបុណ្យភ្ផុំបិណ្ឌ",
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
                    Id = "WATERFESTIVALDAY-01",
                    Date = new DateTime(year, 11, 23),
                    EnglishName = "Water Festival",
                    LocalName = "ពិធីបុណ្យអុំទូក បណ្ដែតប្រទីប អកអំបុក និងសំពះព្រះខែ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "WATERFESTIVALDAY-02",
                    Date = new DateTime(year, 11, 24),
                    EnglishName = "Water Festival",
                    LocalName = "ពិធីបុណ្យអុំទូក បណ្ដែតប្រទីប អកអំបុក និងសំពះព្រះខែ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "WATERFESTIVALDAY-03",
                    Date = new DateTime(year, 11, 25),
                    EnglishName = "Water Festival",
                    LocalName = "ពិធីបុណ្យអុំទូក បណ្ដែតប្រទីប អកអំបុក និងសំពះព្រះខែ",
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

            return holidaySpecifications;
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

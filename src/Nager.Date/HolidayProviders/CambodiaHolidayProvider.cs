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
                    LocalName = "ទិវាចូលឆ្នាំសាកល",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "VICTORYDAY-01",
                    Date = new DateTime(year, 1, 7),
                    EnglishName = "Day of Victory over the Genocidal Regime",
                    LocalName = "	ទិវាជ័យជម្នះលើរបបប្រល័យពូជសាសន៍",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "WOMENDAY-01",
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "International Women's Rights Day",
                    LocalName = "ទិវាអន្តរជាតិនារី",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "KHMERNEWYEARDAY-01",
                    Date = new DateTime(year, 4, 14),
                    EnglishName = "Khmer New Year",
                    LocalName = "ពិធីបុណ្យចូលឆ្នាំថ្មីប្រពៃណីជាតិ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "KHMERNEWYEARDAY-02",
                    Date = new DateTime(year, 4, 15),
                    EnglishName = "Khmer New Year",
                    LocalName = "ពិធីបុណ្យចូលឆ្នាំថ្មីប្រពៃណីជាតិ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "KHMERNEWYEARDAY-03",
                    Date = new DateTime(year, 4, 16),
                    EnglishName = "Khmer New Year",
                    LocalName = "ពិធីបុណ្យចូលឆ្នាំថ្មីប្រពៃណីជាតិ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "International Labour Day",
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
                    Id = "BIRTHDAYHISMAJESTYDAY-01",
                    Date = new DateTime(year, 5, 14),
                    EnglishName = "Birthday of His Majesty Preah Bat Samdech Preah Boromneath NORODOM SIHAMONI, King of Cambodia",
                    LocalName = "ព្រះរាជពិធីបុណ្យចម្រើនព្រះជន្ម ព្រះករុណា ព្រះបាទសម្តេចព្រះបរមនាថ នរោត្តម សីហមុនី",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "KINGBIRTHDAY-01",
                    Date = new DateTime(year, 5, 14),
                    EnglishName = "Birthday of His Majesty Preah Bat Samdech Preah Boromneath NORODOM SIHAMONI, King of Cambodia",
                    LocalName = "ព្រះរាជពិធីបុណ្យចម្រើនព្រះជន្ម ព្រះករុណា ព្រះបាទសម្តេចព្រះបរមនាថ នរោត្តម សីហមុនី",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "QUEENMOTHERBIRTHDAY-01",
                    Date = new DateTime(year, 6, 18),
                    EnglishName = "Birthday of Her Majesty the Queen-Mother NORODOM MONINEATH SIHANOUK of Cambodia",
                    LocalName = "ព្រះរាជពិធីបុណ្យចម្រើនព្រះជន្ម សម្តេចព្រះមហាក្សត្រី ព្រះវររាជមាតា នរោត្តម មុនិនាថ សីហនុ",
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
                    EnglishName = "Pchum Ben Day",
                    LocalName = "ពិធីបុណ្យភ្ផុំបិណ្ឌ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "PCHUMBENDAY-02",
                    Date = new DateTime(year, 10, 11),
                    EnglishName = "Pchum Ben Day",
                    LocalName = "ពិធីបុណ្យភ្ផុំបិណ្ឌ",
                    HolidayTypes = HolidayTypes.Public
                },new HolidaySpecification
                {
                    Id = "PCHUMBENDAY-03",
                    Date = new DateTime(year, 10, 12),
                    EnglishName = "Pchum Ben Day",
                    LocalName = "ពិធីបុណ្យភ្ផុំបិណ្ឌ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "KINGFATHERMOURNINGDAY-01",
                    Date = new DateTime(year, 10, 15),
                    EnglishName = "Mourning Day of the Late King-Father NORODOM SIHANOUK of Cambodia",
                    LocalName = "ទិវាប្រារព្ឋពិធីគោរពព្រះវិញ្ញាណក្ខន្ឋ ព្រះករុណា ព្រះបាទសម្តេចព្រះ នរោត្តម សីហនុ ព្រះមហាវីរក្សត្រ ព្រះវររាជបិតាឯករាជ្យ បូរណភាពទឹកដី និងឯកភាពជាតិខ្មែរ ព្រះបរមរតនកោដ្ឋ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "KINGCORONATIONDAY-01",
                    Date = new DateTime(year, 10, 29),
                    EnglishName = "Coronation Day of His Majesty Preah Bat Samdech Preah Boromneath NORODOM SIHAMONI, King of Cambodia",
                    LocalName = "ព្រះរាជពិធីគ្រងព្រះបរមរាជសម្បត្តិ របស់ ព្រះករុណា ព្រះបាទសម្តេចព្រះបរមនាថ នរោត្តម សីហមុនី ព្រះមហាក្សត្រនៃព្រះរាជាណាចក្រកម្ពុជា",
                    HolidayTypes = HolidayTypes.Public
                }
                new HolidaySpecification
                {
                    Id = "NATIONALINDEPENDENCEDAY-01",
                    Date = new DateTime(year, 11, 9),
                    EnglishName = "National Independence Day",
                    LocalName = "ពិធីបុណ្យឯករាជ្យជាតិ",
                    HolidayTypes = HolidayTypes.Public
                }
                new HolidaySpecification
                {
                    Id = "WATERFESTIVALDAY-01",
                    Date = new DateTime(year, 10, 10),
                    EnglishName = "Water Festival",
                    LocalName = "ព្រះរាជពិធីបុណ្យអុំទូក បណ្តែតប្រទីប និងសំពះព្រះខែអកអំបុក",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "WATERFESTIVALDAY-02",
                    Date = new DateTime(year, 10, 11),
                    EnglishName = "Water Festival",
                    LocalName = "ព្រះរាជពិធីបុណ្យអុំទូក បណ្តែតប្រទីប និងសំពះព្រះខែអកអំបុក",
                    HolidayTypes = HolidayTypes.Public
                },new HolidaySpecification
                {
                    Id = "WATERFESTIVALDAY-03",
                    Date = new DateTime(year, 10, 12),
                    EnglishName = "Water Festival",
                    LocalName = "ព្រះរាជពិធីបុណ្យអុំទូក បណ្តែតប្រទីប និងសំពះព្រះខែអកអំបុក",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "PEACEDAY-01",
                    Date = new DateTime(year, 12, 29),
                    EnglishName = "Peace Day in Cambodia",
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
                "https://www.nbc.gov.kh/english/news_and_events/official_holiday.php"
            ];
        }
    }
}
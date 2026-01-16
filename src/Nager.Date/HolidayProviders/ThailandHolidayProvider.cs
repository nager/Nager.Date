using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Thailand HolidayProvider
    /// </summary>
    internal sealed class ThailandHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Thailand HolidayProvider
        /// </summary>
        public ThailandHolidayProvider() : base(CountryCode.TH)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            //INFO: Some Thai holidays follow the lunar calendar and vary each year:
            //- Makha Bucha Day (Feb/Mar)
            //- Visakha Bucha Day (May/Jun)
            //- Asahna Bucha Day (Jul/Aug)
            //- Royal Ploughing Ceremony (May)

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "วันขึ้นปีใหม่",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "CHAKRIDAY-01",
                    Date = new DateTime(year, 4, 6),
                    EnglishName = "Chakri Memorial Day",
                    LocalName = "วันจักรี",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "SONGKRAN-01",
                    Date = new DateTime(year, 4, 13),
                    EnglishName = "Songkran Festival",
                    LocalName = "วันสงกรานต์",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "SONGKRAN-02",
                    Date = new DateTime(year, 4, 14),
                    EnglishName = "Songkran Festival",
                    LocalName = "วันสงกรานต์",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "SONGKRAN-03",
                    Date = new DateTime(year, 4, 15),
                    EnglishName = "Songkran Festival",
                    LocalName = "วันสงกรานต์",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "National Labour Day",
                    LocalName = "วันแรงงานแห่งชาติ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "KINGSBIRTHDAY-01",
                    Date = new DateTime(year, 7, 28),
                    EnglishName = "H.M. King Vajiralongkorn's Birthday",
                    LocalName = "วันเฉลิมพระชนมพรรษา รัชกาลที่ 10",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "QUEENMOTHERBIRTHDAY-01",
                    Date = new DateTime(year, 8, 12),
                    EnglishName = "H.M. Queen Mother's Birthday / Mother's Day",
                    LocalName = "วันแม่แห่งชาติ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "PRINCEMAHIDOLDAY-01",
                    Date = new DateTime(year, 9, 24),
                    EnglishName = "Prince Mahidol Day",
                    LocalName = "วันมหิดล",
                    HolidayTypes = HolidayTypes.Observance
                },
                new HolidaySpecification
                {
                    Id = "KINGBHUMIBOLDEATH-01",
                    Date = new DateTime(year, 10, 13),
                    EnglishName = "H.M. King Bhumibol Adulyadej Memorial Day",
                    LocalName = "วันคล้ายวันสวรรคต รัชกาลที่ 9",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "CHULALONGKORNDAY-01",
                    Date = new DateTime(year, 10, 23),
                    EnglishName = "H.M. King Chulalongkorn the Great Memorial Day",
                    LocalName = "วันปิยมหาราช",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "KINGBHUMIBOLBIRTHDAY-01",
                    Date = new DateTime(year, 12, 5),
                    EnglishName = "H.M. King Bhumibol Adulyadej's Birthday / Father's Day",
                    LocalName = "วันพ่อแห่งชาติ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "CONSTITUTIONDAY-01",
                    Date = new DateTime(year, 12, 10),
                    EnglishName = "Constitution Day",
                    LocalName = "วันรัฐธรรมนูญ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "NEWYEARSEVE-01",
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "New Year's Eve",
                    LocalName = "วันสิ้นปี",
                    HolidayTypes = HolidayTypes.Public
                }
            };

            holidaySpecifications.AddRange(this.GetCoronationDay(year));
            holidaySpecifications.AddRange(this.GetQueenSuthidaBirthday(year));

            return holidaySpecifications;
        }

        private HolidaySpecification[] GetCoronationDay(int year)
        {
            // Coronation Day was established in 2019 for King Vajiralongkorn
            if (year >= 2019)
            {
                return
                [
                    new HolidaySpecification
                    {
                        Id = "CORONATIONDAY-01",
                        Date = new DateTime(year, 5, 4),
                        EnglishName = "Coronation Day",
                        LocalName = "วันฉัตรมงคล",
                        HolidayTypes = HolidayTypes.Public
                    }
                ];
            }

            return [];
        }

        private HolidaySpecification[] GetQueenSuthidaBirthday(int year)
        {
            // Queen Suthida's Birthday became a public holiday in 2019
            if (year >= 2019)
            {
                return
                [
                    new HolidaySpecification
                    {
                        Id = "QUEENSUTHIDABIRTHDAY-01",
                        Date = new DateTime(year, 6, 3),
                        EnglishName = "H.M. Queen Suthida's Birthday",
                        LocalName = "วันเฉลิมพระชนมพรรษาสมเด็จพระนางเจ้าสุทิดา",
                        HolidayTypes = HolidayTypes.Public
                    }
                ];
            }

            return [];
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Thailand",
                "https://www.officeholidays.com/countries/thailand",
                "https://www.bot.or.th/en/financial-institutions-holiday.html",
            ];
        }
    }
}

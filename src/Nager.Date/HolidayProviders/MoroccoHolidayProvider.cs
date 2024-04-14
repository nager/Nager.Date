using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Morocco HolidayProvider
    /// </summary>
    internal sealed class MoroccoHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Morocco HolidayProvider
        /// </summary>
        public MoroccoHolidayProvider() : base(CountryCode.MA)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            //TODO:Islamic calendar
            //Muslim New Year (Fatih Muharram)
            //Birth of the Prophet Muhammad (Eid Al Mawled)
            //Eid ul-Fitr (Eid Sghir)
            //Eid ul-Adha (Eid Kbir)

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Ras l' âm",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 11),
                    EnglishName = "Proclamation of Independence",
                    LocalName = "Takdim watikat al-istiqlal",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Eid Ash-Shughl",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 30),
                    EnglishName = "Enthronement",
                    LocalName = "Eid Al-Ârch",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 14),
                    EnglishName = "Zikra Oued Ed-Dahab",
                    LocalName = "Oued Ed-Dahab Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 20),
                    EnglishName = "Revolution of the King and the People",
                    LocalName = "Thawrat al malik wa shâab",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 21),
                    EnglishName = "Youth Day",
                    LocalName = "Eid Al Chabab",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 6),
                    EnglishName = "Green March",
                    LocalName = "Eid Al Massira Al Khadra",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 18),
                    EnglishName = "Independence Day",
                    LocalName = "Eid Al Istiqulal",
                    HolidayTypes = HolidayTypes.Public
                }
            };

            if (year >= 2024)
            {
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 14),
                    EnglishName = "Amazigh New Year",
                    LocalName = "Id Yennayer",
                    HolidayTypes = HolidayTypes.Public
                });
            }

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Morocco"
            ];
        }
    }
}

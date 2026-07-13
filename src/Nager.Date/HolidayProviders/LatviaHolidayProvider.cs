using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Latvia HolidayProvider
    /// </summary>
    internal sealed class LatviaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Latvia HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public LatviaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.LV)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var secondSundayInMay = DateHelper.FindDay(year, Month.May, DayOfWeek.Sunday, Occurrence.Second);

            var mondayObservedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(1)
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Jaungada diena",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Darba svētki",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CONSTITUTIONALASSEMBLYDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Day of the Convocation of the Constitutional Assembly of the Republic of Latvia",
                    LocalName = "Latvijas Republikas Satversmes sapulces sasaukšanas diena",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "RESTORATIONOFINDEPENDENCE-01",
                    Date = new DateTime(year, 5, 4),
                    EnglishName = "Day of the Restoration of Independence of the Republic of Latvia",
                    LocalName = "Latvijas Republikas Neatkarības atjaunošanas diena",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = mondayObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "MOTHERSDAY-01",
                    Date = secondSundayInMay,
                    EnglishName = "Mother's Day",
                    LocalName = "Mātes diena",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "MIDSUMMEREVE-01",
                    Date = new DateTime(year, 6, 23),
                    EnglishName = "Līgo Day",
                    LocalName = "Līgo diena",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "MIDSUMMERDAY-01",
                    Date = new DateTime(year, 6, 24),
                    EnglishName = "Jāņi Day", //St. John's Day
                    LocalName = "Jāņu diena",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "PROCLAMATIONDAY-01",
                    Date = new DateTime(year, 11, 18),
                    EnglishName = "Day of the Proclamation of the Republic of Latvia",
                    LocalName = "Latvijas Republikas Proklamēšanas diena",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = mondayObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASEVE-01",
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Ziemassvētku vakars",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Pirmie Ziemassvētki",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-02",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Second day of Christmas",
                    LocalName = "Otrie Ziemassvētki",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NEWYEARSEVE-01",
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "New Year's Eve",
                    LocalName = "Vecgada diena",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._catholicProvider.GoodFriday("Lielā Piektdiena", year),
                this._catholicProvider.EasterSunday("Pirmās Lieldienas", year),
                this._catholicProvider.EasterMonday("Otrās Lieldienas", year),
                this._catholicProvider.Pentecost("Vasarsvētki", year),
            };

            holidaySpecifications.AddIfNotNull(this.SongAndDanceCelebrationFinalDay(year, mondayObservedRuleSet));
            holidaySpecifications.AddIfNotNull(this.PopeFrancisPastoralVisitDay(year));
            holidaySpecifications.AddIfNotNull(this.IceHockeyBronzeMedalDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? SongAndDanceCelebrationFinalDay(int year, ObservedRuleSet observedRuleSet)
        {
            //The final day of the Nationwide Latvian Song and Dance Celebration, held every five years,
            //is a public holiday (in the law since 22.10.2014), the date is fixed per event by a Cabinet order
            DateTime? finalDay = year switch
            {
                2018 => new DateTime(2018, 7, 8),
                2023 => new DateTime(2023, 7, 9),
                2028 => new DateTime(2028, 7, 9),
                _ => null
            };

            if (finalDay is null)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "SONGANDDANCECELEBRATION-01",
                Date = finalDay.Value,
                EnglishName = "Final Day of the Nationwide Latvian Song and Dance Celebration",
                LocalName = "Vispārējo latviešu Dziesmu un deju svētku noslēguma diena",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet,
            };
        }

        private HolidaySpecification? PopeFrancisPastoralVisitDay(int year)
        {
            if (year is not 2018)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "POPEFRANCISVISIT-01",
                Date = new DateTime(2018, 9, 24),
                EnglishName = "Day of the Pastoral Visit of His Holiness Pope Francis to Latvia",
                LocalName = "Viņa Svētības pāvesta Franciska pastorālās vizītes Latvijā diena",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification? IceHockeyBronzeMedalDay(int year)
        {
            if (year is not 2023)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "ICEHOCKEYBRONZEMEDAL-01",
                Date = new DateTime(2023, 5, 29),
                EnglishName = "Day of the Latvian Ice Hockey Team's Bronze Medal Win at the 2023 IIHF World Championship",
                LocalName = "Diena, kad Latvijas hokeja komanda ieguva bronzas medaļu 2023. gada Pasaules hokeja čempionātā",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Latvia",
                "https://likumi.lv/doc.php?id=72608",
                "https://likumi.lv/ta/en/en/id/72608-on-public-holidays-commemoration-days-and-celebration-days"
            ];
        }
    }
}

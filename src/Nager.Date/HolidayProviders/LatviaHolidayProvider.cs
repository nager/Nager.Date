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

        private IEnumerable<HolidaySpecification> CommemorationAndCelebrationDays(int year)
        {
            var thirdSundayInJune = DateHelper.FindDay(year, Month.June, DayOfWeek.Sunday, Occurrence.Third);
            var secondSaturdayInJuly = DateHelper.FindDay(year, Month.July, DayOfWeek.Saturday, Occurrence.Second);
            var secondSundayInSeptember = DateHelper.FindDay(year, Month.September, DayOfWeek.Sunday, Occurrence.Second);
            var firstSundayInDecember = DateHelper.FindDay(year, Month.December, DayOfWeek.Sunday, Occurrence.First);

            //Teachers' Day was moved from the first Sunday of October to 5 October (amendment in force 07.05.2024)
            var teachersDay = year >= 2024
                ? new DateTime(year, 10, 5)
                : DateHelper.FindDay(year, Month.October, DayOfWeek.Sunday, Occurrence.First);

            var commemorationDays = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "BARRICADESDEFENDERS-01",
                    Date = new DateTime(year, 1, 20),
                    EnglishName = "Commemoration Day of Defenders of the Barricades in 1991",
                    LocalName = "1991. gada barikāžu aizstāvju atceres diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "DEJURERECOGNITION-01",
                    Date = new DateTime(year, 1, 26),
                    EnglishName = "Day of the International (de jure) Recognition of the Republic of Latvia",
                    LocalName = "Latvijas Republikas starptautiskās (de jure) atzīšanas diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "INTERNATIONALWOMENSDAY-01",
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "International Women's Day",
                    LocalName = "Starptautiskā sieviešu diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "COMMUNISTGENOCIDEVICTIMS-01",
                    Date = new DateTime(year, 3, 25),
                    EnglishName = "Commemoration Day of Victims of Communist Terror",
                    LocalName = "Komunistiskā genocīda upuru piemiņas diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "LATGALECONGRESS-01",
                    Date = new DateTime(year, 4, 27),
                    EnglishName = "Latgale Congress Day",
                    LocalName = "Latgales kongresa diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "NAZISMDEFEAT-01",
                    Date = new DateTime(year, 5, 8),
                    EnglishName = "Day of the Defeat of Nazism and Commemoration Day of Victims of World War II",
                    LocalName = "Nacisma sagrāves diena un Otrā pasaules kara upuru piemiņas diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "EUROPEDAY-01",
                    Date = new DateTime(year, 5, 9),
                    EnglishName = "Europe Day",
                    LocalName = "Eiropas diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "FAMILYDAY-01",
                    Date = new DateTime(year, 5, 15),
                    EnglishName = "International Day of the Family",
                    LocalName = "Starptautiskā ģimenes diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "FIREFIGHTERSDAY-01",
                    Date = new DateTime(year, 5, 17),
                    EnglishName = "Firefighter and Rescuer Day",
                    LocalName = "Ugunsdzēsēju un glābēju diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "CHILDRENSDAY-01",
                    Date = new DateTime(year, 6, 1),
                    EnglishName = "International Day for Protection of Children",
                    LocalName = "Starptautiskā bērnu aizsardzības diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "COMMUNISTGENOCIDEVICTIMS-02",
                    Date = new DateTime(year, 6, 14),
                    EnglishName = "Commemoration Day of Victims of Communist Terror",
                    LocalName = "Komunistiskā genocīda upuru piemiņas diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "OCCUPATIONDAY-01",
                    Date = new DateTime(year, 6, 17),
                    EnglishName = "Day of the Occupation of the Republic of Latvia",
                    LocalName = "Latvijas Republikas okupācijas diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "MEDICALWORKERSDAY-01",
                    Date = thirdSundayInJune,
                    EnglishName = "Medical Worker Day",
                    LocalName = "Medicīnas darbinieku diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "HEROESDAY-01",
                    Date = new DateTime(year, 6, 22),
                    EnglishName = "Heroes' Commemoration Day (Anniversary of the Battle of Cēsis)",
                    LocalName = "Varoņu piemiņas diena (Cēsu kaujas atceres diena)",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "JEWISHGENOCIDEVICTIMS-01",
                    Date = new DateTime(year, 7, 4),
                    EnglishName = "Commemoration Day of Genocide Against the Jews",
                    LocalName = "Ebreju tautas genocīda upuru piemiņas diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "SEAFESTIVAL-01",
                    Date = secondSaturdayInJuly,
                    EnglishName = "Day of the Sea Festival",
                    LocalName = "Jūras svētku diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "FREEDOMFIGHTERS-01",
                    Date = new DateTime(year, 8, 11),
                    EnglishName = "Latvian Freedom Fighters' Remembrance Day",
                    LocalName = "Latvijas brīvības cīnītāju piemiņas diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "CONSTITUTIONALLAW-01",
                    Date = new DateTime(year, 8, 21),
                    EnglishName = "Day of the Passing of the Constitutional Law on the Status of the Republic of Latvia as a State",
                    LocalName = "Konstitucionālā likuma “Par Latvijas Republikas valstisko statusu” pieņemšanas diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "STALINISMNAZISMVICTIMS-01",
                    Date = new DateTime(year, 8, 23),
                    EnglishName = "Day of Remembrance for Victims of Stalinism and Nazism",
                    LocalName = "Staļinisma un nacisma upuru atceres diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "KNOWLEDGEDAY-01",
                    Date = new DateTime(year, 9, 1),
                    EnglishName = "Knowledge Day",
                    LocalName = "Zinību diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "FATHERSDAY-01",
                    Date = secondSundayInSeptember,
                    EnglishName = "Father's Day",
                    LocalName = "Tēva diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "BALTICUNITYDAY-01",
                    Date = new DateTime(year, 9, 22),
                    EnglishName = "Baltic Unity Day",
                    LocalName = "Baltu vienības diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "SENIORSDAY-01",
                    Date = new DateTime(year, 10, 1),
                    EnglishName = "International Day of Older Persons",
                    LocalName = "Starptautiskā senioru diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "TEACHERSDAY-01",
                    Date = teachersDay,
                    EnglishName = "Teachers' Day",
                    LocalName = "Skolotāju diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "BORDERGUARDSDAY-01",
                    Date = new DateTime(year, 11, 7),
                    EnglishName = "Border Guards Day",
                    LocalName = "Robežsargu diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "LACPLESISDAY-01",
                    Date = new DateTime(year, 11, 11),
                    EnglishName = "Lāčplēsis Day",
                    LocalName = "Lāčplēša diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "POLICEDAY-01",
                    Date = new DateTime(year, 12, 5),
                    EnglishName = "Police Day",
                    LocalName = "Policijas darbinieku diena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "TOTALITARIANGENOCIDEVICTIMS-01",
                    Date = firstSundayInDecember,
                    EnglishName = "Commemoration Day of Victims of Genocide Against the Latvian People By the Totalitarian Communist Regime",
                    LocalName = "Pret latviešu tautu vērstā totalitārā komunistiskā režīma genocīda upuru piemiņas diena",
                    HolidayTypes = HolidayTypes.Observance,
                }
            };

            if (year >= 2021)
            {
                //Added by the amendment of 16.06.2021, in force from 03.07.2021
                commemorationDays.Add(new HolidaySpecification
                {
                    Id = "LANGUAGEDAY-01",
                    Date = new DateTime(year, 10, 15),
                    EnglishName = "Official Language Day",
                    LocalName = "Valsts valodas diena",
                    HolidayTypes = HolidayTypes.Observance,
                });

                commemorationDays.Add(new HolidaySpecification
                {
                    Id = "NOVEMBER21TRAGEDY-01",
                    Date = new DateTime(year, 11, 21),
                    EnglishName = "Remembrance Day of the Tragedy of 21 November 2013",
                    LocalName = "2013. gada 21. novembra traģēdijas atceres diena",
                    HolidayTypes = HolidayTypes.Observance,
                });
            }

            if (year >= 2022)
            {
                //Added by the amendment of 16.06.2021, in force from 03.07.2021 (after 2 March and 17 March 2021)
                commemorationDays.Add(new HolidaySpecification
                {
                    Id = "NATIONALPARTISANS-01",
                    Date = new DateTime(year, 3, 2),
                    EnglishName = "National Partisan Armed Resistance Remembrance Day",
                    LocalName = "Nacionālo partizānu bruņotās pretošanās atceres diena",
                    HolidayTypes = HolidayTypes.Observance,
                });

                commemorationDays.Add(new HolidaySpecification
                {
                    Id = "NATIONALRESISTANCEMOVEMENT-01",
                    Date = new DateTime(year, 3, 17),
                    EnglishName = "National Resistance Movement Remembrance Day",
                    LocalName = "Nacionālās pretošanās kustības piemiņas diena",
                    HolidayTypes = HolidayTypes.Observance,
                });
            }

            if (year >= 2026)
            {
                //Added by the amendment of 27.02.2025, in force from 18.03.2025 (after 27 February 2025)
                commemorationDays.Add(new HolidaySpecification
                {
                    Id = "WORLDNGODAY-01",
                    Date = new DateTime(year, 2, 27),
                    EnglishName = "World Non-Governmental Organization Day",
                    LocalName = "Starptautisko nevalstisko organizāciju diena",
                    HolidayTypes = HolidayTypes.Observance,
                });
            }

            return commemorationDays;
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

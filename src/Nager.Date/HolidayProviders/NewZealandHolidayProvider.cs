using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// New Zealand HolidayProvider
    /// </summary>
    internal class NewZealandHolidayProvider : IHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;
        private IDictionary<int, DateTime> _matariki;

        /// <summary>
        /// New Zealand HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public NewZealandHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
            this.InitMatariki();
        }

        /// <inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
        {
            return new Dictionary<string, string>
            {
                { "NZ-AUK", "Auckland" },
                { "NZ-BOP", "Bay of Plenty" },
                { "NZ-CAN", "Canterbury" },
                { "NZ-CIT", "Chatham Islands Territory" },
                { "NZ-GIS", "Gisborne" },
                { "NZ-HKB", "Hawke's Bay" },
                { "NZ-MBH", "Marlborough" },
                { "NZ-MWT", "Manawatu-Wanganui" },
                { "NZ-NSN", "Nelson" },
                { "NZ-NTL", "Northland" },
                { "NZ-OTA", "Otago" },
                { "NZ-STL", "Southland" },
                { "NZ-TAS", "Tasman" },
                { "NZ-TKI", "Taranaki" },
                { "NZ-WGN", "Wellington" },
                { "NZ-WKO", "Waikato" },
                { "NZ-WTC", "West Coast" }
            };
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.NZ;

            //var newYearDay1 = new DateTime(year, 1, 1).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            //var newYearDay2 = new DateTime(year, 1, 2).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2));
            //var boxingDay = new DateTime(year, 12, 26).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2));
            //var christmasDay = new DateTime(year, 12, 25).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));

            var easterSunday = this._catholicProvider.EasterSunday(year);
            var labourDay = DateHelper.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.Fourth);
            var canterburySouthDay = DateHelper.FindDay(year, Month.September, DayOfWeek.Monday, Occurrence.Fourth);
            var taranakiDay = DateHelper.FindDay(year, Month.March, DayOfWeek.Monday, Occurrence.Second);
            var canterburyDay = DateHelper.FindDay(year, Month.November, DayOfWeek.Tuesday, Occurrence.First).AddDays(10);

            var observedRuleSet1 = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(1)
            };

            var observedRuleSet2 = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(2)
            };

            var closestMondayObservedRuleSet = new ObservedRuleSet
            {
                Tuesday = date => date.AddDays(-1),
                Wednesday = date => date.AddDays(-2),
                Thursday = date => date.AddDays(-3),
                Friday = date => date.AddDays(3),
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(1)
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 2),
                    EnglishName = "Day after New Year's Day",
                    LocalName = "Day after New Year's Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet2
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Boxing Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet2
                },
                new HolidaySpecification
                {
                    Date = labourDay,
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 29),
                    EnglishName = "Auckland Anniversary Day",
                    LocalName = "Auckland/Northland Anniversary Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["NZ-AUK", "NZ-NTL", "NZ-MWT", "NZ-WKO", "NZ-GIS", "NZ-BOP", "NZ-HKB"],
                    ObservedRuleSet = closestMondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 22),
                    EnglishName = "Wellington Anniversary Day",
                    LocalName = "Wellington Anniversary Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["NZ-WGN", "NZ-MWT"],
                    ObservedRuleSet = closestMondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = canterburySouthDay,
                    EnglishName = "Canterbury (South) Anniversary Day",
                    LocalName = "Dominion Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["NZ-CAN"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 30),
                    EnglishName = "Chatham Islands Anniversary Day",
                    LocalName = "Chatham Islands Anniversary Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["NZ-CIT"],
                    ObservedRuleSet = closestMondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 2, 1),
                    EnglishName = "Nelson Anniversary Day",
                    LocalName = "Nelson Anniversary Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["NZ-NSN"],
                    ObservedRuleSet = closestMondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 23),
                    EnglishName = "Otago Anniversary Day",
                    LocalName = "Otago Anniversary Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["NZ-OTA"],
                    ObservedRuleSet = closestMondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = taranakiDay,
                    EnglishName = "Taranaki Anniversary Day",
                    LocalName = "Taranaki Anniversary Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["NZ-TKI"]
                },
                new HolidaySpecification
                {
                    Date = labourDay.AddDays(-3),
                    EnglishName = "Hawke's Bay Anniversary Day",
                    LocalName = "Hawke's Bay Anniversary Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["NZ-HKB"]
                },
                new HolidaySpecification
                {
                    Date = labourDay.AddDays(7),
                    EnglishName = "Marlborough Anniversary Day",
                    LocalName = "Marlborough Anniversary Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["NZ-MBH"]
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(2),
                    EnglishName = "Southland Anniversary Day",
                    LocalName = "Southland Anniversary Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["NZ-STL"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 1),
                    EnglishName = "Westland Anniversary Day",
                    LocalName = "Westland Anniversary Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["NZ-WTC"],
                    ObservedRuleSet = closestMondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = canterburyDay,
                    EnglishName = "Canterbury Anniversary Day",
                    LocalName = "Canterbury (North & Central) Anniversary Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["NZ-CAN"]
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year)
            };

            holidaySpecifications.AddIfNotNull(this.AnzacDay(year));
            holidaySpecifications.AddIfNotNull(this.WaitangiDay(year));
            holidaySpecifications.AddIfNotNull(this.Matariki(year));
            holidaySpecifications.AddIfNotNull(this.MonarchBirthday(year));
            holidaySpecifications.AddIfNotNull(this.MemorialDayForQueenElizabeth(year));

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);


            //var items = new List<Holiday>();        
            //items.Add(new Holiday(newYearDay1, "New Year's Day", "New Year's Day", countryCode));
            //items.Add(new Holiday(newYearDay2, "Day after New Year's Day", "Day after New Year's Day", countryCode));
            //items.Add(new Holiday(christmasDay, "Christmas Day", "Christmas Day", countryCode));
            //items.Add(new Holiday(boxingDay, "Boxing Day", "Boxing Day", countryCode));


            //#region Regional Anniversary Days
            // https://www.employment.govt.nz/leave-and-holidays/public-holidays/public-holidays-and-anniversary-dates/
            //var aucklandDay = new DateTime(year, 1, 29).ShiftToClosest(DayOfWeek.Monday);
            //items.Add(new Holiday(aucklandDay, "Auckland/Northland Anniversary Day", "Auckland Anniversary Day", countryCode, counties: new[] { "NZ-AUK", "NZ-NTL", "NZ-MWT", "NZ-WKO", "NZ-GIS", "NZ-BOP", "NZ-HKB" }));

            //var wellingtonDay = new DateTime(year, 1, 22).ShiftToClosest(DayOfWeek.Monday);
            //items.Add(new Holiday(wellingtonDay, "Wellington Anniversary Day", "Wellington Anniversary Day", countryCode, counties: new[] { "NZ-WGN", "NZ-MWT" }));

            //var canterburySouthDay = DateHelper.FindDay(year, Month.September, DayOfWeek.Monday, Occurrence.Fourth);
            //items.Add(new Holiday(canterburySouthDay, "Dominion Day", "Canterbury (South) Anniversary Day", countryCode, counties: new[] { "NZ-CAN" }));

            //var chathamDay = new DateTime(year, 11, 30).ShiftToClosest(DayOfWeek.Monday);
            //items.Add(new Holiday(chathamDay, "Chatham Islands Anniversary Day", "Chatham Islands Anniversary Day", countryCode, counties: new[] { "NZ-CIT" }));

            //var nelsonDay = new DateTime(year, 2, 1).ShiftToClosest(DayOfWeek.Monday);
            //items.Add(new Holiday(nelsonDay, "Nelson Anniversary Day", "Nelson Anniversary Day", countryCode, counties: new[] { "NZ-NSN" }));

            //var otagoDay = new DateTime(year, 3, 23).ShiftToClosest(DayOfWeek.Monday);
            //items.Add(new Holiday(otagoDay, "Otago Anniversary Day", "Otago Anniversary Day", countryCode, counties: new[] { "NZ-OTA" }));

            //items.Add(new Holiday(taranakiDay, "Taranaki Anniversary Day", "Taranaki Anniversary Day", countryCode, counties: new[] { "NZ-TKI" }));

            // Fri before labour day, and labour day always a Mon
            //var hawkesBayDay = labourDay.AddDays(-3);
            //items.Add(new Holiday(hawkesBayDay, "Hawke's Bay Anniversary Day", "Hawke's Bay Anniversary Day", countryCode, counties: new[] { "NZ-HKB" }));

            // Mon following labour day (which is always Mon itself)
            //var marlboroughDay = labourDay.AddDays(7);
            //items.Add(new Holiday(marlboroughDay, "Marlborough Anniversary Day", "Marlborough Anniversary Day", countryCode, counties: new[] { "NZ-MBH" }));

            // Easter Tues
            //var southlandDay = easterMonday.Date.AddDays(1);
            //items.Add(new Holiday(southlandDay, "Southland Anniversary Day", "Southland Anniversary Day", countryCode, counties: new[] { "NZ-STL" }));

            //var westlandDay = new DateTime(year, 12, 1).ShiftToClosest(DayOfWeek.Monday);
            //items.Add(new Holiday(westlandDay, "Westland Anniversary Day", "Westland Anniversary Day", countryCode, counties: new[] { "NZ-WTC" }));

            // 2nd Fri following 1st Tues of Nov!
            //items.Add(new Holiday(canterburyDay, "Canterbury (North & Central) Anniversary Day", "Canterbury Anniversary Day", countryCode, counties: new[] { "NZ-CAN" }));

            //#endregion

            //items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            //items.Add(new Holiday(labourDay, "Labour Day", "Labour Day", countryCode));

            //items.AddIfNotNull(this.AnzacDay(year, countryCode));
            //items.AddIfNotNull(this.WaitangiDay(year, countryCode));
            //items.AddIfNotNull(this.Matariki(year, countryCode));
            //items.AddIfNotNull(this.MonarchBirthday(year, countryCode));
            //items.AddIfNotNull(this.MemorialDayForQueenElizabeth(year, countryCode));

            //return items.OrderBy(o => o.Date);
        }

        private HolidaySpecification Matariki(int year)
        {
            if (this._matariki.TryGetValue(year, out var matariki))
            {
                return new HolidaySpecification
                {
                    Date = matariki,
                    EnglishName = "Matariki",
                    LocalName = "Matariki",
                    HolidayTypes = HolidayTypes.Public
                };

                //return new Holiday(matariki, "Matariki", "Matariki", countryCode);
            }

            return null;
        }

        private HolidaySpecification WaitangiDay(int year)
        {
            ObservedRuleSet observedRuleSet = null;

            if (year >= 2016)
            {
                observedRuleSet = new ObservedRuleSet
                {
                    Saturday = date => date.AddDays(2),
                    Sunday = date => date.AddDays(1),
                };

                //var waitangiDay = new DateTime(year, 2, 6).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
                //return new Holiday(waitangiDay, "Waitangi Day", "Waitangi Day", countryCode);
            }

            return new HolidaySpecification
            {
                Date = new DateTime(year, 2, 6),
                EnglishName = "Waitangi Day",
                LocalName = "Waitangi Day",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet
            };

            //return new Holiday(year, 2, 6, "Waitangi Day", "Waitangi Day", countryCode);
        }

        private HolidaySpecification AnzacDay(int year)
        {
            ObservedRuleSet observedRuleSet = null;

            if (year >= 2015)
            {
                observedRuleSet = new ObservedRuleSet
                {
                    Saturday = date => date.AddDays(2),
                    Sunday = date => date.AddDays(1),
                };

                //var anzacDay = new DateTime(year, 4, 25).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
                //return new Holiday(anzacDay, "Anzac Day", "Anzac Day", countryCode);
            }

            return new HolidaySpecification
            {
                Date = new DateTime(year, 4, 25),
                EnglishName = "Anzac Day",
                LocalName = "Anzac Day",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet
            };

            //return new Holiday(year, 4, 25, "Anzac Day", "Anzac Day", countryCode);
        }

        private HolidaySpecification MonarchBirthday(int year)
        {
            var name = "Queen's Birthday";
            if (year >= 2023)
            {
                name = "King's Birthday";
            }

            var monarchBirthday = DateHelper.FindDay(year, Month.June, DayOfWeek.Monday, Occurrence.First);

            return new HolidaySpecification
            {
                Date = monarchBirthday,
                EnglishName = name,
                LocalName = name,
                HolidayTypes = HolidayTypes.Public
            };

            //return new Holiday(monarchBirthday, name, name, countryCode);
        }

        private HolidaySpecification MemorialDayForQueenElizabeth(int year)
        {
            if (year == 2022)
            {
                //Public Holiday on 26 September to mark passing of Queen Elizabeth II
                //https://www.beehive.govt.nz/release/public-holiday-26-september-mark-passing-queen-elizabeth-ii

                return new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 26),
                    EnglishName = "Queen Elizabeth II Memorial Day",
                    LocalName = "Queen Elizabeth II Memorial Day",
                    HolidayTypes = HolidayTypes.Public
                };

                //return new Holiday(year, 9, 26, "Queen Elizabeth II Memorial Day", "Queen Elizabeth II Memorial Day", countryCode);
            }

            return null;
        }

        /// <summary>
        /// Matariki (Maori New Year) is introduced as a national public holiday beginning in 2022.
        /// The first 30 years of dates have been agreed upon by the Matariki Advisory Committee.
        /// The dates have been chosen to account for adjustments between the Maori lunar calendar and
        /// the Gregorian calendar, while ensuring the public holiday falls on a Friday.
        /// </summary>
        private void InitMatariki()
        {
            this._matariki = new DateTime[]
            {
                new DateTime(2022, 6, 24),
                new DateTime(2023, 7, 14),
                new DateTime(2024, 6, 28),
                new DateTime(2025, 6, 20),
                new DateTime(2026, 7, 10),
                new DateTime(2027, 6, 25),
                new DateTime(2028, 7, 14),
                new DateTime(2029, 7, 6),
                new DateTime(2030, 6, 21),
                new DateTime(2031, 7, 11),
                new DateTime(2032, 7, 2),
                new DateTime(2033, 6, 24),
                new DateTime(2034, 7, 7),
                new DateTime(2035, 6, 29),
                new DateTime(2036, 7, 18),
                new DateTime(2037, 7, 10),
                new DateTime(2038, 6, 25),
                new DateTime(2039, 7, 15),
                new DateTime(2040, 7, 6),
                new DateTime(2041, 7, 19),
                new DateTime(2042, 7, 11),
                new DateTime(2043, 7, 3),
                new DateTime(2044, 6, 24),
                new DateTime(2045, 7, 7),
                new DateTime(2046, 6, 29),
                new DateTime(2047, 7, 19),
                new DateTime(2048, 7, 3),
                new DateTime(2049, 6, 25),
                new DateTime(2050, 7, 15),
                new DateTime(2051, 6, 30),
                new DateTime(2052, 6, 21),
            }
            .ToDictionary(data => data.Year);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_New_Zealand",
                "https://www.mbie.govt.nz/assets/matariki-dates-2022-to-2052-matariki-advisory-group.pdf"
            };
        }
    }
}

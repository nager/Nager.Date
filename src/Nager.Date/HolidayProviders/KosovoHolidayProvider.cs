using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Kosovo HolidayProvider
    /// </summary>
    internal sealed class KosovoHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;
        private readonly IOrthodoxProvider _orthodoxProvider;
        private readonly HijriCalendar _hijriCalendar;

        /// <summary>
        /// Kosovo HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        /// <param name="orthodoxProvider"></param>
        public KosovoHolidayProvider(
            ICatholicProvider catholicProvider,
            IOrthodoxProvider orthodoxProvider) : base(CountryCode.XK)
        {
            this._catholicProvider = catholicProvider;
            this._orthodoxProvider = orthodoxProvider;
            this._hijriCalendar = new HijriCalendar();
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var observedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(1),
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Viti i Ri",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-02",
                    Date = new DateTime(year, 1, 2),
                    EnglishName = "New Year's Day",
                    LocalName = "Viti i Ri",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "ORTHODOXCHRISTMASDAY-01",
                    Date = new DateTime(year, 1, 7),
                    EnglishName = "Orthodox Christmas",
                    LocalName = "Krishtlindjet Ortodokse",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 2, 17),
                    EnglishName = "Independence Day",
                    LocalName = "Dita e Pavarësisë së Republikës së Kosovës",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "CONSTITUTIONDAY-01",
                    Date = new DateTime(year, 4, 9),
                    EnglishName = "Constitution Day",
                    LocalName = "Dita e Kushtetutës së Republikës së Kosovës",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "MAYDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "International Workers' Day",
                    LocalName = "Dita Ndërkombëtare e Punës",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "EUROPEDAY-01",
                    Date = new DateTime(year, 5, 9),
                    EnglishName = "Europe Day",
                    LocalName = "Dita e Evropës",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Catholic Christmas",
                    LocalName = "Krishtlindjet Katolike",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                this._catholicProvider.EasterMonday("E hëna e Pashkëve Katolike", year, observedRuleSet),
                this._orthodoxProvider.EasterMonday("E hëna e Pashkëve Ortodokse", year, observedRuleSet),
            };

            holidaySpecifications.AddIfNotNull(this.GetEidAlFitr(year));
            holidaySpecifications.AddIfNotNull(this.GetEidAlAdha(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? GetEidAlFitr(int year)
        {
            if (year > this._hijriCalendar.MinSupportedDateTime.Year &&
                year < this._hijriCalendar.MaxSupportedDateTime.Year)
            {
                this._hijriCalendar.HijriAdjustment = -1;
                var hijriYear = this._hijriCalendar.GetYear(new DateTime(year, 1, 1));

                var month = 10;

                for (var hy = hijriYear; hy <= hijriYear + 1; hy++)
                {
                    try
                    {
                        var date = this._hijriCalendar.ToDateTime(hy, month, 1, 0, 0, 0, 0);
                        if (date.Year == year)
                        {
                            return new HolidaySpecification
                            {
                                Id = $"EIDALFITR-{hy}-01",
                                Date = date,
                                EnglishName = "Eid al-Fitr",
                                LocalName = "Bajrami i Madh",
                                HolidayTypes = HolidayTypes.Public,
                            };
                        }
                    }
                    catch
                    {
                    }
                }
            }

            return null;
        }

        private HolidaySpecification? GetEidAlAdha(int year)
        {
            if (year > this._hijriCalendar.MinSupportedDateTime.Year &&
                year < this._hijriCalendar.MaxSupportedDateTime.Year)
            {
                this._hijriCalendar.HijriAdjustment = -1;
                var hijriYear = this._hijriCalendar.GetYear(new DateTime(year, 1, 1));

                var month = 12;

                for (var hy = hijriYear; hy <= hijriYear + 1; hy++)
                {
                    try
                    {
                        var date = this._hijriCalendar.ToDateTime(hy, month, 10, 0, 0, 0, 0);
                        if (date.Year == year)
                        {
                            return new HolidaySpecification
                            {
                                Id = $"EIDALADHA-{hy}-01",
                                Date = date,
                                EnglishName = "Eid al-Adha",
                                LocalName = "Bajrami i Vogël",
                                HolidayTypes = HolidayTypes.Public,
                            };
                        }
                    }
                    catch
                    {
                    }
                }
            }

            return null;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://gzk.rks-gov.net/ActDocumentDetail.aspx?ActID=2539",
                "https://en.wikipedia.org/wiki/Public_holidays_in_Kosovo"
            ];
        }
    }
}

using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Benin HolidayProvider
    /// </summary>
    internal sealed class BeninHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Benin HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public BeninHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.BJ)
        {
            this._catholicProvider = catholicProvider;
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
                    LocalName = "Fête du Nouvel An",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "REMEMBRANCEDAY-01",
                    Date = new DateTime(year, 1, 16),
                    EnglishName = "Remembrance Day",
                    LocalName = "Journée de Souvenir",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "PEOPLESSOVEREIGNTYDAY-01",
                    Date = new DateTime(year, 2, 28),
                    EnglishName = "People's Sovereignty Day",
                    LocalName = "Journée de la Souveraineté du Peuple",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "INTERNATIONALWOMENSDAY-01",
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "International Women's Day",
                    LocalName = "Journée de la Femme",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Fête du Travail",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NATIONALDAY-01",
                    Date = new DateTime(year, 8, 1),
                    EnglishName = "National Day",
                    LocalName = "Fête Nationale",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ASSUMPTIONDAY-01",
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption Day",
                    LocalName = "Jour de l'Assomption",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ALLSAINTSDAY-01",
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints' Day",
                    LocalName = "Jour de la Toussaint",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Jour de la Noël",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._catholicProvider.EasterMonday("Lundi de Pâques", year),
                this._catholicProvider.AscensionDay("Jour de l'Ascension", year),
                this._catholicProvider.WhitMonday("Lundi de Pentecôte", year),
            };

            holidaySpecifications.AddRangeIfNotNull(this.VodounFestival(year));

            //TODO: Islamic Holidays (Law 90-019)
            //CalendarType: Lunar
            //DeterminationType: MoonSighting
            //Astronomical calculation: No
            //1 Shawwal	Jour du Ramadan	Eid al-Fitr
            //10 Dhu al-Hijjah	Jour de la Tabaski	Eid al-Adha
            //12 Rabi' al-awwal	Journée Maouloud	Prophet's Birthday

            return holidaySpecifications;
        }

        private HolidaySpecification[] VodounFestival(int year)
        {
            if (year < 1998)
            {
                return [];
            }

            var englishName = "Vodoun Festival";
            var localName = "Fête annuelle des religions traditionnelles";

            if (year <= 2024)
            {
                //Law 97-031: 10 January
                return
                [
                    new HolidaySpecification
                    {
                        Id = "TRADITIONALDAY-01",
                        Date = new DateTime(year, 1, 10),
                        EnglishName = englishName,
                        LocalName = localName,
                        HolidayTypes = HolidayTypes.Public,
                    }
                ];
            }

            //Law 2024-32: second Friday of January and the Thursday before it
            var secondFridayInJanuary = DateHelper.FindDay(year, Month.January, DayOfWeek.Friday, Occurrence.Second);

            return
            [
                new HolidaySpecification
                {
                    Id = "TRADITIONALDAY-01",
                    Date = secondFridayInJanuary,
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "TRADITIONALDAY-02",
                    Date = secondFridayInJanuary.AddDays(-1),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                },
            ];
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://sgg.gouv.bj/doc/loi-90-019/",
                "https://sgg.gouv.bj/doc/loi-97-031/",
                "https://sgg.gouv.bj/doc/loi-2024-32/",
                "https://en.wikipedia.org/wiki/Public_holidays_in_Benin",
            ];
        }
    }
}

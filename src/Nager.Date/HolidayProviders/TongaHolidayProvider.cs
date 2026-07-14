using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Tonga HolidayProvider
    /// </summary>
    internal sealed class TongaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Tonga HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public TongaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.TO)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var sundayObservedRuleSet = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(1),
            };

            var mondayObservedRuleSet = new ObservedRuleSet
            {
                Monday = date => date.AddDays(1),
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = sundayObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "EMANCIPATIONDAY-01",
                    Date = new DateTime(year, 6, 4),
                    EnglishName = "Emancipation Day",
                    LocalName = "Emancipation Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = sundayObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "CONSTITUTIONDAY-01",
                    Date = new DateTime(year, 11, 4),
                    EnglishName = "Constitution Day",
                    LocalName = "Constitution Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = sundayObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "KINGCORONATIONDAY-01",
                    Date = new DateTime(year, 12, 4),
                    EnglishName = "Anniversary of the Coronation of H.M. King George Tubou I",
                    LocalName = "Anniversary of the Coronation of H.M. King George Tubou I",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = sundayObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-02",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = mondayObservedRuleSet,
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year),
            };

            holidaySpecifications.AddIfNotNull(this.BirthdayOfTheHeirToTheCrownofTonga(year, sundayObservedRuleSet));
            holidaySpecifications.AddIfNotNull(this.BirthdayOfTheReigningSovereignOfTonga(year, sundayObservedRuleSet));

            return holidaySpecifications;
        }

        private HolidaySpecification? BirthdayOfTheHeirToTheCrownofTonga(
            int year,
            ObservedRuleSet observedRuleSet)
        {
            return new HolidaySpecification
            {
                Id = "BIRTHDAYHEIROFTHECROWNTONGA-01",
                Date = new DateTime(year, 9, 17),
                EnglishName = "Birthday of the Heir to the Crown of Tonga",
                LocalName = "Birthday of the Heir to the Crown of Tonga",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet
            };
        }

        private HolidaySpecification? BirthdayOfTheReigningSovereignOfTonga(
            int year,
            ObservedRuleSet observedRuleSet)
        {
            return new HolidaySpecification
            {
                Id = "BIRTHDAYHEIROFTHEREIGNINGSOVEREIGN-01",
                Date = new DateTime(year, 7, 4),
                EnglishName = "Birthday of the reigning Sovereign of Tonga",
                LocalName = "Birthday of the reigning Sovereign of Tonga",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet
            };
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://ago.gov.to/cms/images/LEGISLATION/PRINCIPAL/1919/1919-0008/PublicHolidaysAct_1.pdf",
                "https://de.wikipedia.org/wiki/Feiertage_in_Tonga",
            ];
        }
    }
}

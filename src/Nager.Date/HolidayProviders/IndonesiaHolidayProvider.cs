using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Indonesia HolidayProvider
    /// </summary>
    internal sealed class IndonesiaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Indonesia HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public IndonesiaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.ID)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            //TODO: Add chinise calendar
            //TODO: Add Balinese Saka calendar support
            //TODO: Add islamic calendar support
            //TODO: Add Buddhist calendar

            //Add Chinese New Year (Tahun Baru Imlek)
            //Add Day of Silence (Hari Raya Nyepi-Tahun Baru Saka)
            //Add Ascension of the Prophet (Isra Mi'raj Nabi Muhammad)
            //Add Eid al-Fitr (Hari Raya Idul Fitri)
            //Add Feast of the Sacrifice (Hari Raya Idul Adha)
            //Add Islamic New Year (Tahun Baru Islam 1440 Hijriah)
            //Add Birth of the Prophet (Maulid Nabi Muhammad)


            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Tahun Baru Masehi",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Hari Buruh Internasional",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 1),
                    EnglishName = "Pancasila Day",
                    LocalName = "Hari Lahir Pancasila",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 17),
                    EnglishName = "Independence Day",
                    LocalName = "Hari Ulang Tahun Kemerdekaan Republik Indonesia",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Hari Raya Natal",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.GoodFriday("Wafat Isa Almasih", year),
                this._catholicProvider.EasterSunday("Paskah", year),
                this._catholicProvider.AscensionDay("Kenaikan Isa Almasih", year)
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Indonesia",
            ];
        }
    }
}

using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Globalization;

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
            //TODO: Add islamic calendar support

            //Add Ascension of the Prophet (Isra Mi'raj Nabi Muhammad)
            //Add Eid al-Fitr (Hari Raya Idul Fitri)
            //Add Feast of the Sacrifice (Hari Raya Idul Adha)
            //Add Islamic New Year (Tahun Baru Islam 1440 Hijriah)
            //Add Birth of the Prophet (Maulid Nabi Muhammad)


            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Tahun Baru Masehi",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Hari Buruh Internasional",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "PANCASILADAY-01",
                    Date = new DateTime(year, 6, 1),
                    EnglishName = "Pancasila Day",
                    LocalName = "Hari Lahir Pancasila",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 8, 17),
                    EnglishName = "Independence Day",
                    LocalName = "Hari Ulang Tahun Kemerdekaan Republik Indonesia",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Hari Raya Natal",
                    HolidayTypes = HolidayTypes.Public,
                },
            };

            // Keputusan Presiden Nomor 8 Tahun 2024 renamed the Christian holidays
            // and made Easter Sunday a national holiday.
            if (year >= 2024)
            {
                holidaySpecifications.Add(this._catholicProvider.GoodFriday("Wafat Yesus Kristus", year));
                holidaySpecifications.Add(this._catholicProvider.EasterSunday("Kebangkitan Yesus Kristus (Paskah)", year));
                holidaySpecifications.Add(this._catholicProvider.AscensionDay("Kenaikan Yesus Kristus", year));
            }
            else
            {
                holidaySpecifications.Add(this._catholicProvider.GoodFriday("Wafat Isa Almasih", year));
                holidaySpecifications.Add(this._catholicProvider.AscensionDay("Kenaikan Isa Almasih", year));
            }

            holidaySpecifications.AddIfNotNull(this.ChineseNewYear(year));
            holidaySpecifications.AddIfNotNull(this.DayOfSilence(year));
            holidaySpecifications.AddIfNotNull(this.VesakDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? ChineseNewYear(int year)
        {
            // National holiday since 2003 (Keputusan Presiden Nomor 19 Tahun 2002)
            if (year < 2003)
            {
                return null;
            }

            var chineseCalendar = new ChineseLunisolarCalendar();
            if (year <= chineseCalendar.MinSupportedDateTime.Year || year >= chineseCalendar.MaxSupportedDateTime.Year)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "CHINESENEWYEAR-01",
                Date = chineseCalendar.ToDateTime(year, 1, 1, 0, 0, 0, 0),
                EnglishName = "Chinese New Year",
                LocalName = "Tahun Baru Imlek",
                HolidayTypes = HolidayTypes.Public
            };
        }

        private HolidaySpecification? DayOfSilence(int year)
        {
            // Nyepi follows the Balinese Saka calendar; the date is set by the yearly SKB 3 Menteri
            DateTime? date = year switch
            {
                2025 => new DateTime(year, 3, 29),
                2026 => new DateTime(year, 3, 19),
                2027 => new DateTime(year, 3, 8),
                _ => null
            };

            if (!date.HasValue)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "DAYOFSILENCE-01",
                Date = date.Value,
                EnglishName = "Day of Silence",
                LocalName = "Hari Suci Nyepi",
                HolidayTypes = HolidayTypes.Public
            };
        }

        private HolidaySpecification? VesakDay(int year)
        {
            // The date is set by the yearly SKB 3 Menteri
            DateTime? date = year switch
            {
                2025 => new DateTime(year, 5, 12),
                2026 => new DateTime(year, 5, 31),
                2027 => new DateTime(year, 5, 20),
                _ => null
            };

            if (!date.HasValue)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "VESAKDAY-01",
                Date = date.Value,
                EnglishName = "Vesak Day",
                LocalName = "Hari Raya Waisak",
                HolidayTypes = HolidayTypes.Public
            };
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Indonesia",
                "https://peraturan.bpk.go.id/Details/276688/keppres-no-8-tahun-2024",
                "https://web.archive.org/web/20250413193349/https://setkab.go.id/pemerintah-tetapkan-hari-libur-nasional-dan-cuti-bersama-tahun-2025/",
                "https://www.setneg.go.id/baca/index/inilah_skb_3_menteri_libur_nasional_dan_cuti_bersama_2026",
                "https://web.archive.org/web/20260917182154/https://setneg.go.id/baca/index/inilah_skb_3_menteri_libur_nasional_dan_cuti_bersama_2027",
            ];
        }
    }
}

using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Switzerland HolidayProvider
    /// </summary>
    internal sealed class SwitzerlandHolidayProvider : AbstractHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Switzerland HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SwitzerlandHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.CH)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
        {
            return new Dictionary<string, string>
            {
                { "CH-AG", "Aargau" },
                { "CH-AI", "Appenzell Innerrhoden" },
                { "CH-AR", "Appenzell Ausserrhoden" },
                { "CH-BL", "Basel-Landschaft" },
                { "CH-BS", "Basel-Stadt" },
                { "CH-BE", "Bern" },
                { "CH-FR", "Freiburg" },
                { "CH-GE", "Genf" },
                { "CH-GL", "Glarus" },
                { "CH-GR", "Graubünden" },
                { "CH-JU", "Jura" },
                { "CH-LU", "Luzern" },
                { "CH-NE", "Neuenburg" },
                { "CH-NW", "Nidwalden" },
                { "CH-OW", "Obwalden" },
                { "CH-SG", "St. Gallen" },
                { "CH-SH", "Schaffhausen" },
                { "CH-SZ", "Schwyz" },
                { "CH-SO", "Solothurn" },
                { "CH-TG", "Thurgau" },
                { "CH-TI", "Tessin" },
                { "CH-UR", "Uri" },
                { "CH-VS", "Wallis" },
                { "CH-VD", "Waadt" },
                { "CH-ZG", "Zug" },
                { "CH-ZH", "Zürich" }
            };
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var firstSundayOfSeptember = DateHelper.FindDay(year, Month.September, DayOfWeek.Sunday, Occurrence.First);
            var thirdSundayOfSeptember = DateHelper.FindDay(year, Month.September, DayOfWeek.Sunday, Occurrence.Third);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Neujahr",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 2),
                    EnglishName = "St. Berchtold's Day",
                    LocalName = "Berchtoldstag",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CH-ZH", "CH-BE", "CH-LU", "CH-OW", "CH-GL", "CH-ZG", "CH-FR", "CH-SO", "CH-SH", "CH-TG", "CH-VD", "CH-NE", "CH-GE", "CH-JU"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Epiphany",
                    LocalName = "Heilige Drei Könige",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CH-UR", "CH-SZ", "CH-GR", "CH-TI"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 19),
                    EnglishName = "Saint Joseph's Day",
                    LocalName = "Josefstag",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CH-LU", "CH-UR", "CH-SZ", "CH-NW", "CH-ZG", "CH-GR", "CH-TI", "CH-VS"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Tag der Arbeit",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CH-ZH", "CH-FR", "CH-SO", "CH-BS", "CH-BL", "CH-SH", "CH-AG", "CH-TG", "CH-TI", "CH-NE", "CH-JU"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 1),
                    EnglishName = "Swiss National Day",
                    LocalName = "Bundesfeier",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption of the Virgin Mary",
                    LocalName = "Maria Himmelfahrt",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-ZG", "CH-FR", "CH-SO", "CH-BL", "CH-AI", "CH-GR", "CH-AG", "CH-TI", "CH-VS", "CH-JU"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints' Day",
                    LocalName = "Allerheiligen",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-GL", "CH-ZG", "CH-FR", "CH-SO", "CH-AI", "CH-SG", "CH-GR", "CH-AG", "CH-TI", "CH-VS", "CH-JU"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Immaculate Conception",
                    LocalName = "Mariä Empfängnis",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-ZG", "CH-FR", "CH-SO", "CH-AI", "CH-GR", "CH-AG", "CH-TI", "CH-VS"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Weihnachten",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Stephanstag",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CH-AG", "CH-AI", "CH-AR", "CH-BL", "CH-BS", "CH-BE", "CH-FR", "CH-GL", "CH-GR", "CH-LU", "CH-NW", "CH-OW", "CH-SG", "CH-SH", "CH-SZ", "CH-SO", "CH-TG", "CH-TI", "CH-UR", "CH-ZG", "CH-ZH"]
                },
                new HolidaySpecification
                {
                    Date = firstSundayOfSeptember.AddDays(4),
                    EnglishName = "Geneva Prayday",
                    LocalName = "Jeûne genevois",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CH-GE"]
                },
                new HolidaySpecification
                {
                    Date = thirdSundayOfSeptember,
                    EnglishName = "Federal Day of Thanksgiving",
                    LocalName = "Eidgenössischer Dank-, Buss- und Bettag",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CH-ZH", "CH-BE", "CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-GL", "CH-ZG", "CH-FR", "CH-SO", "CH-BS", "CH-BL", "CH-SH", "CH-AR", "CH-AI", "CH-SG", "CH-GR", "CH-AG", "CH-TG", "CH-TI", "CH-VD", "CH-VS", "CH-NE", "CH-JU"]
                },
                new HolidaySpecification
                {
                    Date = thirdSundayOfSeptember.AddDays(1),
                    EnglishName = "Federal Fast Monday",
                    LocalName = "Bettagsmontag",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CH-VD"]
                },
                this._catholicProvider.GoodFriday("Karfreitag", year).SetSubdivisionCodes("CH-ZH", "CH-BE", "CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-GL", "CH-ZG", "CH-FR", "CH-SO", "CH-BS", "CH-BL", "CH-SH", "CH-AR", "CH-AI", "CH-SG", "CH-GR", "CH-AG", "CH-TG", "CH-VD", "CH-NE", "CH-GE", "CH-JU"),
                this._catholicProvider.EasterMonday("Ostermontag", year).SetSubdivisionCodes("CH-ZH", "CH-BE", "CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-GL", "CH-ZG", "CH-FR", "CH-SO", "CH-BS", "CH-BL", "CH-SH", "CH-AR", "CH-AI", "CH-SG", "CH-GR", "CH-AG", "CH-TG", "CH-TI", "CH-VD", "CH-NE", "CH-GE", "CH-JU"),
                this._catholicProvider.AscensionDay("Auffahrt", year),
                this._catholicProvider.WhitMonday("Pfingstmontag", year).SetSubdivisionCodes("CH-ZH", "CH-BE", "CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-GL", "CH-ZG", "CH-FR", "CH-BS", "CH-BL", "CH-SH", "CH-AR", "CH-AI", "CH-SG", "CH-GR", "CH-TG", "CH-TI", "CH-VD", "CH-NE", "CH-GE", "CH-JU"),
                this._catholicProvider.CorpusChristi("Fronleichnam", year).SetSubdivisionCodes("CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-ZG", "CH-AI", "CH-TI", "CH-VS", "CH-JU")
            };

            return holidaySpecifications;

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Neujahr", "New Year's Day", countryCode, 1967));
            //items.Add(new Holiday(year, 1, 2, "Berchtoldstag", "St. Berchtold's Day", countryCode, null, new string[] { "CH-ZH", "CH-BE", "CH-LU", "CH-OW", "CH-GL", "CH-ZG", "CH-FR", "CH-SO", "CH-SH", "CH-TG", "CH-VD", "CH-NE", "CH-GE", "CH-JU" }));
            //items.Add(new Holiday(year, 1, 6, "Heilige Drei Könige", "Epiphany", countryCode, null, new string[] { "CH-UR", "CH-SZ", "CH-GR", "CH-TI" }));
            //items.Add(new Holiday(year, 3, 19, "Josefstag", "Saint Joseph's Day", countryCode, null, new string[] { "CH-LU", "CH-UR", "CH-SZ", "CH-NW", "CH-ZG", "CH-GR", "CH-TI", "CH-VS" }));
            //items.Add(this._catholicProvider.GoodFriday("Karfreitag", year, countryCode).SetCounties("CH-ZH", "CH-BE", "CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-GL", "CH-ZG", "CH-FR", "CH-SO", "CH-BS", "CH-BL", "CH-SH", "CH-AR", "CH-AI", "CH-SG", "CH-GR", "CH-AG", "CH-TG", "CH-VD", "CH-NE", "CH-GE", "CH-JU"));
            //items.Add(this._catholicProvider.EasterMonday("Ostermontag", year, countryCode).SetLaunchYear(1642).SetCounties("CH-ZH", "CH-BE", "CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-GL", "CH-ZG", "CH-FR", "CH-SO", "CH-BS", "CH-BL", "CH-SH", "CH-AR", "CH-AI", "CH-SG", "CH-GR", "CH-AG", "CH-TG", "CH-TI", "CH-VD", "CH-NE", "CH-GE", "CH-JU"));
            //items.Add(new Holiday(year, 5, 1, "Tag der Arbeit", "Labour Day", countryCode, null, new string[] { "CH-ZH", "CH-FR", "CH-SO", "CH-BS", "CH-BL", "CH-SH", "CH-AG", "CH-TG", "CH-TI", "CH-NE", "CH-JU" }));
            //items.Add(this._catholicProvider.AscensionDay("Auffahrt", year, countryCode));
            //items.Add(this._catholicProvider.WhitMonday("Pfingstmontag", year, countryCode).SetCounties("CH-ZH", "CH-BE", "CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-GL", "CH-ZG", "CH-FR", "CH-SO", "CH-BS", "CH-BL", "CH-SH", "CH-AR", "CH-AI", "CH-SG", "CH-GR", "CH-AG", "CH-TG", "CH-TI", "CH-VD", "CH-NE", "CH-GE", "CH-JU"));
            //items.Add(this._catholicProvider.CorpusChristi("Fronleichnam", year, countryCode).SetCounties("CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-ZG", "CH-FR", "CH-SO", "CH-BL", "CH-AI", "CH-GR", "CH-AG", "CH-TI", "CH-VS", "CH-NE", "CH-JU"));
            //items.Add(new Holiday(year, 8, 1, "Bundesfeier", "Swiss National Day", countryCode));
            //items.Add(new Holiday(year, 8, 15, "Maria Himmelfahrt", "Assumption of the Virgin Mary", countryCode, null, new string[] { "CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-ZG", "CH-FR", "CH-SO", "CH-BL", "CH-AI", "CH-GR", "CH-AG", "CH-TI", "CH-VS", "CH-JU" }));
            //items.Add(new Holiday(year, 11, 1, "Allerheiligen", "All Saints' Day", countryCode, null, new string[] { "CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-GL", "CH-ZG", "CH-FR", "CH-SO", "CH-AI", "CH-SG", "CH-GR", "CH-AG", "CH-TI", "CH-VS", "CH-JU" }));
            //items.Add(new Holiday(year, 12, 8, "Mariä Empfängnis", "Immaculate Conception", countryCode, null, new string[] { "CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-ZG", "CH-FR", "CH-SO", "CH-AI", "CH-GR", "CH-AG", "CH-TI", "CH-VS" }));
            //items.Add(new Holiday(year, 12, 25, "Weihnachten", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Stephanstag", "St. Stephen's Day", countryCode, null, new string[] { "CH-AG", "CH-AI", "CH-AR", "CH-BL", "CH-BS", "CH-BE", "CH-FR", "CH-GL", "CH-GR", "CH-LU", "CH-NW", "CH-OW", "CH-SG", "CH-SH", "CH-SZ", "CH-SO", "CH-TG", "CH-TI", "CH-UR", "CH-ZG", "CH-ZH" }));
            //items.Add(new Holiday(firstSundayOfSeptember.AddDays(4), "Jeûne genevois", "Geneva Prayday", countryCode, null, new string[] { "CH-GE" }));
            //items.Add(new Holiday(thirdSundayOfSeptember, "Eidgenössischer Dank-, Buss- und Bettag", "Federal Day of Thanksgiving", countryCode, null, new string[] { "CH-ZH", "CH-BE", "CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-GL", "CH-ZG", "CH-FR", "CH-SO", "CH-BS", "CH-BL", "CH-SH", "CH-AR", "CH-AI", "CH-SG", "CH-GR", "CH-AG", "CH-TG", "CH-TI", "CH-VD", "CH-VS", "CH-NE", "CH-JU" }));
            //items.Add(new Holiday(thirdSundayOfSeptember.AddDays(1), "Bettagsmontag", "Federal Fast Monday", countryCode, null, new string[] { "CH-VD" }));
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://de.wikipedia.org/wiki/Feiertage_in_der_Schweiz",
                "https://en.wikipedia.org/wiki/Federal_Day_of_Thanksgiving,_Repentance_and_Prayer",
                "https://en.wikipedia.org/wiki/Je%C3%BBne_genevois"
            ];
        }
    }
}

using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// France
    /// </summary>
    public class FranceProvider : IPublicHolidayProvider, ICountyProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// FranceProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public FranceProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IDictionary<string, string> GetCounties()
        {
            return new Dictionary<string, string>
            {
                { "FR-20R", "Corse" },
                { "FR-ARA", "Auvergne-Rhône-Alpes" },
                { "FR-BFC", "Bourgogne-Franche-Comté" },
                { "FR-BRE", "Bretagne" },
                { "FR-CVL", "Centre-Val de Loire" },
                { "FR-GES", "Grand-Est" },
                { "FR-GF", "Guyane (française)" },
                { "FR-GP", "Guadeloupe" },
                { "FR-HDF", "Hauts-de-France" },
                { "FR-IDF", "Île-de-France" },
                { "FR-MQ", "Martinique" },
                { "FR-NAQ", "Nouvelle-Aquitaine" },
                { "FR-NOR", "Normandie" },
                { "FR-OCC", "Occitanie" },
                { "FR-PAC", "Provence-Alpes-Côte-d’Azur" },
                { "FR-PDL", "Pays-de-la-Loire" },
                { "FR-RE", "La Réunion" },
                { "FR-YT", "Mayotte" },
                { "FR-01", "Ain" },
                { "FR-02", "Aisne" },
                { "FR-03", "Allier" },
                { "FR-04", "Alpes-de-Haute-Provence" },
                { "FR-05", "Hautes-Alpes" },
                { "FR-06", "Alpes-Maritimes" },
                { "FR-07", "Ardèche" },
                { "FR-08", "Ardennes" },
                { "FR-09", "Ariège" },
                { "FR-10", "Aube" },
                { "FR-11", "Aude" },
                { "FR-12", "Aveyron" },
                { "FR-13", "Bouches-du-Rhône" },
                { "FR-14", "Calvados" },
                { "FR-15", "Cantal" },
                { "FR-16", "Charente" },
                { "FR-17", "Charente-Maritime" },
                { "FR-18", "Cher" },
                { "FR-19", "Corrèze" },
                { "FR-2A", "Corse-du-Sud" },
                { "FR-2B", "Haute-Corse" },
                { "FR-21", "Côte-d'Or" },
                { "FR-22", "Côtes-d'Armor" },
                { "FR-23", "Creuse" },
                { "FR-24", "Dordogne" },
                { "FR-25", "Doubs" },
                { "FR-26", "Drôme" },
                { "FR-27", "Eure" },
                { "FR-28", "Eure-et-Loir" },
                { "FR-29", "Finistère" },
                { "FR-30", "Gard" },
                { "FR-31", "Haute-Garonne" },
                { "FR-32", "Gers" },
                { "FR-33", "Gironde" },
                { "FR-34", "Hérault" },
                { "FR-35", "Ille-et-Vilaine" },
                { "FR-36", "Indre" },
                { "FR-37", "Indre-et-Loire" },
                { "FR-38", "Isère" },
                { "FR-39", "Jura" },
                { "FR-40", "Landes" },
                { "FR-41", "Loir-et-Cher" },
                { "FR-42", "Loire" },
                { "FR-43", "Haute-Loire" },
                { "FR-44", "Loire-Atlantique" },
                { "FR-45", "Loiret" },
                { "FR-46", "Lot" },
                { "FR-47", "Lot-et-Garonne" },
                { "FR-48", "Lozère" },
                { "FR-49", "Maine-et-Loire" },
                { "FR-50", "Manche" },
                { "FR-51", "Marne" },
                { "FR-52", "Haute-Marne" },
                { "FR-53", "Mayenne" },
                { "FR-54", "Meurthe-et-Moselle" },
                { "FR-55", "Meuse" },
                { "FR-56", "Morbihan" },
                { "FR-57", "Moselle" },
                { "FR-58", "Nièvre" },
                { "FR-59", "Nord" },
                { "FR-60", "Oise" },
                { "FR-61", "Orne" },
                { "FR-62", "Pas-de-Calais" },
                { "FR-63", "Puy-de-Dôme" },
                { "FR-64", "Pyrénées-Atlantiques" },
                { "FR-65", "Hautes-Pyrénées" },
                { "FR-66", "Pyrénées-Orientales" },
                { "FR-67", "Bas-Rhin" },
                { "FR-68", "Haut-Rhin" },
                { "FR-69", "Rhône" },
                { "FR-70", "Haute-Saône" },
                { "FR-71", "Saône-et-Loire" },
                { "FR-72", "Sarthe" },
                { "FR-73", "Savoie" },
                { "FR-74", "Haute-Savoie" },
                { "FR-75", "Paris" },
                { "FR-76", "Seine-Maritime" },
                { "FR-77", "Seine-et-Marne" },
                { "FR-78", "Yvelines" },
                { "FR-79", "Deux-Sèvres" },
                { "FR-80", "Somme" },
                { "FR-81", "Tarn" },
                { "FR-82", "Tarn-et-Garonne" },
                { "FR-83", "Var" },
                { "FR-84", "Vaucluse" },
                { "FR-85", "Vendée" },
                { "FR-86", "Vienne" },
                { "FR-87", "Haute-Vienne" },
                { "FR-88", "Vosges" },
                { "FR-89", "Yonne" },
                { "FR-90", "Territoire de Belfort" },
                { "FR-91", "Essonne" },
                { "FR-92", "Hauts-de-Seine" },
                { "FR-93", "Seine-Saint-Denis" },
                { "FR-94", "Val-de-Marne" },
                { "FR-95", "Val-d'Oise" },
                { "FR-971", "Guadeloupe" },
                { "FR-972", "Martinique" },
                { "FR-973", "Guyane (française)" },
                { "FR-974", "La Réunion" },
                { "FR-976", "Mayotte" },

                { "FR-BL", "Saint-Barthélemy" },
                { "FR-CP", "Clipperton" },
                { "FR-MF", "Saint-Martin" },
                { "FR-NC", "Nouvelle-Calédonie" },
                { "FR-PF", "Polynésie française" },
                { "FR-PM", "Saint-Pierre-et-Miquelon" },
                { "FR-TF", "Terres australes françaises" },
                { "FR-WF", "Wallis-et-Futuna" },
                { "FR-A", "Alsace" }
            };
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.FR;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Jour de l'an", "New Year's Day", countryCode, 1967));
            items.Add(this._catholicProvider.GoodFriday("Vendredi saint", year, countryCode).SetCounties("FR-A", "FR-57"));
            items.Add(this._catholicProvider.EasterMonday("Lundi de Pâques", year, countryCode).SetLaunchYear(1642));
            items.Add(new PublicHoliday(year, 5, 1, "Fête du premier mai", "Labour Day", countryCode));
            items.Add(this._catholicProvider.AscensionDay("Jour de l'Ascension", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 8, "Fête de la Victoire", "Victory in Europe Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 22, "Abolition de l'esclavage", "Abolition of Slavery", countryCode, null, new string[] { "FR-MQ" }));
            items.Add(new PublicHoliday(year, 5, 27, "Abolition of Slavery", "Abolition de l'esclavage", countryCode, null, new string[] { "FR-GP", "FR-MF", "FR-BL" }));
            items.Add(this._catholicProvider.WhitMonday("Lundi de Pentecôte", year, countryCode));
            items.Add(new PublicHoliday(year, 7, 14, "Fête nationale", "Bastille Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "L'Assomption de Marie", "Assumption Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "La Toussaint", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 11, "Armistice de 1918", "Armistice Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Noël", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Saint-Étienne", "St. Stephen's Day", countryCode, null, new string[] { "FR-A", "FR-57" }));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_France",
                "https://en.wikipedia.org/wiki/ISO_3166-2:FR",
            };
        }
    }
}

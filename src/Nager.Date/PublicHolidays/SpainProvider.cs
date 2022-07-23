using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Spain
    /// </summary>
    public class SpainProvider : IPublicHolidayProvider, ICountyProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// SpainProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SpainProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IDictionary<string, string> GetCounties()
        {
            return new Dictionary<string, string>
            {
                //https://en.wikipedia.org/wiki/ISO_3166-2:ES
                { "ES-AN", "Andalusia" },
                { "ES-AR", "Aragon" },
                { "ES-AS", "Principality of Asturias" },
                { "ES-CN", "Canary Islands" },
                { "ES-CB", "Cantabria" },
                { "ES-CL", "Castile and León" },
                { "ES-CM", "Castile-La Mancha" },
                { "ES-CT", "Catalonia" },
                { "ES-CE", "Ceuta" },
                { "ES-EX", "Extremadura" },
                { "ES-GA", "Galicia" },
                { "ES-IB", "Balearic Islands" },
                { "ES-RI", "La Rioja" },
                { "ES-MD", "Community of Madrid" },
                { "ES-ML", "Melilla" },
                { "ES-MC", "Region of Murcia" },
                { "ES-NC", "Chartered Community of Navarre" },
                { "ES-PV", "Basque Country" },
                { "ES-VC", "Valencian Community" },
            };
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.ES;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Año Nuevo", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(year, 1, 6, "Día de Reyes / Epifanía del Señor", "Epiphany", countryCode));
            items.Add(new PublicHoliday(year, 2, 28, "Día de Andalucía", "Regional Holiday", countryCode, null, new string[] { "ES-AN" }));
            items.Add(new PublicHoliday(year, 3, 1, "Dia de les Illes Balears", "Regional Holiday", countryCode, null, new string[] { "ES-IB" }));
            items.Add(this._catholicProvider.MaundyThursday("Jueves Santo", year, countryCode).SetCounties("ES-AN", "ES-AR", "ES-CE", "ES-ML", "ES-CL", "ES-CM", "ES-CN", "ES-EX", "ES-GA", "ES-IB", "ES-RI", "ES-MD", "ES-MC", "ES-NC", "ES-AS", "ES-PV", "ES-CB"));
            items.Add(this._catholicProvider.GoodFriday("Viernes Santo", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Lunes de Pascua", year, countryCode).SetLaunchYear(1642).SetCounties("ES-CT", "ES-IB", "ES-RI", "ES-NC", "ES-PV", "ES-VC"));
            items.Add(new PublicHoliday(year, 4, 23, "San Jorge (Día de Aragón)", "Regional Holiday", countryCode, null, new string[] { "ES-AR" }));
            items.Add(new PublicHoliday(year, 4, 23, "Día de Castilla y León", "Regional Holiday", countryCode, null, new string[] { "ES-CL" }));
            items.Add(new PublicHoliday(year, 5, 1, "Fiesta del trabajo", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 17, "Día das Letras Galegas", "Regional Holiday", countryCode, null, new string[] { "ES-GA" }));
            items.Add(new PublicHoliday(year, 5, 31, "Día de la Región Castilla-La Mancha", "Regional Holiday", countryCode, null, new string[] { "ES-CM" }));
            items.Add(this._catholicProvider.CorpusChristi("Corpus Christi", year, countryCode).SetCounties("ES-CM"));
            items.Add(new PublicHoliday(year, 6, 9, "Día de la Región de Murcia", "Regional Holiday", countryCode, null, new string[] { "ES-MC" }));
            items.Add(new PublicHoliday(year, 6, 9, "Día de La Rioja", "Regional Holiday", countryCode, null, new string[] { "ES-RI" }));
            items.Add(new PublicHoliday(year, 6, 24, "Sant Joan", "St. John's Day", countryCode, null, new string[] { "ES-CT", "ES-VC" }));
            items.Add(new PublicHoliday(year, 7, 20, "Fiesta del Sacrificio-Eidul Adha", "Eidul Adha", countryCode, null, new string[] { "ES-CE" }));
            items.Add(new PublicHoliday(year, 7, 21, "Fiesta del Sacrificio-Aid Al Adha", "Aid Al Adha", countryCode, null, new string[] { "ES-ML" }));
            items.Add(new PublicHoliday(year, 7, 28, "Día de las Instituciones de Cantabria", "Regional Holiday", countryCode, null, new string[] { "ES-CB" }));
            items.Add(new PublicHoliday(year, 9, 2, "Día de Ceuta", "Municipal Holiday", countryCode, null, new string[] { "ES-CE" }));
            items.Add(new PublicHoliday(year, 9, 8, "Día de Asturias", "Regional Holiday", countryCode, null, new string[] { "ES-AS" }));
            items.Add(new PublicHoliday(year, 9, 8, "Día de Extremadura", "Regional Holiday", countryCode, null, new string[] { "ES-EX" }));
            items.Add(new PublicHoliday(year, 9, 11, "Diada Nacional de Catalunya", "National Day of Catalonia", countryCode, null, new string[] { "ES-CT" }));
            items.Add(new PublicHoliday(year, 9, 15, "La Bien Aparecida", "Regional Holiday", countryCode, null, new string[] { "ES-CB" }));
            items.Add(new PublicHoliday(year, 10, 9, "Dia de la Comunitat Valenciana", "Regional Holiday", countryCode, null, new string[] { "ES-VC" }));
            items.Add(new PublicHoliday(year, 10, 12, "Fiesta Nacional de España", "Fiesta Nacional de España", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Día de todos los Santos", "All Saints Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 6, "Día de la Constitución", "Constitution Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Inmaculada Concepción", "Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Navidad", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Sant Esteve", "St. Stephen's Day", countryCode, null, new string[] { "ES-CT" }));

            var assumption = this.Assumption(year, countryCode);
            items.Add(assumption);
            var dayOfMadrid = this.DayOfMadrid(year, countryCode);
            items.Add(dayOfMadrid);

            var sanJose = this.SanJose(year, countryCode);
            if (sanJose != null)
            {
                items.Add(sanJose);
            }

            return items.OrderBy(o => o.Date);
        }

        private PublicHoliday Assumption(int year, CountryCode countryCode)
        {
            var date = new DateTime(year, 8, 15).Shift(saturday => saturday, sunday => sunday.AddDays(1));

            return new PublicHoliday(date, "Asunción", "Assumption", countryCode);
        }

        private PublicHoliday DayOfMadrid(int year, CountryCode countryCode)
        {
            var date = new DateTime(year, 5, 2).Shift(saturday => saturday, sunday => sunday.AddDays(1));

            return new PublicHoliday(date, "Fiesta de la Comunidad de Madrid", "Day of Madrid", countryCode, null, new string[] { "ES-MD" });
        }

        private PublicHoliday SanJose(int year, CountryCode countryCode)
        {
            if (year < 2000)
            {
                return null;
            }

            string[] counties;

            switch (year)
            {
                case 2000:
                case 2001:
                case 2002:
                case 2003:
                case 2004:
                case 2005:
                case 2006:
                case 2007:
                case 2008:
                case 2009:
                case 2010:
                case 2011:
                case 2012:
                case 2013:
                case 2014:
                    counties = new string[] { "ES-AR", "ES-CL", "ES-CM", "ES-EX", "ES-GA", "ES-MD", "ES-ML", "ES-PV", "ES-VC" };
                    break;
                case 2015:
                    counties = new string[] { "ES-CM", "ES-MD", "ES-ML", "ES-PV", "ES-VC" };
                    break;
                case 2016:
                    counties = new string[] { "ES-ML", "ES-PV", "ES-VC" };
                    break;
                case 2017:
                    counties = new string[] { "ES-EX", "ES-MD" };
                    break;
                case 2018:
                case 2019:
                    counties = new string[] { "ES-GA", "ES-PV", "ES-VC" };
                    break;
                case 2020:
                    counties = new string[] { "ES-CM", "ES-GA", "ES-PV", "ES-VC" };
                    break;
                case 2021:
                    counties = new string[] { "ES-EX", "ES-GA", "ES-MD", "ES-PV", "ES-VC" };
                    break;
                case 2022:
                    counties = new string[] { "ES-GA", "ES-VC" };
                    break;
                case 2023:
                default:
                    counties = new string[] { "ES-GA", "ES-VC" };
                    break;
            }

            return new PublicHoliday(year, 3, 19, "San José", "St. Joseph's Day", countryCode, null, counties);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Spain",
                "https://www.boe.es/boe/dias/2020/11/02/pdfs/BOE-A-2020-13343.pdf",
                "https://www.boe.es/diario_boe/txt.php?id=BOE-A-2021-17113"
            };
        }
    }
}

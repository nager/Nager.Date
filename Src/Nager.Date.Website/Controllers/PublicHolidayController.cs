using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Nager.Date.Website.Models;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Nager.Date.Website.Controllers
{
    /// <summary>
    /// Public Holiday
    /// </summary>
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class PublicHolidayController : Controller
    {
        [Route("Country/{countrycode}/{year}")]
        [Route("Country/{countrycode}")]
        public IActionResult Country(string countrycode, int year = 0)
        {
            if (year == 0)
            {
                year = DateTime.Now.Year;
            }

            if (!Enum.TryParse(countrycode, true, out CountryCode countryCode))
            {
                return NotFound();
            }

            var country = new Country.CountryProvider().GetCountry(countryCode.ToString());

            var item = new PublicHolidayInfo
            {
                Country = country.CommonName,
                CountryCode = countrycode,
                Year = year
            };

            return View(item);
        }

        [Route("Country/{countrycode}/{year}/csv")]
        public ActionResult DownloadCsv(string countrycode, int year = 0)
        {
            if (year == 0)
            {
                year = DateTime.Now.Year;
            }

            if (!Enum.TryParse(countrycode, true, out CountryCode countryCode))
            {
                return NotFound();
            }

            var items = DateSystem.GetPublicHolidays(year, countryCode).ToList();

            if (items.Count > 0)
            {
                using (var memoryStream = new MemoryStream())
                using (var streamWriter = new StreamWriter(memoryStream))
                using (var csv = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    var csvItems = items.Select(o => new PublicHolidayCsv(o)).ToArray();

                    csv.WriteRecords(csvItems);
                    streamWriter.Flush();

                    var csvData = memoryStream.ToArray();

                    var result = new FileContentResult(csvData, "application/octet-stream")
                    {
                        FileDownloadName = $"publicholiday.{countrycode}.{year}.csv"
                    };

                    return result;
                }
            }

            return NotFound();
        }
    }
}

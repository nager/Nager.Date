using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Nager.Date.WebsiteCore.Model;
using Nager.Date.WebsiteCore.Models;
using System;
using System.IO;
using System.Linq;

namespace Nager.Date.WebsiteCore.Controllers
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

            //if (item.PublicHolidays.Count > 0)
            //{
            //    
            //}

            //return LocalRedirect("/");
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

            var items = DateSystem.GetPublicHoliday(year, countryCode).ToList();

            if (items.Count > 0)
            {
                using (var memoryStream = new MemoryStream())
                using (var streamWriter = new StreamWriter(memoryStream))
                using (var csv = new CsvWriter(streamWriter))
                {
                    csv.WriteRecords(items.Select(o => new PublicHolidayCsv(o)));
                    streamWriter.Flush();

                    var csvData = memoryStream.ToArray();

                    var result = new FileContentResult(csvData, "application/octet-stream");
                    result.FileDownloadName = $"publicholiday.{countrycode}.{year}.csv";
                    return result;
                }
            }

            return NotFound();
        }
    }
}

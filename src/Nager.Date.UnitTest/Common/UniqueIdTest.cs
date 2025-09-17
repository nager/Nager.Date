using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text;

namespace Nager.Date.UnitTest.Common
{
    [TestClass]
    public class UniqueIdTest
    {
        [TestMethod]
        public void HolidayProvider_CheckIdIsUnique()
        {
            var startYear = DateTime.Today.Year - 100;
            var endYear = DateTime.Today.Year + 100;

            foreach (CountryCode countryCode in Enum.GetValues(typeof(CountryCode)))
            {
                var provider = HolidaySystem.GetHolidayProvider(countryCode);

                for (var year = startYear; year <= endYear; year++)
                {
                    var publicHolidays = provider.GetHolidays(year);

                    var holidaysWithId = publicHolidays
                        .Where(holiday => !string.IsNullOrEmpty(holiday.Id));

                    var distinctHolidayIds = holidaysWithId
                        .Select(holiday => holiday.Id).Distinct();

                    var duplicateIds = holidaysWithId.GroupBy(o => o.Id).Where(o => o.Count() > 1).Select(o => o.Key);

                    Assert.AreEqual(holidaysWithId.Count(), distinctHolidayIds.Count(), $"{countryCode} {duplicateIds.Count()} {string.Join(',', duplicateIds)}");
                }
            }
        }

        [TestMethod]
        public void HolidayProvider_CheckIdFormat()
        {
            var startYear = DateTime.Today.Year - 100;
            var endYear = DateTime.Today.Year + 100;

            foreach (CountryCode countryCode in Enum.GetValues(typeof(CountryCode)))
            {
                var provider = HolidaySystem.GetHolidayProvider(countryCode);

                for (var year = startYear; year <= endYear; year++)
                {
                    var publicHolidays = provider.GetHolidays(year);

                    foreach (var holiday in publicHolidays)
                    {
                        if (string.IsNullOrEmpty(holiday.Id))
                        {
                            continue;
                        }

                        var upper = holiday.Id.Replace(" ", "").ToUpper().Normalize(NormalizationForm.FormD);
                        Assert.AreEqual(upper, holiday.Id, StringComparer.Ordinal);

                        var splitChar = holiday.Id[holiday.Id.Length - 3];
                        if (splitChar != '-')
                        {
                            Assert.Fail($"wrong format {countryCode} - {holiday.Id}");
                        }

                        var holidayIdIndex = holiday.Id.AsSpan(holiday.Id.Length - 2);
                        if (!int.TryParse(holidayIdIndex, out var holidayIndex))
                        {
                            Assert.Fail($"wrong format {countryCode} - {holiday.Id}");
                        }

                        if (holidayIndex <= 0)
                        {
                            Assert.Fail($"wrong format {countryCode} - {holiday.Id}");
                        }

                        Assert.IsLessThan(40, holiday.Id.Length, $"{countryCode} - {holiday.Id}");
                    }
                }
            }
        }
    }
}

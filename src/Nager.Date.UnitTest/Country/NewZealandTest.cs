using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Nager.Date.UnitTest.Country;

[TestClass]
public class NewZealandTest
{
    [TestMethod]
    [DataRow(2022, 6, 24, true)]
    [DataRow(2023, 7, 14, true)]
    [DataRow(2024, 6, 28, true)]
    [DataRow(2025, 6, 20, true)]
    [DataRow(2026, 7, 10, true)]
    [DataRow(2027, 6, 25, true)]
    [DataRow(2028, 7, 14, true)]
    [DataRow(2029, 7, 6, true)]
    [DataRow(2030, 6, 21, true)]
    [DataRow(2031, 7, 11, true)]
    [DataRow(2032, 7, 2, true)]
    [DataRow(2033, 6, 24, true)]
    [DataRow(2034, 7, 7, true)]
    [DataRow(2035, 6, 29, true)]
    [DataRow(2036, 7, 18, true)]
    [DataRow(2037, 7, 10, true)]
    [DataRow(2038, 6, 25, true)]
    [DataRow(2039, 7, 15, true)]
    [DataRow(2040, 7, 6, true)]
    [DataRow(2041, 7, 19, true)]
    [DataRow(2042, 7, 11, true)]
    [DataRow(2043, 7, 3, true)]
    [DataRow(2044, 6, 24, true)]
    [DataRow(2045, 7, 7, true)]
    [DataRow(2046, 6, 29, true)]
    [DataRow(2047, 7, 19, true)]
    [DataRow(2048, 7, 3, true)]
    [DataRow(2049, 6, 25, true)]
    [DataRow(2050, 7, 15, true)]
    [DataRow(2051, 6, 30, true)]
    [DataRow(2052, 6, 21, true)]
    public void ChecksIsMatarikiPublicHoliday(int year, int month, int day, bool expected)
    {
        // Arrange
        var date = new DateTime(year, month, day);

        // Act
        var result = DateSystem.IsPublicHoliday(date, CountryCode.NZ);

        // Assert
        Assert.AreEqual(expected, result);
        Assert.AreEqual(DayOfWeek.Friday, date.DayOfWeek);
    }
}

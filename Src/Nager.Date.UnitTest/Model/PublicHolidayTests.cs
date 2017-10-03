
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Model;

namespace Nager.Date.UnitTest.Model
{
    [TestClass]
    public class PublicHolidayTests
    {
        [TestMethod]
        public void ObservedGetsSetToTrue()
        {
            var holiday = new PublicHoliday(2017, 1, 1, "New Years Day", "New Years Day", CountryCode.US, observed: true);

            Assert.IsTrue(holiday.Observed);
        }

        [TestMethod]
        public void ObservedMovesTheDateBackOneDayIfDateIsSaturday()
        {
            var holiday = new PublicHoliday(2017, 1, 7, "Not a Holiday", "Not a Holiday", CountryCode.US, observed: true);

            Assert.AreEqual(6, holiday.Date.Day);
        }

        [TestMethod]
        public void ObservedMovesTheDateForwardOneDayIfDateIsSunday()
        {
            var holiday = new PublicHoliday(2017, 1, 1, "New Years Day", "New Years Day", CountryCode.US, observed: true);
            
            Assert.AreEqual(2, holiday.Date.Day);
        }
    }
}

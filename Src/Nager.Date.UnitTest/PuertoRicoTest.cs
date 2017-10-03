
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.Date.UnitTest
{
    [TestClass]
    public class PuertoRicoTest
    {

        [TestMethod]
        public void PuertoRicoHasGoodFridayHoliday()
        {
            var holidays = DateSystem.GetPublicHoliday(CountryCode.PR, 2017);
            
            var catholic = new MockProvider();
            var expectedGoodFriday = catholic.EasterSunday(2017).AddDays(-2);

            var goodFriday = holidays.First(h => h.Name == "Good Friday");
            Assert.IsNotNull(goodFriday);
            Assert.AreEqual(expectedGoodFriday.Day, goodFriday.Date.Day);
        }
    }
}

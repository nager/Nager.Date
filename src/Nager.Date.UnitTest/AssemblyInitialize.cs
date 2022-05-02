using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.Date.UnitTest
{
    [TestClass]
    internal class AssemblyInitialize
    {
        [AssemblyInitialize]
        public static void MyTestInitialize(TestContext testContext)
        {
            DateSystem.LicenseKey = "Thank you for supporting open source projects";
        }
    }
}

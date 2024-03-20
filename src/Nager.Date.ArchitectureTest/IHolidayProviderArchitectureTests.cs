using ArchUnitNET.Domain;
using ArchUnitNET.MSTestV2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.ArchitectureTest.Internals;
using Nager.Date.HolidayProviders;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace Nager.Date.ArchitectureTest
{
    [TestClass]
    public class IHolidayProviderArchitectureTests
    {
        private static readonly IObjectProvider<Class> _holidayProviders = Classes()
            .That()
            .AreNotAbstract()
            .And()
            .AreAssignableTo(typeof(IHolidayProvider))
            .As("Nager.Date HolidayProvider");

        [TestMethod]
        public void HolidayProvider_Should_Be_Internal()
        {
            var rule = Classes()
                .That()
                .Are(_holidayProviders)
                .Should()
                .BeInternal();

            rule.Check(NagerDateArchitecture.Instance);
        }

        [TestMethod]
        public void HolidayProvider_Should_Be_Sealed()
        {
            var rule = Classes()
                .That()
                .Are(_holidayProviders)
                .Should()
                .BeSealed();

            rule.Check(NagerDateArchitecture.Instance);
        }

        [TestMethod]
        public void HolidayProvider_Should_Reside_In_Namespace()
        {
            var rule = Classes()
                .That()
                .Are(_holidayProviders)
                .Should()
                .ResideInNamespace("Nager.Date.HolidayProviders");

            rule.Check(NagerDateArchitecture.Instance);
        }
    }
}

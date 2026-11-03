using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.MSTestV4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.ArchitectureTest.Internals;
using Nager.Date.HolidayProviders;
using Nager.Date.Models;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace Nager.Date.ArchitectureTest
{
    [TestClass]
    public class ObservedRuleSetArchitectureTests
    {
        private static readonly IObjectProvider<Class> _holidayProviders = Classes()
            .That()
            .AreAssignableTo(typeof(IHolidayProvider))
            .As("Nager.Date HolidayProvider");

        /// <summary>
        /// A HolidayProvider that uses ObservedRuleSet must implement IObservedRuleSetHolidayProvider
        /// </summary>
        private static readonly IArchRule _observedRuleSetRequiresMarkerRule = Classes()
            .That()
            .Are(_holidayProviders)
            .And()
            .DependOnAny(typeof(ObservedRuleSet))
            .Should()
            .ImplementInterface(typeof(IObservedRuleSetHolidayProvider))
            .Because("only holiday providers marked with IObservedRuleSetHolidayProvider are allowed to use ObservedRuleSet");

        /// <summary>
        /// A class that implements IObservedRuleSetHolidayProvider must be a HolidayProvider and must use ObservedRuleSet
        /// </summary>
        private static readonly IArchRule _markerRequiresObservedRuleSetRule = Classes()
            .That()
            .ImplementInterface(typeof(IObservedRuleSetHolidayProvider))
            .Should()
            .Be(_holidayProviders)
            .AndShould()
            .DependOnAny(typeof(ObservedRuleSet))
            .Because("the IObservedRuleSetHolidayProvider marker is only allowed on holiday providers that use ObservedRuleSet");

        [TestMethod]
        public void HolidayProvider_Using_ObservedRuleSet_Should_Implement_IObservedRuleSetHolidayProvider()
        {
            _observedRuleSetRequiresMarkerRule.Check(NagerDateArchitecture.Instance);
        }

        [TestMethod]
        public void IObservedRuleSetHolidayProvider_Should_Only_Be_Implemented_By_HolidayProviders_Using_ObservedRuleSet()
        {
            _markerRequiresObservedRuleSetRule.Check(NagerDateArchitecture.Instance);
        }
    }
}

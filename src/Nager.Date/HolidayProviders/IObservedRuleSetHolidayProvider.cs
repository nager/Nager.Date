using Nager.Date.Models;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Marker interface for holiday providers that are allowed to use <see cref="ObservedRuleSet"/>
    /// </summary>
    /// <remarks>
    /// A holiday provider that uses <see cref="ObservedRuleSet"/> must implement this interface.
    /// This is enforced by the architecture tests in Nager.Date.ArchitectureTest.
    /// </remarks>
    internal interface IObservedRuleSetHolidayProvider
    {
    }
}

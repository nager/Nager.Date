using System.Threading;
using System;
using ArchUnitNET.Domain;
using ArchUnitNET.Loader;

namespace Nager.Date.ArchitectureTest.Internals
{
    internal static class NagerDateArchitecture
    {
        // TIP: load your architecture once at the start to maximize performance of your tests
        private static readonly Lazy<Architecture> _instance = new Lazy<Architecture>(
            () => LoadArchitecture(),
            LazyThreadSafetyMode.PublicationOnly
        );

        public static Architecture Instance => _instance.Value;

        private static Architecture LoadArchitecture()
        {
            var architecture = new ArchLoader().LoadAssembly(typeof(HolidaySystem).Assembly).Build();
            return architecture;
        }
    }
}

using System;

namespace Nager.Date
{
    /// <summary>
    /// No LicenseKey Exception
    /// </summary>
    public class NoLicenseKeyException : Exception
    {
        /// <summary>
        /// No LicenseKey Exception
        /// </summary>
        public NoLicenseKeyException() : base("As a GitHub sponsor of this project you will receive a license key, https://github.com/sponsors/nager")
        {
        }
    }
}

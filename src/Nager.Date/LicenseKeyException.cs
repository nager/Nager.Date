using System;

namespace Nager.Date
{
    /// <summary>
    /// LicenseKey Exception
    /// </summary>
    public class LicenseKeyException : Exception
    {
        /// <summary>
        /// LicenseKey Exception
        /// </summary>
        public LicenseKeyException(string message)
            : base($"{message} - As a GitHub sponsor of this project you will receive a license key, https://github.com/sponsors/nager")
        {
        }
    }
}

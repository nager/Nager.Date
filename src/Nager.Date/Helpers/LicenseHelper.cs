using Nager.LicenseSystem;

namespace Nager.Date.Helpers
{
    /// <summary>
    /// License Helper
    /// </summary>
    public static class LicenseHelper
    {
        /// <summary>
        /// Get License Key Informations
        /// </summary>
        /// <param name="licenseKey"></param>
        /// <returns></returns>
        public static LicenseInfo? CheckLicenseKey(string? licenseKey)
        {
            if (licenseKey == null)
            {
                return null;
            }

            var licenseKeyConfiguration = new LicenseKeyConfiguration
            {
                Part1 = "DCDCB65FD3009576BC11E23C883220F6292709DEB93174D0913D2E89DB3D5D88",
                Part2 = "17F32AEC71CCB3D20166DCC7F49B32C1153464105344608692E005B16284A41D"
            };

            var licenseKeyValidator = new LicenseKeyValidator(licenseKeyConfiguration);
            if (licenseKeyValidator.Validate(licenseKey, out var licenseInfo))
            {
                return licenseInfo;
            }

            return null;
        }
    }
}

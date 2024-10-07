namespace Nager.Date.Models
{
    /// <summary>
    /// License Check Status
    /// </summary>
    internal enum LicenseCheckStatus
    {
        /// <summary>
        /// License key is missing or not configured
        /// </summary>
        NotConfigured,

        /// <summary>
        /// License key has not been checked
        /// </summary>
        NotChecked,

        /// <summary>
        /// License key is invalid
        /// </summary>
        Invalid,

        /// <summary>
        /// License key has expired
        /// </summary>
        Expired,

        /// <summary>
        /// License key is valid
        /// </summary>
        Valid
    }
}

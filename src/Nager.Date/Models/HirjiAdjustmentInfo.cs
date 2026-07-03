namespace Nager.Date.Models
{
    /// <summary>
    /// Represents the adjustment data for the Hijri calendar to align deviations 
    /// between the .NET standard algorithm and the official Diyanet dates.
    /// </summary>
    internal class HijriAdjustmentInfo
    {
        /// <summary>
        /// Gets or sets the correction value (offset) in days for the specific year-month combination.
        /// </summary>
        internal int Offset { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this combination has been officially 
        /// verified and confirmed against the Diyanet calendar data.
        /// </summary>
        internal bool IsVerified { get; set; }
    }
}

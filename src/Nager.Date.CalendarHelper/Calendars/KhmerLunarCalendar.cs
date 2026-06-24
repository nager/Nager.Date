namespace Nager.Date.Calendars
{
    /*
     * Khmer lunar calendar calculations are based on:
     * https://github.com/nhoemchenda/.net-khmer-lunar
     *
     * The original implementation has been significantly adapted and extended
     * to better fit the holiday calculation requirements.
     *
     * Used for calculating Cambodian holidays based on the Khmer lunar calendar.
     */

    public static class KhmerLunarCalendar
    {
        private static readonly Dictionary<int, string> _hsDay = InitializeHsDayEntries();
        private static readonly Dictionary<int, int> _hsYear = InitializeHsYearEntries();

        private static string GetCalendarLeap(int beYear)
        {
            var leap = GetBoditheyLeap(beYear);
            var leapP = GetBoditheyLeap(beYear - 1);

            if (leap.Equals("MD", StringComparison.OrdinalIgnoreCase))
            {
                return "M";
            }

            if (leapP.Equals("MD", StringComparison.OrdinalIgnoreCase))
            {
                return "D";
            }

            return leap;
        }

        private static string GetBoditheyLeap(int beYear)
        {
            // 1. Calculate current year metrics
            var aharkunMod = (beYear * 292207 + 499) % 800;
            var kromthupul = 800 - aharkunMod;
            var isKhmerSolarLeap = kromthupul <= 207;

            // 2. Compute variables for current, next (+1), and previous (-1) year
            var aharkun = (beYear * 292207 + 499) / 800 + 4;
            var avoman = (aharkun * 11 + 25) % 692;

            var aharkun_n = ((beYear + 1) * 292207 + 499) / 800 + 4;
            var avoman_n = (aharkun_n * 11 + 25) % 692;

            var aharkun_p = ((beYear - 1) * 292207 + 499) / 800 + 4;
            var avoman_p = (aharkun_p * 11 + 25) % 692;

            // Determine leap day year rules
            var isLeapDayYear = false;
            if (isKhmerSolarLeap && avoman < 127)
            {
                isLeapDayYear = true;
            }
            else
            {
                if (avoman < 138)
                {
                    isLeapDayYear = true;
                }

                if (avoman == 137 && avoman_n == 0)
                {
                    isLeapDayYear = false;
                }

                if (avoman_p == 138 && avoman == 0)
                {
                    isLeapDayYear = true;
                }
            }

            // Determine leap month rules
            var temp = (aharkun * 11 + 25) / 692;
            var bodithey = (temp + aharkun + 29) % 30;

            var temp_n = (aharkun_n * 11 + 25) / 692;
            var bodithey_n = (temp_n + aharkun_n + 29) % 30;

            var isLeapMonth = false;
            if (bodithey < 6 || bodithey > 24)
            {
                isLeapMonth = true;
            }

            if (bodithey == 24 && bodithey_n == 6)
            {
                isLeapMonth = true;
            }

            if (bodithey == 25 && bodithey_n == 5)
            {
                isLeapMonth = false;
            }

            // Return appropriate leap code
            if (isLeapMonth && isLeapDayYear)
            {
                return "MD";
            }

            if (isLeapMonth)
            {
                return "M";
            }

            if (isLeapDayYear)
            {
                return "D";
            }

            return string.Empty;
        }

        /// <summary>
        /// Get KhmerLunarCode
        /// </summary>
        /// <param name="srcDate"></param>
        /// <returns></returns>
        public static string? GetKhmerLunarCode(DateTime srcDate)
        {
            const int MinDefineYear = 1900;
            const int MaxDefineYear = 2100;

            if (srcDate.Year < MinDefineYear || srcDate.Year > MaxDefineYear)
            {
                return null;
            }

            var beginDate = new DateTime(srcDate.Year, 1, 1);
            var correspondNum = _hsYear[srcDate.Year];

            var yearPath = beginDate.Year + 543;
            var diffDate = srcDate.Subtract(beginDate).Days;
            var cNum = correspondNum;

            // Pre-calculate the leap value ONCE for this year
            var currentLeapYearCheck = beginDate.Year + 544;
            var leap = GetCalendarLeap(currentLeapYearCheck);

            for (var i = 0; i < diffDate; i++)
            {
                cNum++;
                if (cNum == 207 && leap != "D")
                {
                    cNum = 208;
                }

                if (cNum == 208 && leap == "M")
                {
                    cNum = 238;
                }

                if (cNum == 238 && leap != "M")
                {
                    cNum = 298;
                }

                if (cNum == 416)
                {
                    cNum = 1;
                }

                if (cNum == 163)
                {
                    yearPath++;
                }
            }

            var targetDayOfWeek = (srcDate.Year + 4) % 7;
            var baseApril11 = new DateTime(srcDate.Year, 4, 11);
            var baseDayOfWeek = (int)baseApril11.DayOfWeek;

            // Calculate how many days to add to get to the correct weekday
            var daysToAdd = (targetDayOfWeek - baseDayOfWeek + 7) % 7;
            var newYearDay = baseApril11.AddDays(daysToAdd);

            var animalYear = (srcDate >= newYearDay) ? (srcDate.Year + 8) % 12 + 1 : (srcDate.Year + 7) % 12 + 1;
            var sak = (srcDate >= newYearDay) ? (srcDate.Year + 1) % 10 + 1 : (srcDate.Year + 0) % 10 + 1;

            var result = _hsDay[cNum];
            if (result == "07R14" && GetCalendarLeap(srcDate.Year + 544) != "D")
            {
                result += "S";
            }

            return $"{sak:00}{animalYear:00}{yearPath:0000}{result}";
        }

        /// <summary>
        /// Find Gregorian date for cnum
        /// </summary>
        /// <param name="searchYear"></param>
        /// <returns></returns>
        public static DateTime? FindStartDate(int searchYear, int targetCNum)
        {
            // 1. Get the starting cNum for January 1st
            if (!_hsYear.TryGetValue(searchYear, out var cNumAtJan1))
            {
                return null; // Year out of defined range (1900-2100)
            }

            // Get the leap status for this year to apply the correct skipping rules
            var leap = GetCalendarLeap(searchYear + 544);

            var currentCNum = cNumAtJan1;
            var daysDiff = 0;

            // 2. Fast-forward mathematically to day 399
            while (currentCNum != targetCNum)
            {
                currentCNum++;

                // Apply sequence-skipping rules dynamically
                if (currentCNum == 207 && leap != "D")
                {
                    currentCNum = 208;
                }

                if (currentCNum == 208 && leap == "M")
                {
                    currentCNum = 238;
                }

                if (currentCNum == 238 && leap != "M")
                {
                    currentCNum = 298;
                }

                if (currentCNum == 416)
                {
                    currentCNum = 1;
                }

                daysDiff++;

                // Safety brake
                if (daysDiff > 366)
                {
                    return null;
                }
            }

            // 3. Return the exact Gregorian date for the festival start
            return new DateTime(searchYear, 1, 1).AddDays(daysDiff);
        }

        // Internal setup methods to populate the immutable tables once
        private static Dictionary<int, string> InitializeHsDayEntries() => new Dictionary<int, string>
        {
            { 1, "01K01" },
            { 2, "01K02" },
            { 3, "01K03" },
            { 4, "01K04" },
            { 5, "01K05" },
            { 6, "01K06" },
            { 7, "01K07" },
            { 8, "01K08S" },
            { 9, "01K09" },
            { 10, "01K10" },
            { 11, "01K11" },
            { 12, "01K12" },
            { 13, "01K13" },
            { 14, "01K14" },
            { 15, "01K15S" },
            { 16, "01R01" },
            { 17, "01R02" },
            { 18, "01R03" },
            { 19, "01R04" },
            { 20, "01R05" },
            { 21, "01R06" },
            { 22, "01R07" },
            { 23, "01R08S" },
            { 24, "01R09" },
            { 25, "01R10" },
            { 26, "01R11" },
            { 27, "01R12" },
            { 28, "01R13" },
            { 29, "01R14S" },
            { 30, "02K01" },
            { 31, "02K02" },
            { 32, "02K03" },
            { 33, "02K04" },
            { 34, "02K05" },
            { 35, "02K06" },
            { 36, "02K07" },
            { 37, "02K08S" },
            { 38, "02K09" },
            { 39, "02K10" },
            { 40, "02K11" },
            { 41, "02K12" },
            { 42, "02K13" },
            { 43, "02K14" },
            { 44, "02K15S" },
            { 45, "02R01" },
            { 46, "02R02" },
            { 47, "02R03" },
            { 48, "02R04" },
            { 49, "02R05" },
            { 50, "02R06" },
            { 51, "02R07" },
            { 52, "02R08S" },
            { 53, "02R09" },
            { 54, "02R10" },
            { 55, "02R11" },
            { 56, "02R12" },
            { 57, "02R13" },
            { 58, "02R14" },
            { 59, "02R15S" },
            { 60, "03K01" },
            { 61, "03K02" },
            { 62, "03K03" },
            { 63, "03K04" },
            { 64, "03K05" },
            { 65, "03K06" },
            { 66, "03K07" },
            { 67, "03K08S" },
            { 68, "03K09" },
            { 69, "03K10" },
            { 70, "03K11" },
            { 71, "03K12" },
            { 72, "03K13" },
            { 73, "03K14" },
            { 74, "03K15S" },
            { 75, "03R01" },
            { 76, "03R02" },
            { 77, "03R03" },
            { 78, "03R04" },
            { 79, "03R05" },
            { 80, "03R06" },
            { 81, "03R07" },
            { 82, "03R08S" },
            { 83, "03R09" },
            { 84, "03R10" },
            { 85, "03R11" },
            { 86, "03R12" },
            { 87, "03R13" },
            { 88, "03R14S" },
            { 89, "04K01" },
            { 90, "04K02" },
            { 91, "04K03" },
            { 92, "04K04" },
            { 93, "04K05" },
            { 94, "04K06" },
            { 95, "04K07" },
            { 96, "04K08S" },
            { 97, "04K09" },
            { 98, "04K10" },
            { 99, "04K11" },
            { 100, "04K12" },
            { 101, "04K13" },
            { 102, "04K14" },
            { 103, "04K15S" },
            { 104, "04R01" },
            { 105, "04R02" },
            { 106, "04R03" },
            { 107, "04R04" },
            { 108, "04R05" },
            { 109, "04R06" },
            { 110, "04R07" },
            { 111, "04R08S" },
            { 112, "04R09" },
            { 113, "04R10" },
            { 114, "04R11" },
            { 115, "04R12" },
            { 116, "04R13" },
            { 117, "04R14" },
            { 118, "04R15S" },
            { 119, "05K01" },
            { 120, "05K02" },
            { 121, "05K03" },
            { 122, "05K04" },
            { 123, "05K05" },
            { 124, "05K06" },
            { 125, "05K07" },
            { 126, "05K08S" },
            { 127, "05K09" },
            { 128, "05K10" },
            { 129, "05K11" },
            { 130, "05K12" },
            { 131, "05K13" },
            { 132, "05K14" },
            { 133, "05K15S" },
            { 134, "05R01" },
            { 135, "05R02" },
            { 136, "05R03" },
            { 137, "05R04" },
            { 138, "05R05" },
            { 139, "05R06" },
            { 140, "05R07" },
            { 141, "05R08S" },
            { 142, "05R09" },
            { 143, "05R10" },
            { 144, "05R11" },
            { 145, "05R12" },
            { 146, "05R13" },
            { 147, "05R14S" },
            { 148, "06K01" },
            { 149, "06K02" },
            { 150, "06K03" },
            { 151, "06K04" },
            { 152, "06K05" },
            { 153, "06K06" },
            { 154, "06K07" },
            { 155, "06K08S" },
            { 156, "06K09" },
            { 157, "06K10" },
            { 158, "06K11" },
            { 159, "06K12" },
            { 160, "06K13" },
            { 161, "06K14" },
            { 162, "06K15S" },
            { 163, "06R01" },
            { 164, "06R02" },
            { 165, "06R03" },
            { 166, "06R04" },
            { 167, "06R05" },
            { 168, "06R06" },
            { 169, "06R07" },
            { 170, "06R08S" },
            { 171, "06R09" },
            { 172, "06R10" },
            { 173, "06R11" },
            { 174, "06R12" },
            { 175, "06R13" },
            { 176, "06R14" },
            { 177, "06R15S" },
            { 178, "07K01" },
            { 179, "07K02" },
            { 180, "07K03" },
            { 181, "07K04" },
            { 182, "07K05" },
            { 183, "07K06" },
            { 184, "07K07" },
            { 185, "07K08S" },
            { 186, "07K09" },
            { 187, "07K10" },
            { 188, "07K11" },
            { 189, "07K12" },
            { 190, "07K13" },
            { 191, "07K14" },
            { 192, "07K15S" },
            { 193, "07R01" },
            { 194, "07R02" },
            { 195, "07R03" },
            { 196, "07R04" },
            { 197, "07R05" },
            { 198, "07R06" },
            { 199, "07R07" },
            { 200, "07R08S" },
            { 201, "07R09" },
            { 202, "07R10" },
            { 203, "07R11" },
            { 204, "07R12" },
            { 205, "07R13" },
            { 206, "07R14" },
            { 207, "07R15S" },
            { 208, "08K01" },
            { 209, "08K02" },
            { 210, "08K03" },
            { 211, "08K04" },
            { 212, "08K05" },
            { 213, "08K06" },
            { 214, "08K07" },
            { 215, "08K08S" },
            { 216, "08K09" },
            { 217, "08K10" },
            { 218, "08K11" },
            { 219, "08K12" },
            { 220, "08K13" },
            { 221, "08K14" },
            { 222, "08K15S" },
            { 223, "08R01" },
            { 224, "08R02" },
            { 225, "08R03" },
            { 226, "08R04" },
            { 227, "08R05" },
            { 228, "08R06" },
            { 229, "08R07" },
            { 230, "08R08S" },
            { 231, "08R09" },
            { 232, "08R10" },
            { 233, "08R11" },
            { 234, "08R12" },
            { 235, "08R13" },
            { 236, "08R14" },
            { 237, "08R15S" },
            { 238, "09K01" },
            { 239, "09K02" },
            { 240, "09K03" },
            { 241, "09K04" },
            { 242, "09K05" },
            { 243, "09K06" },
            { 244, "09K07" },
            { 245, "09K08S" },
            { 246, "09K09" },
            { 247, "09K10" },
            { 248, "09K11" },
            { 249, "09K12" },
            { 250, "09K13" },
            { 251, "09K14" },
            { 252, "09K15S" },
            { 253, "09R01" },
            { 254, "09R02" },
            { 255, "09R03" },
            { 256, "09R04" },
            { 257, "09R05" },
            { 258, "09R06" },
            { 259, "09R07" },
            { 260, "09R08S" },
            { 261, "09R09" },
            { 262, "09R10" },
            { 263, "09R11" },
            { 264, "09R12" },
            { 265, "09R13" },
            { 266, "09R14" },
            { 267, "09R15S" },
            { 268, "10K01" },
            { 269, "10K02" },
            { 270, "10K03" },
            { 271, "10K04" },
            { 272, "10K05" },
            { 273, "10K06" },
            { 274, "10K07" },
            { 275, "10K08S" },
            { 276, "10K09" },
            { 277, "10K10" },
            { 278, "10K11" },
            { 279, "10K12" },
            { 280, "10K13" },
            { 281, "10K14" },
            { 282, "10K15S" },
            { 283, "10R01" },
            { 284, "10R02" },
            { 285, "10R03" },
            { 286, "10R04" },
            { 287, "10R05" },
            { 288, "10R06" },
            { 289, "10R07" },
            { 290, "10R08S" },
            { 291, "10R09" },
            { 292, "10R10" },
            { 293, "10R11" },
            { 294, "10R12" },
            { 295, "10R13" },
            { 296, "10R14" },
            { 297, "10R15S" },
            { 298, "11K01" },
            { 299, "11K02" },
            { 300, "11K03" },
            { 301, "11K04" },
            { 302, "11K05" },
            { 303, "11K06" },
            { 304, "11K07" },
            { 305, "11K08S" },
            { 306, "11K09" },
            { 307, "11K10" },
            { 308, "11K11" },
            { 309, "11K12" },
            { 310, "11K13" },
            { 311, "11K14" },
            { 312, "11K15S" },
            { 313, "11R01" },
            { 314, "11R02" },
            { 315, "11R03" },
            { 316, "11R04" },
            { 317, "11R05" },
            { 318, "11R06" },
            { 319, "11R07" },
            { 320, "11R08S" },
            { 321, "11R09" },
            { 322, "11R10" },
            { 323, "11R11" },
            { 324, "11R12" },
            { 325, "11R13" },
            { 326, "11R14S" },
            { 327, "12K01" },
            { 328, "12K02" },
            { 329, "12K03" },
            { 330, "12K04" },
            { 331, "12K05" },
            { 332, "12K06" },
            { 333, "12K07" },
            { 334, "12K08S" },
            { 335, "12K09" },
            { 336, "12K10" },
            { 337, "12K11" },
            { 338, "12K12" },
            { 339, "12K13" },
            { 340, "12K14" },
            { 341, "12K15S" },
            { 342, "12R01" },
            { 343, "12R02" },
            { 344, "12R03" },
            { 345, "12R04" },
            { 346, "12R05" },
            { 347, "12R06" },
            { 348, "12R07" },
            { 349, "12R08S" },
            { 350, "12R09" },
            { 351, "12R10" },
            { 352, "12R11" },
            { 353, "12R12" },
            { 354, "12R13" },
            { 355, "12R14" },
            { 356, "12R15S" },
            { 357, "13K01" },
            { 358, "13K02" },
            { 359, "13K03" },
            { 360, "13K04" },
            { 361, "13K05" },
            { 362, "13K06" },
            { 363, "13K07" },
            { 364, "13K08S" },
            { 365, "13K09" },
            { 366, "13K10" },
            { 367, "13K11" },
            { 368, "13K12" },
            { 369, "13K13" },
            { 370, "13K14" },
            { 371, "13K15S" },
            { 372, "13R01" },
            { 373, "13R02" },
            { 374, "13R03" },
            { 375, "13R04" },
            { 376, "13R05" },
            { 377, "13R06" },
            { 378, "13R07" },
            { 379, "13R08S" },
            { 380, "13R09" },
            { 381, "13R10" },
            { 382, "13R11" },
            { 383, "13R12" },
            { 384, "13R13" },
            { 385, "13R14S" },
            { 386, "14K01" },
            { 387, "14K02" },
            { 388, "14K03" },
            { 389, "14K04" },
            { 390, "14K05" },
            { 391, "14K06" },
            { 392, "14K07" },
            { 393, "14K08S" },
            { 394, "14K09" },
            { 395, "14K10" },
            { 396, "14K11" },
            { 397, "14K12" },
            { 398, "14K13" },
            { 399, "14K14" },
            { 400, "14K15S" },
            { 401, "14R01" },
            { 402, "14R02" },
            { 403, "14R03" },
            { 404, "14R04" },
            { 405, "14R05" },
            { 406, "14R06" },
            { 407, "14R07" },
            { 408, "14R08S" },
            { 409, "14R09" },
            { 410, "14R10" },
            { 411, "14R11" },
            { 412, "14R12" },
            { 413, "14R13" },
            { 414, "14R14" },
            { 415, "14R15S" }
        };

        private static Dictionary<int, int> InitializeHsYearEntries() => new Dictionary<int, int>
        {
            { 1900, 30 },
            { 1901, 41 },
            { 1902, 22 },
            { 1903, 32 },
            { 1904, 43 },
            { 1905, 25 },
            { 1906, 36 },
            { 1907, 46 },
            { 1908, 27 },
            { 1909, 39 },
            { 1910, 20 },
            { 1911, 31 },
            { 1912, 41 },
            { 1913, 23 },
            { 1914, 34 },
            { 1915, 45 },
            { 1916, 26 },
            { 1917, 38 },
            { 1918, 48 },
            { 1919, 29 },
            { 1920, 40 },
            { 1921, 22 },
            { 1922, 33 },
            { 1923, 43 },
            { 1924, 24 },
            { 1925, 36 },
            { 1926, 47 },
            { 1927, 28 },
            { 1928, 38 },
            { 1929, 20 },
            { 1930, 31 },
            { 1931, 42 },
            { 1932, 23 },
            { 1933, 34 },
            { 1934, 45 },
            { 1935, 26 },
            { 1936, 37 },
            { 1937, 49 },
            { 1938, 30 },
            { 1939, 40 },
            { 1940, 21 },
            { 1941, 33 },
            { 1942, 44 },
            { 1943, 25 },
            { 1944, 35 },
            { 1945, 47 },
            { 1946, 28 },
            { 1947, 39 },
            { 1948, 20 },
            { 1949, 31 },
            { 1950, 42 },
            { 1951, 23 },
            { 1952, 34 },
            { 1953, 46 },
            { 1954, 27 },
            { 1955, 37 },
            { 1956, 48 },
            { 1957, 30 },
            { 1958, 41 },
            { 1959, 22 },
            { 1960, 32 },
            { 1961, 44 },
            { 1962, 25 },
            { 1963, 36 },
            { 1964, 46 },
            { 1965, 28 },
            { 1966, 39 },
            { 1967, 20 },
            { 1968, 31 },
            { 1969, 42 },
            { 1970, 23 },
            { 1971, 34 },
            { 1972, 45 },
            { 1973, 27 },
            { 1974, 37 },
            { 1975, 48 },
            { 1976, 29 },
            { 1977, 41 },
            { 1978, 22 },
            { 1979, 32 },
            { 1980, 43 },
            { 1981, 25 },
            { 1982, 36 },
            { 1983, 47 },
            { 1984, 28 },
            { 1985, 39 },
            { 1986, 20 },
            { 1987, 31 },
            { 1988, 42 },
            { 1989, 24 },
            { 1990, 34 },
            { 1991, 45 },
            { 1992, 26 },
            { 1993, 38 },
            { 1994, 19 },
            { 1995, 29 },
            { 1996, 40 },
            { 1997, 22 },
            { 1998, 33 },
            { 1999, 44 },
            { 2000, 25 },
            { 2001, 36 },
            { 2002, 47 },
            { 2003, 28 },
            { 2004, 39 },
            { 2005, 21 },
            { 2006, 31 },
            { 2007, 42 },
            { 2008, 23 },
            { 2009, 35 },
            { 2010, 45 },
            { 2011, 26 },
            { 2012, 37 },
            { 2013, 19 },
            { 2014, 30 },
            { 2015, 41 },
            { 2016, 22 },
            { 2017, 33 },
            { 2018, 44 },
            { 2019, 25 },
            { 2020, 36 },
            { 2021, 47 },
            { 2022, 28 },
            { 2023, 39 },
            { 2024, 20 },
            { 2025, 32 },
            { 2026, 42 },
            { 2027, 23 },
            { 2028, 34 },
            { 2029, 46 },
            { 2030, 27 },
            { 2031, 37 },
            { 2032, 18 },
            { 2033, 30 },
            { 2034, 41 },
            { 2035, 22 },
            { 2036, 32 },
            { 2037, 44 },
            { 2038, 25 },
            { 2039, 36 },
            { 2040, 47 },
            { 2041, 29 },
            { 2042, 39 },
            { 2043, 20 },
            { 2044, 31 },
            { 2045, 43 },
            { 2046, 24 },
            { 2047, 34 },
            { 2048, 45 },
            { 2049, 27 },
            { 2050, 38 },
            { 2051, 19 },
            { 2052, 29 },
            { 2053, 41 },
            { 2054, 22 },
            { 2055, 33 },
            { 2056, 44 },
            { 2057, 26 },
            { 2058, 36 },
            { 2059, 47 },
            { 2060, 28 },
            { 2061, 40 },
            { 2062, 21 },
            { 2063, 31 },
            { 2064, 42 },
            { 2065, 24 },
            { 2066, 35 },
            { 2067, 45 },
            { 2068, 26 },
            { 2069, 38 },
            { 2070, 19 },
            { 2071, 30 },
            { 2072, 40 },
            { 2073, 22 },
            { 2074, 33 },
            { 2075, 44 },
            { 2076, 25 },
            { 2077, 36 },
            { 2078, 47 },
            { 2079, 28 },
            { 2080, 39 },
            { 2081, 21 },
            { 2082, 32 },
            { 2083, 42 },
            { 2084, 23 },
            { 2085, 35 },
            { 2086, 46 },
            { 2087, 27 },
            { 2088, 37 },
            { 2089, 19 },
            { 2090, 30 },
            { 2091, 41 },
            { 2092, 22 },
            { 2093, 33 },
            { 2094, 44 },
            { 2095, 25 },
            { 2096, 36 },
            { 2097, 48 },
            { 2098, 29 },
            { 2099, 39 },
            { 2100, 20 }
        };
    }
}

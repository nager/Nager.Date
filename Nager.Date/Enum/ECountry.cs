using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Nager.Date.Enum
{
    public enum ECountry : byte
    {
        [Description("CH")]
        CH = 1,
        [Description("BE")]
        BE = 2,
        [Description("AT")]
        AT = 3,
        [Description("DE")]
        DE = 4,
        [Description("ES")]
        ES = 5,
        [Description("FR")]
        FR = 6,
        [Description("IT")]
        IT = 7,
        [Description("LI")]
        LI = 8,
        [Description("NL")]
        NL = 9
    }
}

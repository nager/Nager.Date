using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Nager.Date.Website.Helper
{
    internal class IPComparer : EqualityComparer<byte[]>
    {
        public override bool Equals(byte[] x, byte[] y)
        {
            if (x == null || y == null)
            {
                return false;
            }
            if (x.Length == y.Length)
            {
                return ((ReadOnlySpan<byte>)x).SequenceEqual(y);
            }
            if (x.Length == 4 && y.Length == 16)
            {
                return CompareIP4ToIP6(x, y);
            }
            if (x.Length == 16 && y.Length == 4)
            {
                return CompareIP4ToIP6(y, x);
            }
            return false;
        }

        public override int GetHashCode([DisallowNull] byte[] obj)
        {
            return BitConverter.ToInt32(obj, obj.Length - 4);
        }

        private static bool CompareIP4ToIP6(byte[] ip4, byte[] ip6)
        {
            if (!new ReadOnlySpan<byte>(ip6, 12, 4).SequenceEqual(ip4))
            {
                return false;
            }
            for (var i = 11; i >= 0; --i)
            {
                if (ip6[i] != default(byte))
                {
                    return false;
                }
            }
            return true;
        }
        
    }
}

using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Platform.Comparers.Generic.Equality
{
    public class UInt64EqualityComparer : EqualityComparer<ulong>
    {
        static UInt64EqualityComparer() => GenericEqualityComparer<ulong>.Default = new UInt64EqualityComparer();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(ulong x, ulong y) => x == y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode(ulong obj) => obj.GetHashCode();
    }
}
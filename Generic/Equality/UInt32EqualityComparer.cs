using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Platform.Comparers.Generic.Equality
{
    public class UInt32EqualityComparer : EqualityComparer<uint>
    {
        static UInt32EqualityComparer() => GenericEqualityComparer<uint>.Default = new UInt32EqualityComparer();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(uint x, uint y) => x == y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode(uint obj) => obj.GetHashCode();
    }
}
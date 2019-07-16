using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Platform.Comparers.Generic.Equality
{
    public class UInt16EqualityComparer : EqualityComparer<ushort>
    {
        static UInt16EqualityComparer() => GenericEqualityComparer<ushort>.Default = new UInt16EqualityComparer();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(ushort x, ushort y) => x == y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode(ushort obj) => obj.GetHashCode();
    }
}
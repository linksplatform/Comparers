using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Platform.Comparers.Generic.Equality
{
    public class Int64EqualityComparer : EqualityComparer<long>
    {
        static Int64EqualityComparer() => GenericEqualityComparer<long>.Default = new Int64EqualityComparer();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(long x, long y) => x == y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode(long obj) => obj.GetHashCode();
    }
}
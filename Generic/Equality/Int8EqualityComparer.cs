using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Platform.Comparers.Generic.Equality
{
    public class Int8EqualityComparer : EqualityComparer<sbyte>
    {
        static Int8EqualityComparer() => GenericEqualityComparer<sbyte>.Default = new Int8EqualityComparer();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(sbyte x, sbyte y) => x == y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode(sbyte obj) => obj.GetHashCode();
    }
}
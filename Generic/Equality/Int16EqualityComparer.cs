using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Platform.Comparers.Generic.Equality
{
    public class Int16EqualityComparer : EqualityComparer<short>
    {
        static Int16EqualityComparer() => GenericEqualityComparer<short>.Default = new Int16EqualityComparer();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(short x, short y) => x == y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode(short obj) => obj.GetHashCode();
    }
}
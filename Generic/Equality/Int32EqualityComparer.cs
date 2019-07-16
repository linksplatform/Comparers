using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Platform.Comparers.Generic.Equality
{
    public class Int32EqualityComparer : EqualityComparer<int>
    {
        static Int32EqualityComparer() => GenericEqualityComparer<int>.Default = new Int32EqualityComparer();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(int x, int y) => x == y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode(int obj) => obj.GetHashCode();
    }
}
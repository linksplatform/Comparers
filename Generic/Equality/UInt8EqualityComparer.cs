using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Platform.Comparers.Generic.Equality
{
    public class UInt8EqualityComparer : EqualityComparer<byte>
    {
        static UInt8EqualityComparer() => GenericEqualityComparer<byte>.Default = new UInt8EqualityComparer();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(byte x, byte y) => x == y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode(byte obj) => obj.GetHashCode();
    }
}
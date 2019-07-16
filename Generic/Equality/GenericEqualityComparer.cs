using System.Collections.Generic;

namespace Platform.Comparers.Generic.Equality
{
    public static class GenericEqualityComparer<T>
    {
        public static EqualityComparer<T> Default { get; set; }

        static GenericEqualityComparer() => Default = EqualityComparer<T>.Default;
    }
}
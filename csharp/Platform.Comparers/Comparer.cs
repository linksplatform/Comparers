using System;
using System.Collections;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Comparers
{
    /// <summary>
    /// <para>
    /// Represents the comparer.
    /// </para>
    /// <para></para>
    /// </summary>
    /// <seealso cref="IComparer"/>
    public class Comparer : IComparer
    {
        /// <summary>
        /// <para>
        /// The compare.
        /// </para>
        /// <para></para>
        /// </summary>
        private readonly Func<object, object, int> _compare;
        /// <summary>
        /// <para>
        /// Initializes a new <see cref="Comparer"/> instance.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="comparer">
        /// <para>A comparer.</para>
        /// <para></para>
        /// </param>
        public Comparer(IComparer comparer) : this(comparer.Compare) { }
        /// <summary>
        /// <para>
        /// Initializes a new <see cref="Comparer"/> instance.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="compare">
        /// <para>A compare.</para>
        /// <para></para>
        /// </param>
        public Comparer(Func<object, object, int> compare) => _compare = compare;
        /// <summary>
        /// <para>
        /// Compares the x.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="x">
        /// <para>The .</para>
        /// <para></para>
        /// </param>
        /// <param name="y">
        /// <para>The .</para>
        /// <para></para>
        /// </param>
        /// <returns>
        /// <para>The int</para>
        /// <para></para>
        /// </returns>
        public int Compare(object x, object y) => _compare(x, y);
        public static implicit operator Comparer(Func<object, object, int> compare) => new Comparer(compare);
        public static implicit operator Func<object, object, int>(Comparer comparer) => comparer._compare;
    }
}
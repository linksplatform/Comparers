using System;
using Xunit;

namespace Platform.Comparers.Tests
{
    public class ComparerTests
    {
        [Fact]
        public void FunctionConversionTest()
        {
            Func<object, object, int> function = (object x, object y) => x.GetHashCode().CompareTo(y.GetHashCode();
            Comparer comparer = function;
            var x = new object();
            var y = new object();
            Assert.Equal(function(x, y), comparer.Compare(x, y));
        }
    }
}

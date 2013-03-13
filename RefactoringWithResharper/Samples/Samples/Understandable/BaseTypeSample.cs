namespace Samples.Understandable
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class BaseTypeSample : AssertionHelper
    {
        [Test]
        public void Sample()
        {
            var list = new List<string> {"a", "b", "c"};

            var length = GetLength(list);

            Expect(length, Is.EqualTo(3));
        }

        private int GetLength<T>(List<T> items)
        {
            return items.Count();
        }

        // apply use Base Type refactoring (Alt + Enter)
    }
}
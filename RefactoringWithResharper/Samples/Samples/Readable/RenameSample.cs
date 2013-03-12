namespace Samples.Readable
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class RenameSample : AssertionHelper
    {
        [Test]
        public void Sample()
        {
            var list = GetData();

            var result = GetResult(list);

            Expect(result, Is.EqualTo(6));
        }

        private static int GetResult(IList<Tree> list)
        {
            var total = 0;

            for (var i = 0; i < list.Count(); i++)
            {
                total += list[i].Age;
            }

            return total/list.Count();
        }

        private static Tree[] GetData()
        {
            return new[]
                {
                    new Tree(5),
                    new Tree(6),
                    new Tree(7)
                };
        }

        public class Tree
        {
            public int Age { get; set; }

            public Tree(int age)
            {
                Age = age;
            }
        }
    }

    // Rename methods
    // Rename variables
}
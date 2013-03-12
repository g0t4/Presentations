//namespace Samples.Readable
//{
//    using System.Collections.Generic;
//    using System.Linq;
//    using NUnit.Framework;

//    [TestFixture]
//    public class RenameSampleGoal : AssertionHelper
//    {
//        [Test]
//        public void Sample()
//        {
//            var trees = GetTrees();

//            var averageAge = GetAverageAge(trees);

//            Expect(averageAge, Is.EqualTo(6));
//        }

//        private static int GetAverageAge(IList<Tree> trees)
//        {
//            var totalTreeAge = 0;

//            for (var index = 0; index < trees.Count(); index++)
//            {
//                totalTreeAge += trees[index].Age;
//            }

//            return totalTreeAge/trees.Count();
//        }

//        private static Tree[] GetTrees()
//        {
//            return new[]
//                {
//                    new Tree(5),
//                    new Tree(6),
//                    new Tree(7)
//                };
//        }

//        public class Tree
//        {
//            public int Age { get; set; }

//            public Tree(int age)
//            {
//                Age = age;
//            }
//        }
//    }
//}
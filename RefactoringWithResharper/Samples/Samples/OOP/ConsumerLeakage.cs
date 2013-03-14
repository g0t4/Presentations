namespace Samples.OOP
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class ConsumerLeakage : AssertionHelper
    {
        [Test]
        public void Sample()
        {
            var person = new Person {BirthDate = DateTime.Today.AddYears(-30)};
            var fossil = new Fossil {AmountOfCarbon = 50};
            var tree = new Tree {Rings = 20};

            Expect(Age(person), Is.EqualTo(30));
            Expect(Age(fossil), Is.EqualTo(10));
            Expect(Age(tree), Is.EqualTo(20));
        }

        private object Age(object thing)
        {
            if (thing is Person)
            {
                var person = thing as Person;
                var today = DateTime.Today;
                var age = today.Year - person.BirthDate.Year;
                if (person.BirthDate > today.AddYears(-age)) age--;
                return age;
            }
            if (thing is Fossil)
            {
                var fossil = thing as Fossil;
                return fossil.AmountOfCarbon/5;
            }
            var tree = thing as Tree;
            return tree.Rings;
        }
    }

    public class Person
    {
        public DateTime BirthDate { get; set; }
    }

    public class Fossil
    {
        public int AmountOfCarbon { get; set; }
    }

    public class Tree
    {
        public int Rings { get; set; }
    }

    // Extract method per type and move to the type itself
    // Extract an abstract interface or class for IHaveAge or Creature
    // Now if new creatures are defined this will be required to be implemented
    // Reuse!
}
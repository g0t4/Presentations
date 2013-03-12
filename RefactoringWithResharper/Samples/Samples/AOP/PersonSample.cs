namespace Samples
{
    using NUnit.Framework;

    [TestFixture]
    public class PersonSample : AssertionHelper
    {
        [Test]
        public void Sample()
        {
            var person = new Person("bob", "jones");

            var fullname = person.LastName + ", " + person.FirstName;

            Expect(fullname, Is.EqualTo("jones, bob"));
        }

        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public Person(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }
        }

        // Run test case - passes?
        // Extract method
        // Move to another type (Person) (dont set public right away let R# warn and show that step), then go back and set public
        // Make non static
        // Cleanup - inline result
        // Run test case - passes?

        // Encapsulation producer/consumer concerns
    }
}
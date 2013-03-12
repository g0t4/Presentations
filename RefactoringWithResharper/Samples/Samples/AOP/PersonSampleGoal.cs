//namespace Samples
//{
//    using NUnit.Framework;

//    [TestFixture]
//    public class PersonSampleGoal : AssertionHelper
//    {
//        [Test]
//        public void Sample()
//        {
//            var person = new Person("bob", "jones");

//            var fullname = person.Fullname();

//            Expect(fullname, Is.EqualTo("jones, bob"));
//        }

//        public class Person
//        {
//            public string FirstName { get; set; }
//            public string LastName { get; set; }

//            public Person(string firstName, string lastName)
//            {
//                FirstName = firstName;
//                LastName = lastName;
//            }

//            public string Fullname()
//            {
//                return LastName + ", " + FirstName;
//            }
//        }
//    }
//}


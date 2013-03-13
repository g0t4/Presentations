//namespace Samples.BoyScout
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using NUnit.Framework;

//    [TestFixture]
//    public class QueryObjectsGoal : AssertionHelper
//    {
//        [Test]
//        public void Sample()
//        {
//            var query = new AccountQueryGoal
//                {
//                    NameContains = "bob",
//                    Active = true
//                };
//            var allAccounts = GetAllAccounts();
//            var filteredAccounts = query.Filter(allAccounts);
//        }

//        private static IEnumerable<Account> GetAllAccounts()
//        {
//            return Enumerable.Empty<Account>();
//        }

//        public class Account
//        {
//            public DateTime Opened { get; set; }
//            public string Name { get; set; }
//            public bool Active { get; set; }
//        }
//    }
//}
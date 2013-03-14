namespace Samples.BoyScout
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class QueryObjects : AssertionHelper
    {
        [Test]
        public void Sample()
        {
            var filteredAccounts = QueryAccounts("bob", null, true);
        }

        public IEnumerable<Account> QueryAccounts(string nameContains, DateTime? openedAfter, bool? active)
        {
            var accounts = GetAllAccounts();
            if (nameContains != null)
            {
                accounts = accounts.Where(n => n.Name.Contains(nameContains));
            }
            if (openedAfter.HasValue)
            {
                accounts = accounts.Where(a => a.Opened > openedAfter);
            }
            if (active.HasValue)
            {
                accounts = accounts.Where(a => a.Active == active);
            }
            return accounts;
        }

        private static IEnumerable<Account> GetAllAccounts()
        {
            return Enumerable.Empty<Account>();
        }

        public class Account
        {
            public DateTime Opened { get; set; }
            public string Name { get; set; }
            public bool Active { get; set; }
            public bool IsPreferred { get; set; }
        }

        // extract class from parameters
        // make auto props
        // take out ctor and manually assign each parameter
        // READABILITY :)
        // composition with linq, move filter to query object too.
        // extract method for filter conditions, call Filter
        // move to query params
        // make not static
        // rename query params to maybe AccountQuery, all the parameters and logic are encapsulate in a neat package
        // move to outer scope (Ctrl+Shift+R)
        // move to another file

        // consider inlining integration method of GetAllAccounts and Filter call, can't a query object be a service?

        // Expansion joint: use a new test case and add another filter criteria for IsPreferred
    }
}
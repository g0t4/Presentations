//namespace Samples.BoyScout
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;

//    public class AccountQueryGoal
//    {
//        public string NameContains { get; set; }

//        public DateTime? OpenedAfter { get; set; }

//        public bool? Active { get; set; }

//        public IEnumerable<QueryObjectsGoal.Account> Filter(IEnumerable<QueryObjectsGoal.Account> accounts)
//        {
//            if (NameContains != null)
//            {
//                accounts = accounts.Where(n => n.Name.Contains(NameContains));
//            }
//            if (OpenedAfter.HasValue)
//            {
//                accounts = accounts.Where(a => a.Opened > OpenedAfter);
//            }
//            if (Active.HasValue)
//            {
//                accounts = accounts.Where(a => a.Active == Active);
//            }
//            return accounts;
//        }
//    }
//}
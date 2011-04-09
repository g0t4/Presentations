namespace Refactoring
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;
	using NUnit.Framework;

	public class Readability
	{
		public static void IsHighlyUnderrated()
		{
		}

		public class WhatDoTheseDo
		{
			[Test]
			public void WhatDoesThisDo()
			{
				var list = new List<string> {"bob@bob.com", "bob@dan.com", "jane@bob.com", "dan@dan.com"};
				var groups = new Dictionary<string, List<string>>();
				for (var i = 0; i < list.Count; i++)
				{
					var m = Regex.Matches(list[i], @"[^@]*@(.*)")[0];
					var g = m.Groups[1].Value;
					if (!groups.ContainsKey(g))
					{
						groups.Add(g, new List<string> {list[i]});
					}
					else
					{
						groups[g].Add(list[i]);
					}
				}
				foreach (var k in groups.Keys)
				{
					Console.WriteLine(k + ":");
					for (var i = 0; i < groups[k].Count; i++)
					{
						Console.WriteLine(groups[k][i]);
					}
					Console.WriteLine();
				}
			}

			#region How about this way

			[Test]
			public void HowAboutThisWay()
			{
				GetEmails()
					.GroupBy(GetDomain)
					.Run(emailsInDomain => PrintEmailsForDomain(emailsInDomain.Key, emailsInDomain));
			}

			private List<string> GetEmails()
			{
				return new List<string> { "bob@bob.com", "bob@dan.com", "jane@bob.com", "dan@dan.com" };
			}

			private string GetDomain(string email)
			{
				var split = Regex.Matches(email, @"[^@]*@(.*)")[0];
				return split.Groups[1].Value;
			}

			private void PrintEmailsForDomain(string domain, IEnumerable<string> emailsInDomain)
			{
				Console.WriteLine(domain + ":");
				emailsInDomain
					.Run(Console.WriteLine);
				Console.WriteLine();
			}

			#endregion
		}
	}
}
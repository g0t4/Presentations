namespace Refactoring.Strategies
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;
	using NUnit.Framework;

	public class PatienceAnd
	{
		public static void Scouting()
		{
		}

		/*
		 * Boy scouts
		 *	Always leave the campground cleaner than you found it.
		 *	Everytime you work on code pick up some trash!
		 * 
		 * DVCS and checkins - don't interrupt others, small steps
		 * 
		 */

		[Test]
		public void Patience()
		{
			List<string> list = new List<string> { "bob@bob.com", "bob@dan.com", "jane@bob.com", "dan@dan.com" };
			Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();
			for (var i = 0; i < list.Count; i++)
			{
				Match m = Regex.Matches(list[i], @"[^@]*@(.*)")[0];
				string g = m.Groups[1].Value;
				if (!groups.ContainsKey(g))
				{
					groups.Add(g, new List<string> { list[i] });
				}
				else
				{
					groups[g].Add(list[i]);
				}
			}
			foreach (string k in groups.Keys)
			{
				Console.WriteLine(k + ":");
				for (int i = 0; i < groups[k].Count; i++)
				{
					Console.WriteLine(groups[k][i]);
				}
				Console.WriteLine();
			}
		}	
	}

	[TestFixture]
	public class Patience
	{
		[Test]
		public void PrintEmailsGroupedByDomain()
		{
			List<string> emails = new List<string> { "bob@bob.com", "jane@bob.com", "dan@dan.com" };
			Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();
			for (int i = 0; i < emails.Count(); i++)
			{
				Match split = Regex.Matches(emails[i], @"[^@]*@(.*)")[0];
				string domain = split.Groups[1].Value;
				if (!groups.ContainsKey(domain))
				{
					groups.Add(domain, new List<string> { emails[i] });
				}
				else
				{
					groups[domain].Add(emails[i]);
				}
			}
			foreach (var key in groups.Keys)
			{
				Console.WriteLine("Emails for domain: " + key);
				for (int i = 0; i < groups[key].Count; i++)
				{
					Console.WriteLine(groups[key][i]);
				}
				Console.WriteLine();
			}
		}

		[Test]
		public void PrintEmailsGroupedByDomain_CleanupWithResharper()
		{
			var emails = new List<string> { "bob@bob.com", "jane@bob.com", "dan@dan.com" };
			var groups = new Dictionary<string, List<string>>();
			for (var i = 0; i < emails.Count(); i++)
			{
				var split = Regex.Matches(emails[i], @"[^@]*@(.*)")[0];
				var domain = split.Groups[1].Value;
				if (!groups.ContainsKey(domain))
				{
					groups.Add(domain, new List<string> { emails[i] });
				}
				else
				{
					groups[domain].Add(emails[i]);
				}
			}
			foreach (var key in groups.Keys)
			{
				Console.WriteLine("Emails for domain: " + key);
				for (var i = 0; i < groups[key].Count; i++)
				{
					Console.WriteLine(groups[key][i]);
				}
				Console.WriteLine();
			}
		}

		[Test]
		public void PrintEmailsGroupedByDomain_ExtractLocalVariablesResharper()
		{
			var emails = new List<string> { "bob@bob.com", "jane@bob.com", "dan@dan.com" };
			var groups = new Dictionary<string, List<string>>();
			for (var i = 0; i < emails.Count(); i++)
			{
				var email = emails[i];
				var split = Regex.Matches(email, @"[^@]*@(.*)")[0];
				var domain = split.Groups[1].Value;
				if (!groups.ContainsKey(domain))
				{
					groups.Add(domain, new List<string> { email });
				}
				else
				{
					groups[domain].Add(email);
				}
			}
			foreach (var key in groups.Keys)
			{
				Console.WriteLine("Emails for domain: " + key);
				var emailsInDomain = groups[key];
				for (var i = 0; i < emailsInDomain.Count; i++)
				{
					Console.WriteLine(emailsInDomain[i]);
				}
				Console.WriteLine();
			}
		}

		[Test]
		public void PrintEmailsGroupedByDomain_RenameVariablesAndForeach()
		{
			var emails = new List<string> { "bob@bob.com", "jane@bob.com", "dan@dan.com" };
			var domains = new Dictionary<string, List<string>>();
			foreach (var email in emails)
			{
				var split = Regex.Matches(email, @"[^@]*@(.*)")[0];
				var domain = split.Groups[1].Value;
				if (!domains.ContainsKey(domain))
				{
					domains.Add(domain, new List<string> { email });
				}
				else
				{
					domains[domain].Add(email);
				}
			}
			foreach (var domain in domains.Keys)
			{
				Console.WriteLine("Emails for domain: " + domain);
				var emailsInDomain = domains[domain];
				foreach (var email in emailsInDomain)
				{
					Console.WriteLine(email);
				}
				Console.WriteLine();
			}
		}

		[Test]
		public void PrintEmailsGroupedByDomain_ExtractMethodsUnrelatedWithResharper()
		{
			var emails = GetEmails();
			var domains = new Dictionary<string, List<string>>();
			foreach (var email in emails)
			{
				var domain = GetDomain(email);
				if (!domains.ContainsKey(domain))
				{
					domains.Add(domain, new List<string> { email });
				}
				else
				{
					domains[domain].Add(email);
				}
			}
			foreach (var domain in domains.Keys)
			{
				var emailsInDomain = domains[domain];
				PrintEmailsForDomain(domain, emailsInDomain);
			}
		}

		private void PrintEmailsForDomain(string domain, IEnumerable<string> emailsInDomain)
		{
			Console.WriteLine("Emails for domain: " + domain);
			foreach (var email in emailsInDomain)
			{
				Console.WriteLine(email);
			}
			Console.WriteLine();
		}

		/// <summary>
		/// This can easily be tested now, independently!
		/// Potential for reuse... :P
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		private string GetDomain(string email)
		{
			var split = Regex.Matches(email, @"[^@]*@(.*)")[0];
			return split.Groups[1].Value;
		}

		/// <summary>
		/// This source can more easily be stubbed for testing, if necessary
		/// </summary>
		/// <returns></returns>
		private List<string> GetEmails()
		{
			return new List<string> { "bob@bob.com", "jane@bob.com", "dan@dan.com" };
		}


		[Test]
		public void PrintEmailsGroupedByDomain_LINQGroupBy()
		{
			var emails = GetEmails();
			var domains = emails
				// Why reinvent the wheel with grouping into a dictionary?
				.GroupBy(GetDomain)
				.ToDictionary(d => d.Key);

			foreach (var domain in domains.Keys)
			{
				var emailsInDomain = domains[domain];
				PrintEmailsForDomain(domain, emailsInDomain);
			}
		}

		[Test]
		public void PrintEmailsGroupedByDomain_InteractiveFramework()
		{
			var emails = GetEmails();
			var emailsByDomain = emails
				.GroupBy(GetDomain);

			emailsByDomain
				.Run(emailsInDomain => PrintEmailsForDomain(emailsInDomain.Key, emailsInDomain));
		}

		[Test]
		public void PrintEmailsGroupedByDomain_CompositionViaInlineVariables()
		{
			GetEmails()
				.GroupBy(GetDomain)
				.Run(emailsInDomain => PrintEmailsForDomain(emailsInDomain.Key, emailsInDomain));
		}

		[Test]
		public void PrintEmailsGroupedByDomain_PrintV2()
		{
			GetEmails()
				.GroupBy(GetDomain)
				.Run(emailsInDomain => PrintEmailsForDomain2(emailsInDomain.Key, emailsInDomain));
		}

		private void PrintEmailsForDomain2(string domain, IEnumerable<string> emailsInDomain)
		{
			Console.WriteLine("Emails for domain: " + domain);
			emailsInDomain
				.Run(Console.WriteLine);
			Console.WriteLine();
		}

		// This took us to "What" not "How"
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Refactoring
{
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
				return new List<string> {"bob@bob.com", "bob@dan.com", "jane@bob.com", "dan@dan.com"};
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

	#region Composed Method - Add

	public class MyExpandableList
	{
		private object[] _elements = new object[10];

		private bool _readOnly;

		private int _size;

		public void Add(object child)
		{
			if (!_readOnly)
			{
				var newSize = _elements.Length + 1;

				if (newSize > _elements.Length)
				{
					var newElements = new object[_elements.Length + 10];

					for (var i = 0; i < _size; i++)
					{
						newElements[i] = _elements[i];
					}


					_elements = newElements;
				}


				_elements[_size] = child;

				_size++;
			}
		}

		public bool ReadOnly
		{
			get { return _readOnly; }

			set { _readOnly = value; }
		}
	}

	public class MyExpandableListRefactored
	{
		private object[] _elements = new object[10];

		private bool _readOnly;

		private int _size;

		public void Add(object child)
		{
			if (_readOnly)
			{
				return;
			}

			if (atCapacity())
			{
				grow();
			}

			addElement(child);
		}

		private void grow()
		{
			var newElements = new object[_elements.Length + 10];

			for (var i = 0; i < _size; i++)
			{
				newElements[i] = _elements[i];
			}


			_elements = newElements;
		}

		private bool atCapacity()
		{
			var newSize = _elements.Length + 1;

			return newSize > _elements.Length;
		}

		private void addElement(object child)
		{
			_elements[_size] = child;

			_size++;
		}

		public bool ReadOnly
		{
			get { return _readOnly; }

			set { _readOnly = value; }
		}
	}

	#endregion

	#region Creation Methods

	// http://www.industriallogic.com/xp/refactoring/constructorCreation.html

	#endregion
}
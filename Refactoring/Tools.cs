using System;
using NUnit.Framework;

namespace Refactoring
{
	public class Tools
	{
		public static void MovingBeyondFindAndReplace()
		{
		}

		[Test]
		public void TestDerp()
		{
			DoDerp("5", null);
			DoDerp("asdf", null);
		}

		public void DoDerp(string numberText, string notUsed)
		{
			int? number = null;
			
			int parsedNumber;
			
			if ( int.TryParse(numberText, out parsedNumber ))
				{	

					number = parsedNumber;
			}

			// do some more code
				if (number.HasValue)
				{

				Console.WriteLine("Doing " + number);
			}
			else
			{
				Console.WriteLine("No can do " + numberText);
			}
		}

		// code cleanup - consistency
		// extract method 
		// rename
		// make extension methods
		// extract variable - test parameters
		// find usages & safe delete
	}
}
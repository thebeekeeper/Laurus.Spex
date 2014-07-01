using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Spex
{
	public class ConsoleLog : ITestLog
	{
		IList<TestStep> ITestLog.GetExecutedSteps()
		{
			return new List<TestStep> ();
		}

		void ITestLog.Given(string given, bool success)
		{
			var c = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("+ Given {0}", given);
			Console.ForegroundColor = c;
		}

		void ITestLog.And(string and, bool success)
		{
			var c = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine("+ And {0}", and);
			Console.ForegroundColor = c;
		}

		void ITestLog.When(string when, bool success)
		{
			var c = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("- When {0}", when);
			Console.ForegroundColor = c;
		}

		void ITestLog.Then(string then, bool success)
		{
			var c = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("x Then {0}", then);
			Console.ForegroundColor = c;
		}

		void ITestLog.Error(string error)
		{
			var c = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Error: {0}", error);
			Console.ForegroundColor = c;
		}
	}
}

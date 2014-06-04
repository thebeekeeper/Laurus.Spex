using System;
using System.Collections.Generic;

namespace Spex
{
	public class RuntimeLog : ITestLog
	{
		public RuntimeLog()
		{
			_steps = new List<TestStep> ();
		}

		IList<TestStep> ITestLog.GetExecutedSteps()
		{
			return _steps;
		}

		void ITestLog.Given(string given)
		{
			_steps.Add(new TestStep() { Kind = "Given", Description = given, Outcome = "Pass" });
		}

		void ITestLog.And(string and)
		{
			_steps.Add (new TestStep () { Kind = "And", Description = and, Outcome = "Pass" });
		}

		void ITestLog.When(string when)
		{
			_steps.Add (new TestStep () { Kind = "When", Description = when, Outcome = "Pass" });
		}

		void ITestLog.Then(string then)
		{
			_steps.Add (new TestStep () { Kind = "Then", Description = then, Outcome = "Pass" });
		}

		void ITestLog.Error(string error)
		{
			_steps.Add(new TestStep() { Kind = "Error", Description = error, Outcome = "Fail" });
		}

		private List<TestStep> _steps;
	}
}


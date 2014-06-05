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

		void ITestLog.And(string and, bool success)
		{
			_steps.Add (new TestStep () { Kind = "And", Description = and, Outcome = success.ToOutcome() });
		}

		void ITestLog.When(string when, bool success)
		{
			_steps.Add (new TestStep () { Kind = "When", Description = when, Outcome = success.ToOutcome() });
		}

		void ITestLog.Then(string then, bool success)
		{
			_steps.Add (new TestStep () { Kind = "Then", Description = then, Outcome = success.ToOutcome() });
		}

		void ITestLog.Error(string error)
		{
			_steps.Add(new TestStep() { Kind = "Error", Description = error, Outcome = "Fail" });
		}

		private List<TestStep> _steps;
	}

	public static class BooleanExtensions
	{
		public static string ToOutcome(this bool v)
		{
			return v ? "Pass" : "Fail";
		}
	}
}


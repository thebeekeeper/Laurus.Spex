using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Spex
{
	public interface ITestLog
	{
		void Given(string given, bool success);
		void And(string and, bool success);
		void When(string when, bool success);
		void Then(string then, bool success);
		void Error(string message);

		IList<TestStep> GetExecutedSteps();
	}
}

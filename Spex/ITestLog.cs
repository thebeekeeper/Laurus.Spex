using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spex
{
	public interface ITestLog
	{
		void Given(string given);
		void And(string and, bool success);
		void When(string when, bool success);
		void Then(string then, bool success);
		void Error(string message);

		IList<TestStep> GetExecutedSteps();
	}
}

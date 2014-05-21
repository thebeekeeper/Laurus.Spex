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
		void And(string and);
		void When(string when);
		void Then(string then);
		void Error(string message);
	}
}

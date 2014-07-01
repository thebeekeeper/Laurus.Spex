using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Spex
{
	public class SpexContext
	{
		public dynamic ContextData { get; set; }
		public ITestLog Log { get; set; }
		public string Title { get; set; }

		public SpexContext Given(string given, Action<SpexContext> action)
		{
			// bootstrapping might be an issue - how to log if setting up the context fails?
			var success = TryStep(action);
			this.Log.Given(given, success);
			return this;
		}

		// i don't know if i really want And - given, when, then is pretty nice, but it's pretty good to havae something else that affects context
		public SpexContext And(string and, Action<SpexContext> action)
		{
			var success = TryStep(action);
			this.Log.And(and, success);
			return this;
		}

		public SpexContext When(string when, Action<SpexContext> action)
		{
			var success = TryStep(action);
			this.Log.When(when, success);
			return this;
		}

		public SpexContext Then(string then, Action<SpexContext> action)
		{
			var success = TryStep(action);
			this.Log.Then(then, success);
			return this;
		}

		private bool TryStep(Action<SpexContext> step)
		{
			bool success = true;
			try
			{
				step(this);
			}
			catch (Exception)
			{
				success = false;
			}
			return success;
		}
	}
}

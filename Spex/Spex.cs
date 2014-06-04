using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Spex
{
    public static class Spex
	{
		public static SpexContext Given(string given, Func<SpexContext> action)
		{
			// bootstrapping might be an issue - how to log if setting up the context fails?
			var context = default(SpexContext);
			try
			{
				context = action();
				context.Log.Given(given);
			}
			catch (Exception e)
			{
				context.Log.Error(e.Message);
			}
			return context;
		}

		// i don't know if i really want And - given, when, then is pretty nice, but it's pretty good to havae something else that affects context
		public static SpexContext And(this SpexContext context, string and, Action<SpexContext> action)
		{
			context.Log.And(and);
			action(context);
			return context;
		}

		public static SpexContext When(this SpexContext context, string when, Action<SpexContext> action)
		{
			context.Log.When(when);
			action(context);
			return context;
		}

		public static SpexContext Then(this SpexContext context, string then, Action<SpexContext> action)
		{
			context.Log.Then(then);
			action(context);
			return context;
		}

	}

	/// <summary>
	/// Test context can either be explicitly defined, or ContextData can be used to dynamically add members
	/// </summary>
	public class SpexContext
	{
		public dynamic ContextData { get; set; }
		public ITestLog Log { get; set; }

		public SpexContext()
		{
			ContextData = new ExpandoObject();
			Log = new RuntimeLog();
		}
	}

	public static class ContextExtensions
	{
		public static Scenario ToScenario(this SpexContext context)
		{
			return new Scenario()
			{
				Title = "asdf",
				Outcome =  "Pass",
				Steps = context.Log.GetExecutedSteps(),
			};
		}
	}

	public class NodeContext : SpexContext
	{
		public string SelectedNode { get; set; }
	}

	[AttributeUsage(AttributeTargets.Method)]
	public class ScenarioAttribute : Attribute
	{
		public string Title { get; set; }

		public ScenarioAttribute(string title)
		{
			Title = title;
		}
	}
}

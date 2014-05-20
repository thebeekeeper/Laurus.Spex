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
		public static TestContext Given(string given, Func<TestContext> action)
		{
			var context = action();
			context.Log.Given(given);
			return context;
		}

		// i don't know if i really want And - given, when, then is pretty nice, but it's pretty good to havae something else that affects context
		public static TestContext And(this TestContext context, string and, Action<TestContext> action)
		{
			context.Log.And(and);
			action(context);
			return context;
		}

		public static TestContext When(this TestContext context, string when, Action<TestContext> action)
		{
			context.Log.When(when);
			action(context);
			return context;
		}

		public static TestContext Then(this TestContext context, string then, Action<TestContext> action)
		{
			context.Log.Then(then);
			action(context);
			return context;
		}

	}

	/// <summary>
	/// Test context can either be explicitly defined, or ContextData can be used to dynamically add members
	/// </summary>
	public class TestContext
	{
		public dynamic ContextData { get; set; }
		public ITestLog Log { get; set; }

		public TestContext()
		{
			ContextData = new ExpandoObject();
			Log = new ConsoleLog();
		}
	}

	public static class ContextExtensions
	{
		public static Scenario ToScenario(this TestContext context)
		{
			return new Scenario()
			{
				Title = "asdf",
			};
		}
	}

	public class NodeContext : TestContext
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

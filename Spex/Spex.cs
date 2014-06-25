using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Spex
{
    public class Spex
	{
		public static SpexContext Given(string given, Func<SpexContext> action)
		{
			// bootstrapping might be an issue - how to log if setting up the context fails?
			var context = default(SpexContext);
			try
			{
				context = action();
				context.Log.Given(given);
				context.Title = GetScenarioTitle();
			}
			catch (Exception e)
			{
				context.Log.Error(e.Message);
			}
			return context;
		}

		private static string GetScenarioTitle()
		{
			var frames = new StackTrace ().GetFrames();
			foreach (var f in frames) {
				var attrs = f.GetMethod ().GetCustomAttributes (typeof(ScenarioAttribute), false);
				if (attrs.Any ()) {
					var scenario = (ScenarioAttribute)attrs.First ();
					return scenario.Title;
				}
			}
			throw new Exception ("Scenario attribute not found on test");
		}
	}

	public class SpexContext
	{
		// i don't know if i really want And - given, when, then is pretty nice, but it's pretty good to havae something else that affects context
		public SpexContext And(string and, Action<SpexContext> action)
		{
			bool success = true;
			try
			{
				action(this);
			}
			catch (Exception) 
			{
				success = false;
			}
			this.Log.And(and, success);
			return this;
		}

		public SpexContext When(string when, Action<SpexContext> action)
		{
			bool success = true;
			try
			{
				action(this);
			}
			catch(Exception) {
				success = false;
			}
			this.Log.When(when, success);
			return this;
		}

		public SpexContext Then(string then, Action<SpexContext> action)
		{
			bool success = true;
			try
			{
				action(this);
			}
			catch (Exception) {
				success = false;
			}
			this.Log.Then(then, success);
			return this;
		}

		public dynamic ContextData { get; set; }
		public ITestLog Log { get; set; }
		public string Title {get;set;}

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
				Title = context.Title,
				Outcome = (!context.Log.GetExecutedSteps().Any(s => s.Outcome.Equals("Fail"))).ToOutcome(),
				Steps = context.Log.GetExecutedSteps(),
			};
		}
	}

	/*public class NodeContext : SpexContext
	{
		public string SelectedNode { get; set; }
	}*/

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

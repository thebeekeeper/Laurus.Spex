using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Laurus.Spex
{
	public class Spex
	{
		private static string GetScenarioTitle()
		{
			var frames = new StackTrace().GetFrames();
			foreach (var f in frames)
			{
				var attrs = f.GetMethod().GetCustomAttributes(typeof(ScenarioAttribute), false);
				if (attrs.Any())
				{
					var scenario = (ScenarioAttribute)attrs.First();
					return scenario.Title;
				}
			}
			throw new Exception("Scenario attribute not found on test");
		}
	}

	public static class ContextExtensions
	{
		public static Scenario ToScenario(this SpexContext context)
		{
			return new Scenario()
			{
				//Title = context.Title,
                Title = "figure out the title",
				Outcome = (!context.Log.GetExecutedSteps().Any(s => s.Outcome.Equals("Fail"))).ToOutcome(),
				Steps = context.Log.GetExecutedSteps(),
			};
		}
	}

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Razor;

namespace Spex
{
	public class Templater
	{
		public void Apply(string title, IEnumerable<Scenario> scenarios)
		{
			var data = new TemplateData()
			{
				Title = title,
				Scenarios = scenarios
				/*Title = "Css Service",
				Scenarios = new List<Scenario>()
				{
					new Scenario()
					{
						Title = "Theme manager can save css",
						Outcome = "Pass",
						Steps = new List<TestStep>() 
						{
							new TestStep() { Kind = "Given", Description = "I am authenticated as a user with theme manager role", Outcome = "Pass" },
							new TestStep() { Kind = "When", Description = "I save a new css entry", Outcome = "Pass" },
							new TestStep() { Kind = "Then", Description = "the css should be saved", Outcome = "Pass" }
						}
					},
					new Scenario()
					{
						Title = "Multiple active css entries should not be allowed",
						Outcome = "Fail",
						Steps = new List<TestStep>() 
						{
							new TestStep() { Kind = "Given", Description = "I am authenticated as a user with theme manager role", Outcome = "Pass" },
							new TestStep() { Kind = "And", Description = "My tenant has an active css entry", Outcome = "Pass" },
							new TestStep() { Kind = "When", Description = "I save a new css entry", Outcome = "Pass" },
							new TestStep() { Kind = "Then", Description = "only one css entry should be active", Outcome = "Fail" }
						}
					}
				}*/
			};
			var template = new RuntimeTextTemplate1(data);
			var content = template.TransformText();
			System.IO.File.WriteAllText(@"templated.html", content);
		}
	}
}

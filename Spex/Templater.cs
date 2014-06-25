using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spex
{
	public class Templater
	{
		public void Apply(string title, IEnumerable<Scenario> scenarios, string outputFile)
		{
			var data = new TemplateData()
			{
				Title = title,
				Scenarios = scenarios
			};
			var template = new RuntimeTextTemplate1(data);
			var content = template.TransformText();
			System.IO.File.WriteAllText(outputFile, content);
		}
	}
}

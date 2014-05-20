using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spex
{
	public partial class RuntimeTextTemplate1
	{
		public TemplateData Data { get; set; }
		public RuntimeTextTemplate1(TemplateData data)
		{
			Data = data;
		}
	}

	public class TemplateData
	{
		public string Title { get; set; }
		public IEnumerable<Scenario> Scenarios { get; set; }
	}

	public class Scenario
	{
		public string Title { get; set; }
		public string Outcome { get; set; }
		public IEnumerable<TestStep> Steps { get; set; }
	}

	public class TestStep
	{
		public string Kind { get; set; }
		public string Description { get; set; }
		public string Outcome { get; set; }
	}
}

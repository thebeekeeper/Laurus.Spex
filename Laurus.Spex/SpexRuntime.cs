using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Spex
{
	public class SpexRuntime
	{
        public SpexRuntime(ITestLog logger)
		{
			_context = new SpexContext()
            {
				Log = logger,
			};
		}

        public void Run(IFeature feature, string scenarioName)
		{
			feature.SetContext(_context);
			var s = feature.GetType().GetMethod(scenarioName);
			s.Invoke(feature, null);
			var t = new Templater();
			t.Apply("asdf", new[] { _context.ToScenario() }, "test.html");
		}

		private ITestLog _log;
		private SpexContext _context;
	}
}

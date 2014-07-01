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
        public SpexRuntime()
		{
			_context = new SpexContext()
            {
				Log = new ConsoleLog(),
			};
		}

        public void Run(IFeature feature, string scenarioName)
		{
			feature.SetContext(_context);
			var s = feature.GetType().GetMethod(scenarioName);
			s.Invoke(feature, null);
		}

		private ITestLog _log;
		private SpexContext _context;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Spex
{
	public class RuntimeBuilder
	{
		public RuntimeBuilder WithLogger(ITestLog log)
		{
			_logger = log;
			return this;
		}

		public SpexRuntime Create()
		{
			return new SpexRuntime(_logger);
		}

		private ITestLog _logger;
	}

    public static class RuntimeFactory
	{
        public static RuntimeBuilder Initialize()
		{
			return new RuntimeBuilder();
		}
	}
}

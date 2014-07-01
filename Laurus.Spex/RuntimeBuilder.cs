using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Spex
{
	public class RuntimeBuilder
	{
        public SpexRuntime Default()
		{
			return new SpexRuntime();
		}
	}
}

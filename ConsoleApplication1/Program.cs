using Spex;
using Spex.Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			var r = new Runner();
			var result = r.RunTest<AtmSample>("AnotherOne");
			var t = new Templater();
			t.Apply ("Test", new[] { result }, "templated.html");
		}
	}
}

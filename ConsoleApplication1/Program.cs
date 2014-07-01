using Laurus.Spex;
using Laurus.Spex.Sample;
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
			RunTest<AtmSample>("AnotherOne");
			RunTest(new AtmSample(), "AnotherOne");
			//var t = new Templater();
			//t.Apply ("Test", new[] { result }, "templated.html");
			Console.ReadKey();
		}

		public static void RunTest<T>(string name) where T : IFeature
		{
			var inst = Activator.CreateInstance<T>();
			var runtime = new SpexRuntime();
			runtime.Run(inst, "AnotherOne");
		} 

        public static void RunTest(IFeature feature, string name)
		{
			var runtime = new SpexRuntime();
			runtime.Run(feature, name);
		}
	}
}

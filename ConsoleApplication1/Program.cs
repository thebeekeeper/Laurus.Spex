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
			//RunTest(new AtmSample(), "AnotherOne");
			Console.ReadKey();
		}

		public static void RunTest<T>(string name) where T : IFeature
		{
			var inst = Activator.CreateInstance<T>();
			var runtime = RuntimeFactory.Initialize().WithLogger(new RuntimeLog()).Create();
			runtime.Run(inst, "AnotherOne");
		} 

        public static void RunTest(IFeature feature, string name)
		{
			var runtime = RuntimeFactory.Initialize().WithLogger(new ConsoleLog()).Create();
			runtime.Run(feature, name);
		}
	}
}

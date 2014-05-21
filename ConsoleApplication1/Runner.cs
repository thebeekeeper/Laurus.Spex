using Spex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	public class Runner
	{
		public TestContext RunTest<T>(string name)
		{
			var instance = Activator.CreateInstance<T>();
			var testMethod = instance.GetType().GetMethods().Where(m => m.Name.Equals(name)).First();
			var attr = testMethod.GetCustomAttributes(typeof(ScenarioAttribute), false).First() as ScenarioAttribute;
			Console.WriteLine(attr.Title);
			var c = testMethod.Invoke(instance, null);
			var context = (TestContext)c;
			return context;
		}
	}
}

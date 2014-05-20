using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Spex.Sample
{
	public class Sample2
	{
		[Scenario("Customer withdraws cash")]
		public TestContext AnotherOne()
		{
			var context = Spex.Given("the account is in credit", () =>
			{
				var rval = new TestContext();
				return rval;
			})
			.And("the card is valid", (c) => { })
			.When("the customer requests cash", (c) => { })
			.Then("ensure a rejection message is displayed", (c) => { })
			.Then("ensure cash is not dispensed", (c) => { })
			.Then("ensure the card is returned", (c) => { });
			return context;
		}
	}


}

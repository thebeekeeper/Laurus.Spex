using NUnit.Framework;
using System;
using Spex;
using Spex.SampleApp;

namespace Laurus.Spex.NUnitSample
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		//[Spex.Scenario("Customer withdraws cash")]
		public void TestCase ()
		{
			// can't resolve type Given, not sure why
			/*var context = Spex.Given("the account is in credit", () => CreateDefaultContext())
				.And("the card is valid", (c) => 
					{
						var atm = new Atm();
						atm.CardIsValid(c.ContextData.Card);
					})
				.When("the customer requests cash", (c) => { })
				.Then("ensure a rejection message is displayed", (c) => { })
				.Then("ensure cash is not dispensed", (c) => { })
				.Then("ensure the card is returned", (c) => { });
			*/
		}

		// this is an example of a shared step binding
		public SpexContext CreateDefaultContext()
		{
			var rval = new SpexContext();
			rval.ContextData.Card = new AtmCard(Guid.NewGuid(), DateTime.Now.AddDays(99))
			{
				Balance = -1000.0M
			};
			return rval;
		}
	}
}


using Spex.SampleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spex.Sample
{
	public class AtmSample
	{
		[Scenario("Customer withdraws cash")]
		public SpexContext AnotherOne()
		{
			var context = Spex.Given("the account is in credit", () => CreateDefaultContext())
			.And("the card is valid", (c) => 
			{
				var atm = new Atm();
				atm.CardIsValid(c.ContextData.Card);
			})
			.When("the customer requests cash", (c) => { })
			.Then("ensure a rejection message is displayed", (c) => { })
			.Then("ensure cash is not dispensed", (c) => { })
			.Then("ensure the card is returned", (c) => { });
			return context;
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

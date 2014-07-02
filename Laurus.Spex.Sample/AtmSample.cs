using Laurus.Spex.SampleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Spex.Sample
{
	public class AtmSample : IFeature
	{
		[Scenario("Customer withdraws cash")]
		public void AnotherOne()
		{
			_context.Given("the account is in credit", (c) => InitContext(c))
			.And("the card is valid", (c) =>
			{
				var atm = new Atm();
				atm.CardIsValid(c.ContextData.Card);
			})
			.When("the customer requests cash", (c) => { })
			.Then("ensure a rejection message is displayed", (c) => { })
			.Then("ensure cash is not dispensed", (c) => { throw new Exception("test"); })
			.Then("ensure the card is returned hello", (c) => { });
		}

		// this is an example of a shared step binding
		public void InitContext(SpexContext c)
		{
			c.ContextData.Card = new AtmCard(Guid.NewGuid(), DateTime.Now.AddDays(99))
			{
				Balance = 1000.0M
			};
		}

		public void wat()
		{
			var steps = new Dictionary<string, Action>();
			steps["given"] = () => Console.WriteLine("hello given");
			// neat
			steps["given"].Invoke();
		}

		public void SetContext(SpexContext context)
		{
			_context = context;
		}

		private SpexContext _context;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spex.SampleApp
{
    public class Atm
    {
		public bool CardIsValid(AtmCard card)
		{
			if (card.Number.Equals(Guid.Empty) == false && card.Expirationdate.Subtract(DateTime.Today).Milliseconds >= 0)
				return true;
			return false;
		}
    }
}

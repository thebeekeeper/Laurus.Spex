using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Spex.SampleApp
{
	public class AtmCard
	{
		public Guid Number { get { return _number; } }
		public DateTime Expirationdate { get { return _expiration; } }

		public decimal Balance { get; set; }

		public AtmCard(Guid number, DateTime expiration)
		{
			_number = number;
			_expiration = expiration;
			Balance = 0.0M;
		}

		private Guid _number;
		private DateTime _expiration;
	}
}

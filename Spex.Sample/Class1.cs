using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spex.Sample
{
	public class Class1
	{
		/*
		Scenario: When adding a user to a node, search by department exact match and validate that the search match was for department
		Given an administrator that has selected the following node
		|Node Name|
		|Savo West|
		And chooses to add a user to the node
		When the administrator searches using the search term
		| Search term |
		| Accounting  |
		Then the search results will contain the following match
		| Match      |
		| Adam Apple |
		And the result matched on the following field (We know this because the data is set up so Adam Apple is the only user who lines up with Accounting as the department
		| Field      |
		| Department |
		 */

		public void WhenAddingAUserToANodeSearchByDepartmentExactMatchAndImSickOfTypingThis()
		{
			var nodeName = string.Empty;
			Given an_administrator_that_has_selected_the_following_node = () => { nodeName = "Savo West"; };

			And chooses_to_add_a_user_to_the_node = () => { };

			When the_administrator_searches_using_the_search_term = () =>
			{
				// search for "Accounting";
			};

			Then the_search_results = (x) => { Console.WriteLine(x); };
		}
	}

	public delegate void Given();
	public delegate void And();
	public delegate void When();
	//public delegate void Then();
	public delegate void Then(string step);
	public delegate void AndThen();
}

using FizzBuzzApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzApi.Services
{
	// Service to process the input, run the fizz buzz algorithm, then output the result
	// This could be more robust, with some DI in the startup class, but for brevity, we'll call this service via the api
	public class FizzBuzzService
	{
		// value check for ensuring in range is done on the API call
		// this could be done via a validation later (service) depending on complexity of the validation :)
		public static Result<List<string>> GetFizzBuzzResult(int n)
		{
			var result = new Result<List<string>>();
			var fizzBuzzList = new List<string>();

			for (var i = 1; i <= n; i++)
			{
				var item = string.Empty;

				if (i % 15 == 0)
				{
					item = "FizzBuzz";
				}
				else if (i % 3 == 0)
				{
					item = "Fizz";
				}
				else if (i % 5 == 0)
				{
					item = "Buzz";
				}

				//wasn't divisible by the above, just spit out that number, number bing the i loop value :)
				if (string.IsNullOrWhiteSpace(item) == true)
				{
					item = i.ToString();
				}

				fizzBuzzList.Add(item);
			}

			result.Data = fizzBuzzList;
			result.Success = fizzBuzzList.Count > 0;

			return result;
		}
	}
}
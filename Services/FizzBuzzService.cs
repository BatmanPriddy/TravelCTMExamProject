using FizzBuzzApi.Models;
using System.Collections.Generic;

namespace FizzBuzzApi.Services
{
	/// <summary>
	/// Service to process the input, run the fizz buzz algorithm, then output the result 
	/// This could be more robust, with some DI in the startup class with an Interface, but for brevity, we'll call this service via the api
	/// </summary>
	public class FizzBuzzService
	{
		/// <summary>
		/// For each multiple of 3, print "Fizz" instead of the number.
		/// For each multiple of 5, print "Buzz" instead of the number.
		/// For numbers which are multiples of both 3 and 5, print "FizzBuzz" instead of the number.
		/// Value check for ensuring in range is done on the API call 
		/// </summary>
		/// <param name="n">Input of between 1 and 100</param>
		/// <returns>A success or failed object, with the list of fizzbuzz data if successful</returns>
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

				//wasn't divisible by the above (i.e. had a remainder), just spit out that number, number being the i loop value :)
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
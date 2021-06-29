namespace FizzBuzzApi.Models
{
	/// <summary>
	/// Model class used to store a result for better control of your output
	/// </summary>
	/// <typeparam name="T">Generic type for data being passed around</typeparam>
	public class Result<T>
	{
		//Data is the result data, generic here so it can be whatever you want
		//ErrorMessage is for any failures you might encounter, that the user/call can see to determine issue
		//Success is a boolean of hey it work, or nope, houston we have a problem!
		public T Data { get; set; }
		public string ErrorMessage { get; set; }
		public bool Success { get; set; }

		public Result()
		{
			Init();
		}

		/// <summary>
		/// Used to initialize default values for the properties, which allows you to know the exactly defaults
		/// and can check against them.
		/// </summary>
		private void Init()
		{
			Data = default;
			ErrorMessage = string.Empty;
			Success = false;
		}
	}
}
namespace FizzBuzzApi.Models
{
	//This is a cool little model to store the result, allowing you better control over your output
	//Data is the result data, generic here so it can be whatever you want
	//ErrorMessage is for any failures you might encounter, that the user/call can see to determine issue
	//Success is a boolean of hey it work, or nope, houston we have a problem!
	public class Result<T>
	{
		public T Data { get; set; }
		public string ErrorMessage { get; set; }
		public bool Success { get; set; }

		public Result()
		{
			Init();
		}

		private void Init()
		{
			Data = default(T);
			ErrorMessage = string.Empty;
			Success = false;
		}
	}
}
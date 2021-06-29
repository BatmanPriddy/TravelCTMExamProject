using FizzBuzzApi.Services;
using System;
using System.Web.Http;

namespace FizzBuzzApi.Controllers
{
    /// <summary>
    /// FizzBuzz Controller to accept n input, call service, and output the results
    /// or Bad Request if there was a problem
    /// </summary>
    public sealed class FizzBuzzController : ApiController
    {
        /// <summary>
        /// Runs the code to get you back your "fizzbuzz" result based on inputted n value
        /// </summary>
        /// <param name="n">Input of between 1 and 100</param>
        /// <returns>200 (Ok) if successfully, 400 (BadRequest) if any issues</returns>
        [Route("api/fizzbuzz/{n}")]
        [HttpGet]
        public IHttpActionResult GetFizzBuzzResult(int n)
        {
            try
            {
                // this could be done via a validation later (service) depending on complexity of the validation :)
                // simple enough to leave here for this app
                if (n > 0 && n < 101)
                {
                    // Call service to process the n value, and get back your fizzbuzz list
                    var result = FizzBuzzService.GetFizzBuzzResult(n);

                    if (result.Success)
                    {
                        return Ok(result.Data);
                    }
                    else
                    {
                        // something failed in the service, let calling application / user know
                        return BadRequest(result.ErrorMessage);
                    }
                }
                else
                {
                    // Let the calling application / user know that the value was not within the expected range
                    return BadRequest($"Value was not specified or was not between 1 and 100, value was {n}");
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add(nameof(n), n);

                return InternalServerError(ex);
            }
        }
    }
}
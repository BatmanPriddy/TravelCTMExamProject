using FizzBuzzApi.Models;
using FizzBuzzApi.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace FizzBuzzApi.Controllers
{
    public class FizzBuzzController : ApiController
    {
        // Runs the code to get you back your result based on n
        [Route("api/fizzbuzz/{n}")]
        [HttpGet]
        public IHttpActionResult GetFizzBuzzResult(int n)
		{
            try
            {
                if (n > 0 && n < 101)
                {
                    var result = new Result<List<string>>();

                    if (result != null)
                    {
                        // Call service to process the n value, and get back your fizzbuzz list
                        result = FizzBuzzService.GetFizzBuzzResult(n);

                        if (result.Success)
                        {
                            return Ok(result.Data);
                        }
                        else
						{
                            return BadRequest(result.ErrorMessage); // something failed in the service, let caller know
                        }
                    }
                    else
                    {
                        return BadRequest(result.ErrorMessage); // something failed in the service, let caller know
                    }
                }
                else
				{
                    // This could be either, we could pass back a not found, or we can pass back a bad request, since the value was
                    // specified, but out of bounds :)
                    return Content(HttpStatusCode.NotFound, "Value was not specified or was not between 1 and 100, invalid endpoint!");
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
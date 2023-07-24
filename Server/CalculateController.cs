using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Scripting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerForCalculator
{
	[ApiController]
	[Route("[controller]")]


	public class CalculateController : ControllerBase
	{


		[HttpGet]
		public JsonResult Get()
		{
			return new JsonResult("Server run");
		}

		[HttpPost]
		public IActionResult Post([FromBody] string expression)
		{
			expression = "1.0*" + expression;
			try
			{
				double answer = CSharpScript.EvaluateAsync<double>(expression).Result;
				return Ok(new { result = answer });
			}
			catch
			{
				return BadRequest(new { message = "Incorrect expression!" });
			}
		}
	}
}
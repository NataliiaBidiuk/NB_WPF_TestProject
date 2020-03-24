using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestServerSide.Controllers
{
	/// <summary>
	/// Slider Controller
	/// </summary>
	/// <seealso cref="Controller" />
	[Route("slider")]
	[ApiController]
	public class SliderController : ControllerBase
	{
		/// <summary>
		/// Gets this instance.
		/// </summary>
		/// <returns>RandomValue</returns>
		[HttpGet]
		[Route("GetSliderValue")]
		public ActionResult<int> GetSliderValue()
		{
			var randomizer = new Random();

			return randomizer.Next(1, 100);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Services
{
	/// <summary>
	/// ISlider Service
	/// </summary>
	public interface ISliderService
	{
		/// <summary>
		/// Gets the slider value.
		/// </summary>
		/// <returns>Slider value</returns>
		Task<int> GetSliderValue();
	}
}

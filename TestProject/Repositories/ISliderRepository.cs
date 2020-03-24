using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Repositories
{
	/// <summary>
	/// I Slider Repository
	/// </summary>
	public interface ISliderRepository
	{
		/// <summary>
		/// Gets the slider value.
		/// </summary>
		/// <returns>Slider value</returns>
		Task<int> GetSliderValue();
	}
}

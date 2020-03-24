using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Repositories;

namespace TestProject.Services
{
	/// <summary>
	/// Slider Service
	/// </summary>
	/// <seealso cref="ISliderService" />
	public class SliderService : ISliderService
	{
		#region Private Fields

		/// <summary>
		/// The slider repository
		/// </summary>
		private readonly ISliderRepository _sliderRepository;

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="SliderService"/> class.
		/// </summary>
		/// <param name="sliderRepository">The slider repository.</param>
		public SliderService(ISliderRepository sliderRepository) => _sliderRepository = sliderRepository;

		#endregion

		#region Public Methods

		/// <inheritdoc />
		public Task<int> GetSliderValue() => _sliderRepository.GetSliderValue();

		#endregion
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace TestProject.Repositories
{
	/// <summary>
	/// Slider Repository
	/// </summary>
	/// <seealso cref="ISliderRepository" />
	public class SliderRepository : ISliderRepository
	{
		#region Private Fields

		/// <summary>
		/// The get slider value
		/// </summary>
		private const string GET_SLIDER_VALUE = "slider/GetSliderValue";

		/// <summary>
		/// The HTTP client
		/// </summary>
		private readonly HttpClient httpClient;

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="SliderRepository"/> class.
		/// </summary>
		public SliderRepository() => httpClient = new HttpClient
		{
			BaseAddress = new Uri($"{App.BackendUrl}/")
		};

		#endregion

		#region Public Methods

		/// <inheritdoc />
		public async Task<int> GetSliderValue()
		{
			try
			{
				var json = await httpClient.GetStringAsync(GET_SLIDER_VALUE);

				return await Task.Run(() => JsonConvert.DeserializeObject<int>(json));
			}
			catch (Exception ex)
			{
				return 100;
			}
		}

		#endregion
	}
}

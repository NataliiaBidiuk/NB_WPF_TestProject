using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using TestProject.Content.Shared;
using TestProject.Services;
using System.Threading;
using System.Windows.Input;

namespace TestProject.Content
{
	/// <summary>
	/// Slider View Model
	/// </summary>
	/// <seealso cref="NotifyPropertyChangedImplementation" />
	public class SliderViewModel : NotifyPropertyChangedImplementation
	{
		#region Private Fields

		/// <summary>
		/// The slider service
		/// </summary>
		private readonly ISliderService _sliderService;

		/// <summary>
		/// The slider value
		/// </summary>
		private int _sliderValue;

		/// <summary>
		/// The cancellation token
		/// </summary>
		private CancellationTokenSource _cancellationToken;

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="SliderViewModel"/> class.
		/// </summary>
		/// <param name="sliderService">The slider service.</param>
		public SliderViewModel(ISliderService sliderService)
		{
			_sliderService = sliderService;

			LoadData();
		}

		#endregion

		/// <summary>
		/// Gets the cancel command.
		/// </summary>
		public ICommand CancelCommand => new Command(() => _cancellationToken.Cancel());

		/// <summary>
		/// Gets the start command.
		/// </summary>
		public ICommand StartCommand => new Command(LoadData);

		/// <summary>
		/// Gets or sets the slider value.
		/// </summary>
		public int SliderValue
		{
			get => _sliderValue;
			set => SetProperty(ref _sliderValue, value);
		}

		#region Private Methods

		/// <summary>
		/// Loads the data.
		/// </summary>
		private void LoadData()
		{
			_cancellationToken = new CancellationTokenSource();

			Task.Run(async () =>
			{
				while (true)
				{
					SliderValue = await _sliderService.GetSliderValue();

					await Task.Delay(1000, _cancellationToken.Token);
				}
			});
		}

		#endregion
	}
}
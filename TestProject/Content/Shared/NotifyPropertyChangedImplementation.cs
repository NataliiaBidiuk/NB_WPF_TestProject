using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Content.Shared
{
	/// <summary>
	/// Notify Property Changed Implementation
	/// </summary>
	/// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
	public class NotifyPropertyChangedImplementation : INotifyPropertyChanged
	{
		#region Events

		/// <summary>
		/// Occurs when a property value changes.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		#region Methods

		/// <summary>
		/// Sets the property.
		/// </summary>
		/// <typeparam name="T">The type of property value</typeparam>
		/// <param name="field">The field.</param>
		/// <param name="value">The value.</param>
		/// <param name="propertyName">Name of the property.</param>
		protected void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
		{
			if (Equals(field, value))
			{
				return;
			}

			field = value;
			SendPropertyChanged(propertyName);
		}

		/// <summary>
		/// Raise PropertyChanged event
		/// </summary>
		/// <param name="propertyName">Name of the property that was changed</param>
		protected void SendPropertyChanged([CallerMemberName] string propertyName = null)
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		#endregion
	}
}

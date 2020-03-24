using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestProject.Content.Shared
{
	/// <summary>
	/// Command
	/// </summary>
	/// <seealso cref="ICommand" />
	public class Command : ICommand
	{
		#region Private Fields

		/// <summary>
		/// The action
		/// </summary>
		private readonly Action _action;

		/// <summary>
		/// The can execute
		/// </summary>
		private readonly Func<bool> _canExecute;

		#endregion

		#region Constructor

		/// <summary>
		/// Creates instance of the command
		/// </summary>
		/// <param name="action">Action to be executed by the command</param>
		/// <param name="canExecute">A bolean property to containing current permissions to execute the command</param>
		public Command(Action action, Func<bool> canExecute = null)
		{
			_action = action;
			_canExecute = canExecute;
		}

		#endregion

		/// <summary>
		/// Wires CanExecuteChanged event 
		/// </summary>
		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		/// <summary>
		/// Defines the method that determines whether the command can execute in its current state.
		/// </summary>
		/// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if this command can be executed; otherwise, <see langword="false" />.
		/// </returns>
		public bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;

		/// <summary>
		/// Defines the method to be called when the command is invoked.
		/// </summary>
		/// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
		public void Execute(object parameter) => _action();
	}
}

using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TestProject.Repositories;
using TestProject.Services;

namespace TestProject
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		#region Private Fields

		/// <summary>
		/// The builder
		/// </summary>
		private readonly ContainerBuilder _builder;

		/// <summary>
		/// The container scope
		/// </summary>
		private static ILifetimeScope _containerScope;

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="App"/> class.
		/// </summary>
		public App()
		{
			_builder = new ContainerBuilder();

			//repository
			_builder.RegisterInstance(new SliderRepository()).As<ISliderRepository>();

			//services
			_builder.RegisterInstance(new SliderService(new SliderRepository())).As<ISliderService>();

			var container = _builder.Build();
			_containerScope = container.BeginLifetimeScope();	
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// The backend URL
		/// </summary>
		public static string BackendUrl = "https://localhost:44319";

		#endregion

		#region Methods

		/// <summary>
		/// Resolves this instance.
		/// </summary>
		/// <typeparam name="T">Interface</typeparam>
		/// <returns>Resolved class</returns>
		public static T Resolve<T>() => _containerScope.Resolve<T>();

		#endregion
	}
}

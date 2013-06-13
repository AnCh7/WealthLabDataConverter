// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter.Library/DependencyFactory.cs
// 
// Last updated:
// 2013-06-13 11:55 AM
// =================================================

#region Usings

using Microsoft.Practices.Unity;

using WealthLabDataConverter.Library.Core;
using WealthLabDataConverter.Library.Helpers;
using WealthLabDataConverter.Library.Logging;
using WealthLabDataConverter.Library.Models;

using log4net.Appender;

#endregion

namespace WealthLabDataConverter.Library.DI
{
	/// <summary> Simple wrapper for unity resolution. </summary>
	public class DependencyFactory
	{
		/// <summary>
		/// Static constructor for DependencyFactory which will
		/// initialize the unity container.
		/// </summary>
		static DependencyFactory()
		{
			Container = new UnityContainer();

			Container.RegisterInstance(new Parameters(), new ContainerControlledLifetimeManager());

			Container.RegisterType<IAppender, RichTextBoxAppender>(new ContainerControlledLifetimeManager());
			Container.RegisterType<IMyLogger, MyLogger>(new ContainerControlledLifetimeManager());
			Container.RegisterType<IDataConverter, DataConverter>(new ContainerControlledLifetimeManager());

			Container.RegisterInstance(new PathHelper(), new ContainerControlledLifetimeManager());
		}

		/// <summary>
		/// Public reference to the unity container which will
		/// allow the ability to register instances or take other
		/// actions on the container.
		/// </summary>
		public static IUnityContainer Container { get; private set; }
	}
}

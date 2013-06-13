// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter.Library/MyLogger.cs
// 
// Last updated:
// 2013-06-13 11:56 AM
// =================================================

#region Usings

using System;

using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Repository.Hierarchy;

#endregion

namespace WealthLabDataConverter.Library.Logging
{
	public class MyLogger : IMyLogger
	{
		private readonly ILog _logger;

		public MyLogger(IAppender appender, string currentClassName)
		{
			InitializeHierarchyLogManager();
			BasicConfigurator.Configure(appender);
			_logger = LogManager.GetLogger(currentClassName);
		}

		public void Error(string message)
		{
			_logger.Error(message);
		}

		public void Error(string message, Exception exception)
		{
			_logger.Error(message, exception);
		}

		public void Info(string message)
		{
			_logger.Info(message);
		}

		public void Progress(string message)
		{
			_logger.Info(message);
		}

		public void Debug(string message)
		{
			_logger.Debug(message);
		}

		public void Warn(string message)
		{
			_logger.Warn(message);
		}

		private void InitializeHierarchyLogManager()
		{
			var hierarchy = (Hierarchy)LogManager.GetRepository();
			hierarchy.Root.RemoveAllAppenders();
		}
	}
}

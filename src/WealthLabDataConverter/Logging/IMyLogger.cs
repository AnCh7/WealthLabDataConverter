// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter.Library/IMyLogger.cs
// 
// Last updated:
// 2013-06-13 11:56 AM
// =================================================

#region Usings

using System;

#endregion

namespace WealthLabDataConverter.Library.Logging
{
	public interface IMyLogger
	{
		void Error(string message);

		void Error(string message, Exception exception);

		void Progress(string message);

		void Info(string message);

		void Debug(string message);

		void Warn(string message);
	}
}

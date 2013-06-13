﻿// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter.Library/PathHelper.cs
// 
// Last updated:
// 2013-06-13 11:55 AM
// =================================================

#region Usings

using System;
using System.Globalization;
using System.IO;

#endregion

namespace WealthLabDataConverter.Library.Helpers
{
	public class PathHelper
	{
		public bool CreateDirectory(string folder)
		{
			if (string.IsNullOrEmpty(folder))
			{
				throw new ArgumentNullException("folder");
			}

			var successfulCreating = Directory.Exists(folder);

			if (IsValidPath(folder))
			{
				Directory.CreateDirectory(folder);
				successfulCreating = true;
			}

			return successfulCreating;
		}

		public bool IsValidPath(string folder)
		{
			var invalidPathChars = Path.GetInvalidPathChars();
			var isValidPath = true;

			foreach (var symbol in invalidPathChars)
			{
				if (folder.Contains(symbol.ToString(CultureInfo.InvariantCulture)))
				{
					isValidPath = false;
				}
			}

			return isValidPath;
		}
	}
}

// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter.Library/TimeFrame.cs
// 
// Last updated:
// 2013-06-13 11:57 AM
// =================================================

#region Usings

using System;

#endregion

namespace WealthLabDataConverter.Library.Models
{
	public static class TimeFrame
	{
		public static string GetTimeFrame(int type)
		{
			switch (type)
			{
				case 0:
					return "Daily";
				case 1:
					return "Weekly";
				case 2:
					return "Monthly";
				case 3:
					return "Minute";
				case 4:
					return "Second";
				case 5:
					return "Tick";
				case 6:
					return "Quarterly";
				case 7:
					return "Yearly";
				default:
					throw new ArgumentOutOfRangeException("type");
			}
		}
	}
}

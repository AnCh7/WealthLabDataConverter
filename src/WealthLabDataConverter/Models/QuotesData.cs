// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter.Library/QuotesData.cs
// 
// Last updated:
// 2013-08-18 9:36 PM
// =================================================

#region Usings

using System;

#endregion

namespace WealthLabDataConverter.Library.Models
{
	public class QuotesData
	{
		public DateTime DateTime { get; set; }
		public double Open { get; set; }
		public double High { get; set; }
		public double Low { get; set; }
		public double Close { get; set; }
		public double Volume { get; set; }
	}
}

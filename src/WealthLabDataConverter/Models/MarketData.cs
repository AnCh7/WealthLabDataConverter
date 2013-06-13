// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter.Library/MarketData.cs
// 
// Last updated:
// 2013-06-13 11:56 AM
// =================================================

#region Usings

using System;

#endregion

namespace WealthLabDataConverter.Library.Models
{
	public class MarketData
	{
		public DateTime DateTime { get; set; }
		public double Open { get; set; }
		public double High { get; set; }
		public double Low { get; set; }
		public double Close { get; set; }
		public double Volume { get; set; }
	}
}

// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter.Library/Dividend.cs
// 
// Last updated:
// 2013-08-21 2:13 PM
// =================================================

#region Usings

using WealthLabDataConverter.Library.Models.Fundamental.Base;

#endregion

namespace WealthLabDataConverter.Library.Models.Fundamental
{
	public class Dividend : FundamentalBase
	{
		public Dividend(string name) : base(name)
		{}

		public override string FormatValue()
		{
			string result;

			if (base.Value < 0.01)
			{
				result = (base.Value.ToString("F4") + " per share Dividend");
			}
			else
			{
				result = (base.Value.ToString("F") + " per share Dividend");
			}

			return result;
		}
	}
}

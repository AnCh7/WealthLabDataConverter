// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter.Library/ShortInterest.cs
// 
// Last updated:
// 2013-08-21 2:10 PM
// =================================================

#region Usings

using System.Globalization;
using System.Text;

using WealthLabDataConverter.Library.Models.Fundamental.Base;

#endregion

namespace WealthLabDataConverter.Library.Models.Fundamental
{
	public class ShortInterest : FundamentalBase
	{
		public ShortInterest(string name) : base(name)
		{}

		public override string FormatValue()
		{
			var builder = new StringBuilder();

			builder.Append("Shares Short");
			builder.Append(":");

			double d;
			double.TryParse(base.GetDetail("shares short"), out d);
			builder.Append(d.ToString("F2"));

			builder.Append(",");
			builder.Append("Short Interest as a % of Shares Outstanding");
			builder.Append(":");
			builder.Append(base.GetDetail("short interest as a % of shares outstanding"));
			builder.Append(",");
			builder.Append("Days to Cover");
			builder.Append(":");
			builder.Append(base.GetDetail("days to cover"));

			var result =  builder.ToString();
			return result;
		}
	}
}

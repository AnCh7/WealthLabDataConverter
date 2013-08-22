// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter.Library/EstimatedEarnings.cs
// 
// Last updated:
// 2013-08-21 2:13 PM
// =================================================

#region Usings

using System.Text;

using WealthLabDataConverter.Library.Models.Fundamental.Base;

#endregion

namespace WealthLabDataConverter.Library.Models.Fundamental
{
	public class EstimatedEarnings : FundamentalBase
	{
		public EstimatedEarnings(string name) : base(name)
		{}

		public override string FormatValue()
		{
			var builder = new StringBuilder();

			builder.Append("Q");
			builder.Append(base.GetDetail("current quarter"));
			builder.Append(":");
			builder.Append(base.GetDetail("fiscal year"));
			builder.Append(",");
			builder.Append("Est EPS:");
			builder.Append(base.Value.ToString("C3"));
			builder.Append(",");
			builder.Append("Sum TTM Mean:");
			builder.Append(base.GetDetail("sum TTM mean value"));
			builder.Append(",");
			builder.Append("Sum FTM Mean:");
			builder.Append(base.GetDetail("sum FTM mean value"));

			return builder.ToString();
		}
	}
}

// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter.Library/EarningsPerShare.cs
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
	public class EarningsPerShare : FundamentalBase
	{
		public EarningsPerShare(string name) : base(name)
		{}

		public override string FormatValue()
		{
			var builder = new StringBuilder();

			builder.Append("Q");
			builder.Append(base.GetDetail("current quarter"));
			builder.Append(" ");
			builder.Append(base.GetDetail("fiscal year"));
			builder.Append(",");

			if (base.Value < 0.01)
			{
				builder.Append(base.Value.ToString("C4"));
			}
			else
			{
				builder.Append(base.Value.ToString("C"));
			}

			builder.Append(",EPS");

			return builder.ToString();
		}
	}
}

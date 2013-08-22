// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter.Library/AnalystRating.cs
// 
// Last updated:
// 2013-08-21 2:13 PM
// =================================================

#region Usings

using System.Globalization;
using System.Text;

using WealthLabDataConverter.Library.Models.Fundamental.Base;

#endregion

namespace WealthLabDataConverter.Library.Models.Fundamental
{
	public class AnalystRating : FundamentalBase
	{
		public AnalystRating(string name) : base(name)
		{
			if (name == "analyst upgrade")
			{
				base.SetDetail("action code", "UPGRADE");
			}
			else if (name == "analyst downgrade")
			{
				base.SetDetail("action code", "DOWNGRADE");
			}
		}

		public override string FormatValue()
		{
			var builder = new StringBuilder();

			builder.Append(base.GetDetail("firm name"));
			builder.Append(",");
			builder.Append(base.GetDetail("action code"));
			builder.Append(" to ");
			builder.Append(base.GetDetail("normalized rating"));
			builder.Append(" (");
			builder.Append(base.Value.ToString(CultureInfo.InvariantCulture));
			builder.Append(") From ");
			builder.Append(base.GetDetail("prev normalized rating"));

			return builder.ToString();
		}
	}
}

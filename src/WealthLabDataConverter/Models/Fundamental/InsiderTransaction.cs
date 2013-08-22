// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter.Library/InsiderTransaction.cs
// 
// Last updated:
// 2013-08-20 11:20 PM
// =================================================

#region Usings

using System.Globalization;
using System.Text;

using WealthLabDataConverter.Library.Models.Fundamental.Base;

#endregion

namespace WealthLabDataConverter.Library.Models.Fundamental
{
	public class InsiderTransaction : FundamentalBase
	{
		public InsiderTransaction(string name) : base(name)
		{
			if (name == "insider sell")
			{
				base.SetDetail("transaction type", "S");
			}
			else if (name == "insider buy")
			{
				base.SetDetail("transaction type", "B");
			}
		}

		public override string FormatValue()
		{
			var builder = new StringBuilder();

			var flag = base.Name == "net insider transactions";

			if (base.Name == "insider buy")
			{
				builder.Append("Purchase ");
			}
			if (base.Name == "insider sell")
			{
				builder.Append("Sell ");
			}
			else
			{
				builder.Append("Net ");
			}

			builder.Append(base.Value.ToString("F0"));

			var detail = base.GetDetail("transaction type");
			var flag2 = detail == "S";
			var num3 = int.Parse(base.GetDetail("count"));

			for (var i = 1; i <= num3; i++)
			{
				builder.Append(",");

				if (flag)
				{
					builder.Append("(");
					
					var str2 = base.GetDetail("transaction type" + i);
					if (str2 != "")
					{
						builder.Append(str2);
						flag2 = str2 == "S";
					}
					else
					{
						builder.Append(detail);
					}

					builder.Append(") ");
				}

				builder.Append(base.GetDetail("insider" + i));
				builder.Append(",");
				builder.Append(base.GetDetail("title" + i));

				if (flag || (num3 > 1))
				{
					builder.Append(":");

					if (flag2)
					{
						builder.Append("(");
					}
					
					builder.Append(base.GetDetail("shares" + i));
					
					if (flag2)
					{
						builder.Append(")");
					}
				}
			}

			var result = builder.ToString();
			return result;
		}
	}
}

// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter.Library/Economics.cs
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
	public class Economics : FundamentalBase
	{
		public Economics(string name) : base(name)
		{}

		public override string FormatValue()
		{
			var builder = new StringBuilder();

			builder.Append(base.Name);
			builder.Append(":");

			if (base.Value < 0.01)
			{
				builder.Append(base.Value.ToString("C4"));
			}
			else
			{
				builder.Append(base.Value.ToString("C"));
			}

			builder.Append(",");
			builder.Append("Observation Date: ");
			builder.Append(base.GetDetail("observation date"));
			builder.Append(",");
			builder.Append("Periodicity: ");
			builder.Append(base.GetDetail("period"));
			builder.Append(",");
			builder.Append("Ref ID: ");
			builder.Append(base.GetDetail("ref id"));

			return builder.ToString();
		}
	}
}

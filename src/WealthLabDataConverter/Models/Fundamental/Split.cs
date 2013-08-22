// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter.Library/Split.cs
// 
// Last updated:
// 2013-08-21 2:10 PM
// =================================================

#region Usings

using System.Globalization;

using WealthLabDataConverter.Library.Models.Fundamental.Base;

#endregion

namespace WealthLabDataConverter.Library.Models.Fundamental
{
	public class Split : FundamentalBase
	{
		public Split(string name) : base(name)
		{}

		public override string FormatValue()
		{
			var num = 1;
			var num2 = base.Value;
			var num3 = (1 * num2) - ((int)((1 * num2) + 0.5));

			while ((num3 * num3) > 0.00025)
			{
				num++;
				num3 = (num * num2) - ((int)((num * num2) + 0.5));
				if (num > 0x3e8)
				{
					break;
				}
			}

			var objArray = new object[]
			{((int)((num * num2) + 0.5)).ToString(CultureInfo.InvariantCulture), ':', num, " Stock Split"};

			var result = string.Concat(objArray);
			return result;
		}
	}
}

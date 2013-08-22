// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter.Library/FundamentalDataConverter.cs
// 
// Last updated:
// 2013-08-22 5:40 PM
// =================================================

#region Usings

using System.Collections.Generic;
using System.IO;

using WealthLabDataConverter.Library.Helpers;
using WealthLabDataConverter.Library.Models;
using WealthLabDataConverter.Library.Models.Fundamental;
using WealthLabDataConverter.Library.Models.Fundamental.Base;

#endregion

namespace WealthLabDataConverter.Library.Core
{
	public class FundamentalDataConverter : IDataConverter
	{
		private readonly PathHelper _pathHelper;

		public FundamentalDataConverter(PathHelper pathHelper)
		{
			_pathHelper = pathHelper;
		}

		public Dictionary<string, List<FundamentalBase>> ProcessDataFromFile(string file, string provider)
		{
			var dictionary = new Dictionary<string, List<FundamentalBase>>();

			if (File.Exists(file))
			{
				var input = File.OpenRead(file);
				var reader = new BinaryReader(input);

				reader.ReadDouble();
				var num = reader.ReadInt32();

				for (var i = 0; i < num; i++)
				{
					var itemName = reader.ReadString();
					var list = new List<FundamentalBase>();

					var num4 = reader.ReadInt32();

					for (var j = 0; j < num4; j++)
					{
						var item = CreateItem(itemName, provider);
						item.ReadData(reader);
						list.Add(item);
					}

					if (!dictionary.ContainsKey(itemName))
					{
						dictionary.Add(itemName, list);
					}
				}
			}

			return dictionary;
		}

		public void SaveToFile(Dictionary<string, List<FundamentalBase>> data,
							   Parameters p,
							   string provider,
							   string securityName)
		{
			var path = ConstructSavePath(p, securityName, provider);
			_pathHelper.CreateDirectory(Path.GetDirectoryName(path));

			foreach (var fundamentals in data)
			{
				if (fundamentals.Value.Count != 0)
				{
					using (var streamWriter = new StreamWriter(path))
					{
						foreach (var f in fundamentals.Value)
						{
							var value = f.FormatValue();
							var date = f.Date.ToShortDateString();
							var line = date + p.Delimiter + value;

							streamWriter.WriteLine(line);
						}
					}
				}
			}
		}

		private FundamentalBase CreateItem(string itemName, string dataType)
		{
			switch (dataType)
			{
				case "FidelityFMDFundamental":
					if (itemName == "split")
					{
						return new Split("split");
					}
					if (itemName == "dividend")
					{
						return new Dividend("dividend");
					}

					return new FundamentalBase(itemName);

				case "FidelityWSODAnalystRatingsProvider":
					if (itemName == "all analyst ratings" ||
						itemName == "analyst downgrade" ||
						itemName == "analyst upgrade")
					{
						return new AnalystRating(itemName);
					}

					return new FundamentalBase(itemName);

				case "FidelityWSODSecuritySentimentProvider":
					switch (itemName)
					{
						case "net insider transactions":
							return new InsiderTransaction(itemName);

						case "insider buy":
							return new InsiderTransaction(itemName);

						case "insider sell":
							return new InsiderTransaction(itemName);

						case "shares short":
							return new ShortInterest(itemName);

						case "short interest as a % of shares outstanding":
							return new ShortInterest(itemName);

						case "days to cover":
							return new ShortInterest(itemName);

						case "short interest":
							return new ShortInterest(itemName);

						default:
							return new FundamentalBase(itemName);
					}

				case "FidelityWSODEconomicsProvider":
					return new Economics(itemName);

				case "FidelityWSODEstimatedEarningsProvider":
					if (itemName == "estimated earnings")
					{
						return new EstimatedEarnings(itemName);
					}

					return new FundamentalBase(itemName);

				case "FidelityWSODFundamentalProvider":
					if (itemName == "earnings per share")
					{
						return new EarningsPerShare(itemName);
					}
					if (!string.IsNullOrEmpty(Fundamentals.CheckFundamentalEntity(itemName)))
					{
						return new Fundamentals(itemName);
					}

					return new FundamentalBase(itemName);

				default:
					return new FundamentalBase(itemName);
			}
		}

		private string ConstructSavePath(Parameters p, string securityName, string provider)
		{
			const string dataTypeFolder = "Fundamentals";
			var firstLetterOfSymbol = securityName.Substring(0, 1);
			return p.OutputPath + "\\" + dataTypeFolder + "\\" + provider + "\\" + firstLetterOfSymbol + "\\" + securityName +
				   p.FileExtension;
		}
	}
}

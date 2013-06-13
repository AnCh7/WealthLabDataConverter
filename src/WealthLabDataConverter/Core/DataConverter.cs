// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter.Library/DataConverter.cs
// 
// Last updated:
// 2013-06-13 11:51 AM
// =================================================

#region Usings

using System;
using System.Collections.Generic;
using System.IO;

using WealthLabDataConverter.Library.Helpers;
using WealthLabDataConverter.Library.Models;

#endregion

namespace WealthLabDataConverter.Library.Core
{
	public class DataConverter : IDataConverter
	{
		private readonly List<DateTime> _listDateTime = new List<DateTime>();
		private readonly PathHelper _pathHelper;

		public DataConverter(PathHelper pathHelper)
		{
			_pathHelper = pathHelper;
		}

		public List<MarketData> LoadFromFile(string fileName,
											  out string securityName,
											  out string timeFrameName,
											  out int timeFrameInterval)
		{
			var data = new List<MarketData>();

			using (var input = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				using (var reader = new BinaryReader(input))
				{
					var value1 = reader.ReadDouble();
					securityName = reader.ReadString();
					var fullSecurityName = reader.ReadString();
					timeFrameName = TimeFrame.GetTimeFrame(reader.ReadInt32());
					timeFrameInterval = reader.ReadInt32();
					var value2 = reader.ReadInt32();
					var value3 = reader.ReadInt32();

					for (var i = 0; i < value3; i++)
					{
						var seriesName = reader.ReadString();
						var sumOnCollapse = reader.ReadBoolean();
					}

					if (value1 >= 2.0)
					{
						var securityType = reader.ReadInt32();
					}

					if (value1 >= 3.0)
					{
						var value6 = reader.ReadInt32();

						while (value6 > 0)
						{
							value6--;
							_listDateTime.Add(new DateTime(reader.ReadInt64()));
						}
					}

					while (value2 > 0)
					{
						var md = new MarketData();

						md.DateTime = new DateTime(reader.ReadInt64());
						md.Open = reader.ReadDouble();
						md.High = reader.ReadDouble();
						md.Low = reader.ReadDouble();
						md.Close = reader.ReadDouble();
						md.Volume = reader.ReadDouble();

						value2--;

						data.Add(md);
					}
				}
			}

			return data;
		}

		public void SaveToFile(List<MarketData> data,
							   Parameters p,
							   string securityName,
							   string timeFrameName,
							   int timeFrameInterval)
		{
			var path = ConstructSavePath(p, securityName, timeFrameName, timeFrameInterval);
			_pathHelper.CreateDirectory(Path.GetDirectoryName(path));

			using (var streamWriter = new StreamWriter(path))
			{
				foreach (var d in data)
				{
					string dt;

					if (timeFrameInterval == 0)
					{
						dt = d.DateTime.ToString(p.DateFormat);
					}
					else
					{
						dt = d.DateTime.ToString(p.DateFormat + p.DateTimeDelimiter + p.TimeFormat);
					}

					streamWriter.WriteLine(dt + p.Delimiter +
										   d.Open.ToString(p.OHLCFormat) + p.Delimiter +
										   d.High.ToString(p.OHLCFormat) + p.Delimiter +
										   d.Low.ToString(p.OHLCFormat) + p.Delimiter +
										   d.Close.ToString(p.OHLCFormat) + p.Delimiter +
										   d.Volume.ToString(p.VFormat));
				}
			}
		}

		private string ConstructSavePath(Parameters p, string securityName, string timeFrameName, int timeFrameInterval)
		{
			const string slash = "\\";

			var pathToFolder = p.OutputPath;
			string timeFramePath;
			var symbolName = securityName;
			var fileExtension = p.FileExtension;

			if (timeFrameInterval == 0)
			{
				timeFramePath = TimeFrame.GetTimeFrame(0);
			}
			else
			{
				timeFramePath = timeFrameInterval + " " + timeFrameName.ToLower();
			}

			var firstLetterOfSymbol = securityName.Substring(0, 1);

			return pathToFolder + slash + timeFramePath + slash + firstLetterOfSymbol + slash + symbolName + fileExtension;
		}
	}
}

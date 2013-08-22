// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter.Library/FundamentalBase.cs
// 
// Last updated:
// 2013-08-22 12:05 PM
// =================================================

#region Usings

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

#endregion

namespace WealthLabDataConverter.Library.Models.Fundamental.Base
{
	public class FundamentalBase
	{
		private Dictionary<string, string> _items;

		public FundamentalBase(string name)
		{
			Name = name;
		}

		public DateTime Date { get; set; }
		public string Name { get; private set; }
		public double Value { get; set; }

		public virtual string FormatValue()
		{
			string result;

			if (Value < 0.01)
			{
				result = (Name + ":" + Value);
			}
			else
			{
				result = (Name + ":" + Value.ToString("F2"));
			}
			
			return result;
		}

		public string GetDetail(string detailName)
		{
			if ((_items != null) &&
				_items.ContainsKey(detailName))
			{
				return _items[detailName];
			}

			return "";
		}

		internal void ReadData(BinaryReader binaryData)
		{
			Date = new DateTime(binaryData.ReadInt64());
			Value = binaryData.ReadDouble();

			var num = binaryData.ReadInt32();
			if (num == 0)
			{
				_items = null;
			}
			else
			{
				_items = new Dictionary<string, string>();
				for (var i = 0; i < num; i++)
				{
					var key = binaryData.ReadString();
					var str2 = binaryData.ReadString();
					_items.Add(key, str2);
				}
			}
		}

		public void SetDetail(string detailName, string value)
		{
			if (_items == null)
			{
				_items = new Dictionary<string, string>();
			}

			_items[detailName] = value;
		}
	}
}

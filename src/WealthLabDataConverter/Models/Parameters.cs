// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter.Library/Parameters.cs
// 
// Last updated:
// 2013-06-13 11:56 AM
// =================================================

namespace WealthLabDataConverter.Library.Models
{
	public class Parameters
	{
		public string Delimiter { get; set; }

		public string FileExtension { get; set; }

		public string DateFormat { get; set; }
		public string DateTimeDelimiter { get; set; }
		public string TimeFormat { get; set; }

		public string OHLCFormat { get; set; }
		public string VFormat { get; set; }

		public string InputPath { get; set; }
		public string OutputPath { get; set; }
	}
}

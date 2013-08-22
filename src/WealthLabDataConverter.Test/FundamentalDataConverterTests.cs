// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter.Test/FundamentalDataConverterTests.cs
// 
// Last updated:
// 2013-08-22 11:19 PM
// =================================================

#region Usings

using NUnit.Framework;

using WealthLabDataConverter.Library.Core;
using WealthLabDataConverter.Library.Helpers;

#endregion

namespace WealthLabDataConverter.Test
{
	[TestFixture]
	public class FundamentalDataConverterTests
	{
		[Test]
		public void FidelityFMDFundamentalProvider()
		{
			var p = new PathHelper();
			var f = new FundamentalDataConverter(p);

			const string path =
				@"D:\WealthLabDataConverter\WealthLabDataConverter.Test\FundamentalData\FidelityFMDFundamentalProvider_ABCB.WLF";
			f.ProcessDataFromFile(path, "FidelityFMDFundamentalProvider");
		}

		[Test]
		public void FidelityWSODAnalystRatingsProvider()
		{
			var p = new PathHelper();
			var f = new FundamentalDataConverter(p);

			var path =
				@"D:\WealthLabDataConverter\WealthLabDataConverter.Test\FundamentalData\FidelityWSODAnalystRatingsProvider_AAPL.WLF";
			f.ProcessDataFromFile(path, "FidelityWSODAnalystRatingsProvider");
		}

		[Test]
		public void FidelityWSODEconomicsProvider()
		{
			var p = new PathHelper();
			var f = new FundamentalDataConverter(p);

			var path = @"D:\WealthLabDataConverter\WealthLabDataConverter.Test\FundamentalData\";
			f.ProcessDataFromFile(path, "FidelityWSODEconomicsProvider");
		}

		[Test]
		public void FidelityWSODEstimatedEarningsProvider()
		{
			var p = new PathHelper();
			var f = new FundamentalDataConverter(p);

			var path =
				@"D:\WealthLabDataConverter\WealthLabDataConverter.Test\FundamentalData\FidelityWSODEstimatedEarningsProvider_AKAM.WLF";
			f.ProcessDataFromFile(path, "FidelityWSODEstimatedEarningsProvider");
		}

		[Test]
		public void FidelityWSODFundamentalProvider()
		{
			var p = new PathHelper();
			var f = new FundamentalDataConverter(p);

			var path =
				@"D:\WealthLabDataConverter\WealthLabDataConverter.Test\FundamentalData\FidelityWSODFundamentalProvider_ACAS.WLF";
			f.ProcessDataFromFile(path, "FidelityWSODFundamentalProvider");
		}

		[Test]
		public void FidelityWSODSecuritySentimentProvider()
		{
			var p = new PathHelper();
			var f = new FundamentalDataConverter(p);

			var path =
				@"D:\WealthLabDataConverter\WealthLabDataConverter.Test\FundamentalData\FidelityWSODSecuritySentimentProvider_AAPL.WLF";
			f.ProcessDataFromFile(path, "FidelityWSODSecuritySentimentProvider");
		}
	}
}

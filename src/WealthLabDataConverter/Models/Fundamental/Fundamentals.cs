// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter.Library/Fundamentals.cs
// 
// Last updated:
// 2013-08-21 2:07 PM
// =================================================

#region Usings

using System.Globalization;
using System.Text;

using WealthLabDataConverter.Library.Models.Fundamental.Base;

#endregion

namespace WealthLabDataConverter.Library.Models.Fundamental
{
	public class Fundamentals : FundamentalBase
	{
		private static readonly string[] Entities = new[]
		{
			"employee", "assets", "current assets", "long term debt", "liabilities", "current liabilities", "stockholder equity",
			"common shares outstanding", "adjustment factor", "sales turnover", "operating income before depreciation",
			"pretax income", "net income", "operating activities", "cash dividends", "cash", "fiscal year", "fiscal quarter",
			"total receivables", "total inventories", "ebit", "property plant and equipment", "accounts payable", "goodwill",
			"interest expense", "common shares used to calculate eps diluted", "stock compensation expense",
			"research and development expense"
		};

		private static readonly string[] Descriptions = new[]
		{
			"Thousands; Employee represents the number of company workers as reported to shareholders. This is reported by some firms as an average number of employees and by some as the number of employees at year-end. No attempt has been made to differentiate between these bases of reporting. If both are given, the year-end figure is used.",
			"Millions USD; Quarterly; Assets represents the total value of assets reported on the balance sheet.",
			"Millions USD; Quarterly; Current assets represents cash and other assets that are expected to be realized in cash or used in the production of revenue within the next 12 months.",
			"Millions USD; Quarterly; Long term debt represents debt obligations due more than one year from the company's balance sheet date.",
			"Millions USD; Quarterly; Liabilities represents current liabilities plus long-term debt plus other noncurrent liabilities (including deferred taxes and investment tax credit).",
			"Millions USD; Quarterly; Current liabilities represents liabilities due within one year, including the current portion of long-term debt.",
			"Millions USD; Quarterly; Stockholder equity represents the common and preferred shareholders' interest in the company.",
			"Millions of shares; Quarterly; Common shares outstanding represents the net number of all common shares outstanding at year-end, excluding treasury shares and scrip.",
			"Per share ratio; Quarterly; Adjustment factor represents a ratio that enables you to adjust per-share data (such as, price, earnings per share, and dividends per share), as well as share data (such as, shares outstanding and shares traded) for all stock splits and stock dividends that occur subsequent to the end of a given period.",
			"Millions USD; Quarterly; Sales turnover represents gross sales (the amount of actual billings to customers for regular sales completed during the period) reduced by cash discounts, trade discounts, and returned sales and allowances for which credit is given to customers.",
			"Millions USD; Quarterly; Operating income before depreciation includes the effects of adjustments for Cost of Goods Sold and Selling, General, and Administrative Expenses.",
			"Millions USD; Quarterly; Pretax income represents operating and nonoperating income before provisions for income taxes and minority interest.",
			"Millions USD; Quarterly; Net income represents the income or loss reported by a company after expenses and losses have been subtracted from all revenues and gains for the fiscal period including extraordinary items and discontinued operations.",
			"Millions USD; Quarterly; Operating activities represents the net change in cash from all items classified in the Operating Activities section on a Statement of Cash Flows (Format Code = 7).",
			"Millions USD; Quarterly; Cash dividends represents the total amount of cash dividends for common/ordinary capital, preferred/preference capital and other share capital.",
			"Millions USD; Quarterly; Cash represents any immediately negotiable medium of exchange or any instruments normally accepted by banks for deposit and immediate credit to a customer's account.",
			"Fiscal year represents the fiscal year of the current fiscal year-end month.",
			"Fiscal quarter identifies the fiscal quarter of the company by the code 1, 2, 3 or 4, depending upon the quartile of the fiscal year in which the data falls. It consists of a one-character numeric code for the quarter.",
			"Millions USD; Quarterly; Total receivables includes all debts owed the company.",
			"Millions USD; Quarterly; Total inventories represents merchandise bought for resale and materials and supplies purchased for use in production of revenue.",
			"Millions USD; Quarterly; Earnings before interest and taxes represents all profits before taking into account interest payments and income taxes.",
			"Millions USD; Quarterly; Property plant and equipment represents the cost, less accumulated depreciation, of tangible fixed property used in the production of revenue.",
			"Millions USD; Quarterly; Accounts payable represents the obligations due within one year of the normal operating cycle of the company",
			"Millions USD; Quarterly; Goodwill represents excess of the purchase price over the fair market value of an asset.",
			"Millions USD; Quarterly; Interest expense is the periodic expense to the company of securing short and long term debt.",
			"Millions of shares; Annually; Common shares used to calculate eps diluted is the number of shares used by the company to calculate diluted earnings per share.",
			"Millions of shares; Quarterly; Stock compensation expense is a pre-tax item that represents compensation of employees/executives in the form of company stock.",
			"Millions of shares; Quarterly; Research and development expense represents all costs incurred during the year related to development of new products or services"
		};

		public Fundamentals(string name) : base(name)
		{}

		public override string FormatValue()
		{
			var builder = new StringBuilder();

			builder.Append("Q");
			builder.Append(base.GetDetail("current quarter"));
			builder.Append(" ");
			builder.Append(base.GetDetail("fiscal year"));
			builder.Append(",");
			builder.Append(base.Name);
			builder.Append(":");
			builder.Append(FormatValue(base.Name, base.Value));

			return builder.ToString();
		}

		public static string CheckFundamentalEntity(string itemName)
		{
			for (var i = 0; i < Entities.Length; i++)
			{
				if (Entities[i] == itemName)
				{
					return (Descriptions.GetValue(i) as string);
				}
			}

			return "";
		}

		private string FormatValue(string itemName, double value)
		{
			if (itemName == "employee")
			{
				return (value.ToString(CultureInfo.InvariantCulture) + " (thousands)");
			}
			if ((itemName == "common shares outstanding") ||
				(itemName == "common shares used to calculate eps diluted"))
			{
				return (value.ToString("F2") + " (millions)");
			}
			if (itemName == "adjustment factor")
			{
				return value.ToString(CultureInfo.InvariantCulture);
			}
			if (itemName == "fiscal year")
			{
				return value.ToString(CultureInfo.InvariantCulture);
			}
			if (itemName == "fiscal quarter")
			{
				return ("Q" + value.ToString(CultureInfo.InvariantCulture));
			}
			if (value < 0.01)
			{
				return (value.ToString("C4") + " millions (USD)");
			}

			return (value.ToString("C") + " millions (USD)");
		}
	}
}

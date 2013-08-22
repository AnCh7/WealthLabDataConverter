// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter/MainForm.cs
// 
// Last updated:
// 2013-08-22 12:48 AM
// =================================================

#region Usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Practices.Unity;

using WealthLabDataConverter.Library.Core;
using WealthLabDataConverter.Library.DI;
using WealthLabDataConverter.Library.Helpers;
using WealthLabDataConverter.Library.Logging;
using WealthLabDataConverter.Library.Models;

#endregion

namespace WealthLabDataConverter
{
	public partial class MainForm : Form
	{
		private IMyLogger _logger;

		private PathHelper _pathHelper;
		private QuotesDataConverter _quotesDataConverter;
		private FundamentalDataConverter _fundamentalDataConverter;

		private CancellationTokenSource _token;

		public MainForm()
		{
			InitializeComponent();
			InitAsyncRelated();
			InitDependencies();
			SetDefaultValues();
		}

		private async void btnStart_Click(object sender, EventArgs e)
		{
			LockControls();

			if (CheckSavePath(tbOutputFolder.Text))
			{
				if (_pathHelper.IsValidPath(tbInputFolder.Text))
				{
					var parameters = LoadProgramParameters();

					var quotesFiles = GetQuotesFiles(parameters.InputPath);
					var fundamentalFiles = GetFundamentalFiles(parameters.InputPath, parameters.FundamentalProviders);

					var quotesResult = await ConvertQuotesAsync(parameters, quotesFiles);
					_logger.Info(quotesResult);

					var fundamentalsResult = await ConvertFundamentalsAsync(parameters, fundamentalFiles);
					_logger.Info(fundamentalsResult);
				}
			}

			UnlockControls();
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			_token.Cancel();
		}
		
		private void btnClean_Click(object sender, EventArgs e)
		{
			rtbLog.Clear();
		}

		private void btnOutputFolderDialog_Click(object sender, EventArgs e)
		{
			var dialog = new FolderBrowserDialog();
			dialog.ShowDialog();
			tbOutputFolder.Text = dialog.SelectedPath;
		}

		private void btnInputFolderDialog_Click(object sender, EventArgs e)
		{
			var dialog = new FolderBrowserDialog();
			dialog.ShowDialog();
			tbInputFolder.Text = dialog.SelectedPath;
		}

		#region Private

		private IEnumerable<string> GetQuotesFiles(string folder)
		{
			var files = new List<string>();

			try
			{
				files = new List<string>(Directory.GetFiles(folder, "*.WL", SearchOption.AllDirectories));
				_logger.Info(string.Format("Found {0} files", files.Count));
			}
			catch (Exception ex)
			{
				_logger.Info(string.Format("Error {0}", ex.Message));
			}

			return files;
		}

		private Dictionary<string, List<string>> GetFundamentalFiles(string folder, IEnumerable<string> fundamentalProviders)
		{
			var files = new Dictionary<string, List<string>>();

			foreach (var pr in fundamentalProviders)
			{
				try
				{
					var newFolder = folder + "\\" + pr;
					var fList = new List<string>(Directory.GetFiles(newFolder, "*.WLF", SearchOption.AllDirectories));
					_logger.Info(string.Format("Found {0} fundamental files for {1} provider", fList.Count, pr));
					files.Add(pr, fList);
				}
				catch (Exception ex)
				{
					_logger.Info(string.Format("Error {0}", ex.Message));
				}
			}

			return files;
		}

		private Parameters LoadProgramParameters()
		{
			var parameters = new Parameters();

			parameters.DateFormat = cbDTFormatDate.Text;
			parameters.DateTimeDelimiter = cbDTFormatDelimiter.Text;
			parameters.TimeFormat = cbDTFormatTime.Text;

			if (cbDTFormatDelimiter.Text == @"Space")
			{
				parameters.DateTimeDelimiter = " ";
			}

			if (cbDTFormatDelimiter.Text == @"Tab")
			{
				parameters.DateTimeDelimiter = "	";
			}

			parameters.Delimiter = cbDataDelimiter.Text;

			parameters.InputPath = tbInputFolder.Text;
			parameters.OutputPath = tbOutputFolder.Text;

			parameters.FileExtension = cbFileFormat.Text;
			parameters.OHLCFormat = cbOHLC.Text;
			parameters.VFormat = cbVolume.Text;

			ReadCheckboxes(parameters);

			return parameters;
		}

		private void ReadCheckboxes(Parameters parameters)
		{
			if (cbAnalystRatings.Checked)
			{
				parameters.FundamentalProviders.Add(cbAnalystRatings.Text);
			}

			if (cbEconomics.Checked)
			{
				parameters.FundamentalProviders.Add(cbEconomics.Text);
			}

			if (cbEstimatedEarnings.Checked)
			{
				parameters.FundamentalProviders.Add(cbEstimatedEarnings.Text);
			}

			if (cbSecuritySentiment.Checked)
			{
				parameters.FundamentalProviders.Add(cbSecuritySentiment.Text);
			}

			if (cbFMDFundamental.Checked)
			{
				parameters.FundamentalProviders.Add(cbFMDFundamental.Text);
			}

			if (cbWSODFundamental.Checked)
			{
				parameters.FundamentalProviders.Add(cbWSODFundamental.Text);
			}
		}

		private void InitDependencies()
		{
			DependencyFactory.Container.RegisterInstance(new RichTextBoxAppender(rtbLog));

			_logger = DependencyFactory.Container.Resolve<IMyLogger>(new ParameterOverride("currentClassName", "MainForm"));
			_quotesDataConverter = (QuotesDataConverter)DependencyFactory.Container.Resolve<IDataConverter>("Quotes");
			_fundamentalDataConverter =
				(FundamentalDataConverter)DependencyFactory.Container.Resolve<IDataConverter>("Fundamental");
			_pathHelper = DependencyFactory.Container.Resolve<PathHelper>();
		}

		private void SetDefaultValues()
		{
			const string defaultPath = @"\Fidelity Investments\WealthLabPro\1.0.0.0\Data\FidelityStaticProvider";
			tbInputFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + defaultPath;

			tbOutputFolder.Text = @"C:\Output";

			cbDTFormatDate.SelectedIndex = 0;
			cbDTFormatDelimiter.SelectedIndex = 0;
			cbDTFormatTime.SelectedIndex = 0;
			cbDataDelimiter.SelectedIndex = 0;
			cbFileFormat.SelectedIndex = 0;
			cbOHLC.SelectedIndex = 2;
			cbVolume.SelectedIndex = 0;

			cbAnalystRatings.Checked = true;
			cbEconomics.Checked = true;
			cbEstimatedEarnings.Checked = true;
			cbSecuritySentiment.Checked = true;
			cbFMDFundamental.Checked = true;
			cbWSODFundamental.Checked = true;
		}

		private void UnlockControls()
		{
			btnInputFolderDialog.Enabled = true;
			btnOutputFolderDialog.Enabled = true;

			tbInputFolder.Enabled = true;
			tbOutputFolder.Enabled = true;
			cbDTFormatDate.Enabled = true;
			cbDTFormatDelimiter.Enabled = true;
			cbDTFormatTime.Enabled = true;
			cbDataDelimiter.Enabled = true;
			cbFileFormat.Enabled = true;

			cbOHLC.Enabled = true;
			cbVolume.Enabled = true;

			btnStart.Enabled = true;

			cbAnalystRatings.Enabled = true;
			cbEconomics.Enabled = true;
			cbEstimatedEarnings.Enabled = true;
			cbSecuritySentiment.Enabled = true;
			cbFMDFundamental.Enabled = true;
			cbWSODFundamental.Enabled = true;
		}

		private void LockControls()
		{
			btnInputFolderDialog.Enabled = false;
			btnOutputFolderDialog.Enabled = false;

			tbInputFolder.Enabled = false;
			tbOutputFolder.Enabled = false;
			cbDTFormatDate.Enabled = false;
			cbDTFormatDelimiter.Enabled = false;
			cbDTFormatTime.Enabled = false;
			cbDataDelimiter.Enabled = false;
			cbFileFormat.Enabled = false;
			cbOHLC.Enabled = false;
			cbVolume.Enabled = false;

			btnStart.Enabled = false;

			cbAnalystRatings.Enabled = false;
			cbEconomics.Enabled = false;
			cbEstimatedEarnings.Enabled = false;
			cbSecuritySentiment.Enabled = false;
			cbFMDFundamental.Enabled = false;
			cbWSODFundamental.Enabled = false;
		}

		private bool CheckSavePath(string pathName)
		{
			var isValid = true;

			if (!_pathHelper.CreateDirectory(pathName))
			{
				_logger.Error("Wrong directory name");
				isValid = false;
			}

			return isValid;
		}

		#endregion

		#region Async

		private void InitAsyncRelated()
		{
			_token = new CancellationTokenSource();
		}

		private async Task<string> ConvertQuotesAsync(Parameters parameters, IEnumerable<string> fileNames)
		{
			var result = await Task.Factory.StartNew(() => ProcessQuotesAsync(parameters, fileNames));
			return result;
		}

		private async Task<string> ConvertFundamentalsAsync(Parameters parameters, Dictionary<string, List<string>> fileNames)
		{
			var result = await Task.Factory.StartNew(() => ProcessFundamentalsAsync(parameters, fileNames));
			return result;
		}

		private string ProcessQuotesAsync(Parameters parameters, IEnumerable<string> fileNames)
		{
			foreach (var filename in fileNames)
			{
				_logger.Info(String.Format("Converting symbol: {0}", Path.GetFileName(filename)));

				if (_token.IsCancellationRequested)
				{
					_logger.Info("Stopping proccess...");
					InitAsyncRelated();
					return "Canceled";
				}

				string securityName;
				string timeFrameName;
				int timeFrameInterval;

				var data = _quotesDataConverter.ProcessDataFromFile(filename,
																	out securityName,
																	out timeFrameName,
																	out timeFrameInterval);

				_quotesDataConverter.SaveToFile(data, parameters, securityName, timeFrameName, timeFrameInterval);
			}

			return "Quotes parsed";
		}

		private string ProcessFundamentalsAsync(Parameters parameters, Dictionary<string, List<string>> fundamentals)
		{
			foreach (var provider in fundamentals)
			{
				foreach (var file in provider.Value)
				{
					var security = Path.GetFileNameWithoutExtension(file);
					_logger.Info(String.Format("Converting symbol: {0}", security));

					if (_token.IsCancellationRequested)
					{
						_logger.Info("Stopping proccess...");
						InitAsyncRelated();
						return "Canceled";
					}

					var data = _fundamentalDataConverter.ProcessDataFromFile(file, provider.Key);
					_fundamentalDataConverter.SaveToFile(data, parameters, provider.Key, security);
				}
			}

			return "Fundamentals parsed";
		}

		#endregion Async
	}
}

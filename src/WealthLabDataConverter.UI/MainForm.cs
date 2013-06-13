// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter/MainForm.cs
// 
// Last updated:
// 2013-06-13 12:41 PM
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
		private DataConverter _converter;
		private MyLogger _logger;
		private PathHelper _pathHelper;
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
					var fileNames = GetFilenamesList(parameters.InputPath);
					var result = await ConvertDataAsync(parameters, fileNames);

					_logger.Info(result);
				}
			}

			UnlockControls();
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			_token.Cancel();
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

		private IEnumerable<string> GetFilenamesList(string folder)
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

			return parameters;
		}

		private void InitDependencies()
		{
			DependencyFactory.Container.RegisterInstance(new RichTextBoxAppender(rtbLog));

			_logger =
				(MyLogger)DependencyFactory.Container.Resolve<IMyLogger>(new ParameterOverride("currentClassName", "MainForm"));
			_converter = (DataConverter)DependencyFactory.Container.Resolve<IDataConverter>();
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

		private async Task<string> ConvertDataAsync(Parameters parameters, IEnumerable<string> fileNames)
		{
			await Task.Factory.StartNew(() => ProcessAsync(parameters, fileNames));
			return "Done";
		}

		private void ProcessAsync(Parameters parameters, IEnumerable<string> fileNames)
		{
			foreach (var filename in fileNames)
			{
				_logger.Info(String.Format("Converting symbol: {0}", Path.GetFileName(filename)));

				if (_token.IsCancellationRequested)
				{
					_logger.Info("Stopping proccess...");
					InitAsyncRelated();
					return;
				}

				string securityName;
				string timeFrameName;
				int timeFrameInterval;

				var data = _converter.LoadFromFile(filename, out securityName, out timeFrameName, out timeFrameInterval);
				_converter.SaveToFile(data, parameters, securityName, timeFrameName, timeFrameInterval);
			}
		}

		#endregion Async
	}
}

namespace WealthLabDataConverter
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tbOutputFolder = new System.Windows.Forms.TextBox();
			this.btnOutputFolderDialog = new System.Windows.Forms.Button();
			this.lbOutputFolder = new System.Windows.Forms.Label();
			this.tbInputFolder = new System.Windows.Forms.TextBox();
			this.btnInputFolderDialog = new System.Windows.Forms.Button();
			this.lblInputFolder = new System.Windows.Forms.Label();
			this.lblLog = new System.Windows.Forms.Label();
			this.rtbLog = new System.Windows.Forms.RichTextBox();
			this.gpbParameters = new System.Windows.Forms.GroupBox();
			this.cbVolume = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbOHLC = new System.Windows.Forms.ComboBox();
			this.lblOHLCDigits = new System.Windows.Forms.Label();
			this.cbFileFormat = new System.Windows.Forms.ComboBox();
			this.lblFileFormat = new System.Windows.Forms.Label();
			this.cbDataDelimiter = new System.Windows.Forms.ComboBox();
			this.lblDelimiter = new System.Windows.Forms.Label();
			this.cbDTFormatDelimiter = new System.Windows.Forms.ComboBox();
			this.cbDTFormatTime = new System.Windows.Forms.ComboBox();
			this.cbDTFormatDate = new System.Windows.Forms.ComboBox();
			this.lblDateTimeFormat = new System.Windows.Forms.Label();
			this.gpbFolders = new System.Windows.Forms.GroupBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cbEconomics = new System.Windows.Forms.CheckBox();
			this.cbSecuritySentiment = new System.Windows.Forms.CheckBox();
			this.cbWSODFundamental = new System.Windows.Forms.CheckBox();
			this.cbEstimatedEarnings = new System.Windows.Forms.CheckBox();
			this.cbAnalystRatings = new System.Windows.Forms.CheckBox();
			this.cbFMDFundamental = new System.Windows.Forms.CheckBox();
			this.btnClean = new System.Windows.Forms.Button();
			this.gpbParameters.SuspendLayout();
			this.gpbFolders.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbOutputFolder
			// 
			this.tbOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutputFolder.Location = new System.Drawing.Point(156, 49);
			this.tbOutputFolder.Name = "tbOutputFolder";
			this.tbOutputFolder.Size = new System.Drawing.Size(274, 20);
			this.tbOutputFolder.TabIndex = 2;
			// 
			// btnOutputFolderDialog
			// 
			this.btnOutputFolderDialog.Location = new System.Drawing.Point(85, 47);
			this.btnOutputFolderDialog.Name = "btnOutputFolderDialog";
			this.btnOutputFolderDialog.Size = new System.Drawing.Size(65, 23);
			this.btnOutputFolderDialog.TabIndex = 21;
			this.btnOutputFolderDialog.Text = "Choose...";
			this.btnOutputFolderDialog.UseVisualStyleBackColor = true;
			this.btnOutputFolderDialog.Click += new System.EventHandler(this.btnOutputFolderDialog_Click);
			// 
			// lbOutputFolder
			// 
			this.lbOutputFolder.AutoSize = true;
			this.lbOutputFolder.Location = new System.Drawing.Point(5, 52);
			this.lbOutputFolder.Name = "lbOutputFolder";
			this.lbOutputFolder.Size = new System.Drawing.Size(74, 13);
			this.lbOutputFolder.TabIndex = 22;
			this.lbOutputFolder.Text = "Output Folder:";
			// 
			// tbInputFolder
			// 
			this.tbInputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbInputFolder.Location = new System.Drawing.Point(156, 19);
			this.tbInputFolder.Name = "tbInputFolder";
			this.tbInputFolder.Size = new System.Drawing.Size(274, 20);
			this.tbInputFolder.TabIndex = 1;
			// 
			// btnInputFolderDialog
			// 
			this.btnInputFolderDialog.Location = new System.Drawing.Point(85, 17);
			this.btnInputFolderDialog.Name = "btnInputFolderDialog";
			this.btnInputFolderDialog.Size = new System.Drawing.Size(65, 23);
			this.btnInputFolderDialog.TabIndex = 25;
			this.btnInputFolderDialog.Text = "Choose...";
			this.btnInputFolderDialog.UseVisualStyleBackColor = true;
			this.btnInputFolderDialog.Click += new System.EventHandler(this.btnInputFolderDialog_Click);
			// 
			// lblInputFolder
			// 
			this.lblInputFolder.AutoSize = true;
			this.lblInputFolder.Location = new System.Drawing.Point(5, 22);
			this.lblInputFolder.Name = "lblInputFolder";
			this.lblInputFolder.Size = new System.Drawing.Size(66, 13);
			this.lblInputFolder.TabIndex = 26;
			this.lblInputFolder.Text = "Input Folder:";
			// 
			// lblLog
			// 
			this.lblLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblLog.AutoSize = true;
			this.lblLog.Location = new System.Drawing.Point(4, 328);
			this.lblLog.Name = "lblLog";
			this.lblLog.Size = new System.Drawing.Size(28, 13);
			this.lblLog.TabIndex = 29;
			this.lblLog.Text = "Log:";
			// 
			// rtbLog
			// 
			this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtbLog.Location = new System.Drawing.Point(7, 344);
			this.rtbLog.Name = "rtbLog";
			this.rtbLog.ReadOnly = true;
			this.rtbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.rtbLog.Size = new System.Drawing.Size(436, 194);
			this.rtbLog.TabIndex = 30;
			this.rtbLog.Text = "";
			// 
			// gpbParameters
			// 
			this.gpbParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gpbParameters.Controls.Add(this.cbVolume);
			this.gpbParameters.Controls.Add(this.label1);
			this.gpbParameters.Controls.Add(this.cbOHLC);
			this.gpbParameters.Controls.Add(this.lblOHLCDigits);
			this.gpbParameters.Controls.Add(this.cbFileFormat);
			this.gpbParameters.Controls.Add(this.lblFileFormat);
			this.gpbParameters.Controls.Add(this.cbDataDelimiter);
			this.gpbParameters.Controls.Add(this.lblDelimiter);
			this.gpbParameters.Controls.Add(this.cbDTFormatDelimiter);
			this.gpbParameters.Controls.Add(this.cbDTFormatTime);
			this.gpbParameters.Controls.Add(this.cbDTFormatDate);
			this.gpbParameters.Controls.Add(this.lblDateTimeFormat);
			this.gpbParameters.Location = new System.Drawing.Point(7, 100);
			this.gpbParameters.Name = "gpbParameters";
			this.gpbParameters.Size = new System.Drawing.Size(436, 108);
			this.gpbParameters.TabIndex = 31;
			this.gpbParameters.TabStop = false;
			this.gpbParameters.Text = "Parameters";
			// 
			// cbVolume
			// 
			this.cbVolume.FormattingEnabled = true;
			this.cbVolume.Items.AddRange(new object[] {
            "0.",
            "0.0",
            "0.00"});
			this.cbVolume.Location = new System.Drawing.Point(308, 76);
			this.cbVolume.Name = "cbVolume";
			this.cbVolume.Size = new System.Drawing.Size(122, 21);
			this.cbVolume.TabIndex = 64;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(257, 79);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 13);
			this.label1.TabIndex = 63;
			this.label1.Text = "Volume:";
			// 
			// cbOHLC
			// 
			this.cbOHLC.FormattingEnabled = true;
			this.cbOHLC.Items.AddRange(new object[] {
            "0.",
            "0.0",
            "0.00",
            "0.000",
            "0.0000"});
			this.cbOHLC.Location = new System.Drawing.Point(308, 49);
			this.cbOHLC.Name = "cbOHLC";
			this.cbOHLC.Size = new System.Drawing.Size(122, 21);
			this.cbOHLC.TabIndex = 62;
			// 
			// lblOHLCDigits
			// 
			this.lblOHLCDigits.AutoSize = true;
			this.lblOHLCDigits.Location = new System.Drawing.Point(263, 52);
			this.lblOHLCDigits.Name = "lblOHLCDigits";
			this.lblOHLCDigits.Size = new System.Drawing.Size(39, 13);
			this.lblOHLCDigits.TabIndex = 61;
			this.lblOHLCDigits.Text = "OHLC:";
			// 
			// cbFileFormat
			// 
			this.cbFileFormat.FormattingEnabled = true;
			this.cbFileFormat.Items.AddRange(new object[] {
            ".csv",
            ".txt"});
			this.cbFileFormat.Location = new System.Drawing.Point(95, 76);
			this.cbFileFormat.Name = "cbFileFormat";
			this.cbFileFormat.Size = new System.Drawing.Size(106, 21);
			this.cbFileFormat.TabIndex = 60;
			// 
			// lblFileFormat
			// 
			this.lblFileFormat.AutoSize = true;
			this.lblFileFormat.Location = new System.Drawing.Point(6, 79);
			this.lblFileFormat.Name = "lblFileFormat";
			this.lblFileFormat.Size = new System.Drawing.Size(75, 13);
			this.lblFileFormat.TabIndex = 59;
			this.lblFileFormat.Text = "File Extension:";
			// 
			// cbDataDelimiter
			// 
			this.cbDataDelimiter.FormattingEnabled = true;
			this.cbDataDelimiter.Items.AddRange(new object[] {
            ",",
            ":",
            ";",
            "/",
            "\\"});
			this.cbDataDelimiter.Location = new System.Drawing.Point(95, 49);
			this.cbDataDelimiter.Name = "cbDataDelimiter";
			this.cbDataDelimiter.Size = new System.Drawing.Size(106, 21);
			this.cbDataDelimiter.TabIndex = 58;
			// 
			// lblDelimiter
			// 
			this.lblDelimiter.AutoSize = true;
			this.lblDelimiter.Location = new System.Drawing.Point(5, 52);
			this.lblDelimiter.Name = "lblDelimiter";
			this.lblDelimiter.Size = new System.Drawing.Size(76, 13);
			this.lblDelimiter.TabIndex = 57;
			this.lblDelimiter.Text = "Data Delimiter:";
			// 
			// cbDTFormatDelimiter
			// 
			this.cbDTFormatDelimiter.FormattingEnabled = true;
			this.cbDTFormatDelimiter.Items.AddRange(new object[] {
            "Space",
            "Tab",
            ",",
            ".",
            ":",
            ";",
            "/",
            "\\",
            "-"});
			this.cbDTFormatDelimiter.Location = new System.Drawing.Point(207, 22);
			this.cbDTFormatDelimiter.Name = "cbDTFormatDelimiter";
			this.cbDTFormatDelimiter.Size = new System.Drawing.Size(95, 21);
			this.cbDTFormatDelimiter.TabIndex = 56;
			// 
			// cbDTFormatTime
			// 
			this.cbDTFormatTime.FormattingEnabled = true;
			this.cbDTFormatTime.Items.AddRange(new object[] {
            "H:mm:ss",
            "H.mm",
            "H.mm.ss",
            "H:mm",
            "Hmm",
            "Hmmss",
            "hh.mm tt",
            "hh.mm.ss tt",
            "hh:mm tt",
            "hh:mm:ss tt",
            "hhmm tt",
            "hhmmss tt"});
			this.cbDTFormatTime.Location = new System.Drawing.Point(308, 22);
			this.cbDTFormatTime.Name = "cbDTFormatTime";
			this.cbDTFormatTime.Size = new System.Drawing.Size(122, 21);
			this.cbDTFormatTime.TabIndex = 55;
			// 
			// cbDTFormatDate
			// 
			this.cbDTFormatDate.FormattingEnabled = true;
			this.cbDTFormatDate.Items.AddRange(new object[] {
            "yyyy-MM-dd",
            "d/M/yyyy",
            "ddMMyyyy",
            "d-MMM-yyyy",
            "d-M-yyyy",
            "d.M.yy",
            "dd.MM.yyyy",
            "M/d/yyyy",
            "M-d-yyyy",
            "MMddyy",
            "MMddyyyy",
            "yyddMM",
            "yyMMdd",
            "yyyy/MM/dd",
            "yyyyddMM",
            "yyyyMMdd"});
			this.cbDTFormatDate.Location = new System.Drawing.Point(95, 22);
			this.cbDTFormatDate.Name = "cbDTFormatDate";
			this.cbDTFormatDate.Size = new System.Drawing.Size(106, 21);
			this.cbDTFormatDate.TabIndex = 54;
			// 
			// lblDateTimeFormat
			// 
			this.lblDateTimeFormat.AutoSize = true;
			this.lblDateTimeFormat.Location = new System.Drawing.Point(6, 25);
			this.lblDateTimeFormat.Name = "lblDateTimeFormat";
			this.lblDateTimeFormat.Size = new System.Drawing.Size(91, 13);
			this.lblDateTimeFormat.TabIndex = 53;
			this.lblDateTimeFormat.Text = "DateTime Format:";
			// 
			// gpbFolders
			// 
			this.gpbFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gpbFolders.Controls.Add(this.tbInputFolder);
			this.gpbFolders.Controls.Add(this.lbOutputFolder);
			this.gpbFolders.Controls.Add(this.btnOutputFolderDialog);
			this.gpbFolders.Controls.Add(this.tbOutputFolder);
			this.gpbFolders.Controls.Add(this.lblInputFolder);
			this.gpbFolders.Controls.Add(this.btnInputFolderDialog);
			this.gpbFolders.Location = new System.Drawing.Point(7, 12);
			this.gpbFolders.Name = "gpbFolders";
			this.gpbFolders.Size = new System.Drawing.Size(436, 82);
			this.gpbFolders.TabIndex = 32;
			this.gpbFolders.TabStop = false;
			this.gpbFolders.Text = "Folders";
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(247, 309);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(62, 23);
			this.btnStart.TabIndex = 3;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnStop
			// 
			this.btnStop.Location = new System.Drawing.Point(315, 309);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(62, 23);
			this.btnStop.TabIndex = 34;
			this.btnStop.Text = "Stop";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.cbEconomics);
			this.groupBox1.Controls.Add(this.cbSecuritySentiment);
			this.groupBox1.Controls.Add(this.cbWSODFundamental);
			this.groupBox1.Controls.Add(this.cbEstimatedEarnings);
			this.groupBox1.Controls.Add(this.cbAnalystRatings);
			this.groupBox1.Controls.Add(this.cbFMDFundamental);
			this.groupBox1.Location = new System.Drawing.Point(7, 214);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(436, 89);
			this.groupBox1.TabIndex = 35;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Fundamentals";
			// 
			// cbEconomics
			// 
			this.cbEconomics.AutoSize = true;
			this.cbEconomics.Location = new System.Drawing.Point(216, 65);
			this.cbEconomics.Name = "cbEconomics";
			this.cbEconomics.Size = new System.Drawing.Size(183, 17);
			this.cbEconomics.TabIndex = 5;
			this.cbEconomics.Text = "FidelityWSODEconomicsProvider";
			this.cbEconomics.UseVisualStyleBackColor = true;
			// 
			// cbSecuritySentiment
			// 
			this.cbSecuritySentiment.AutoSize = true;
			this.cbSecuritySentiment.Location = new System.Drawing.Point(216, 42);
			this.cbSecuritySentiment.Name = "cbSecuritySentiment";
			this.cbSecuritySentiment.Size = new System.Drawing.Size(216, 17);
			this.cbSecuritySentiment.TabIndex = 4;
			this.cbSecuritySentiment.Text = "FidelityWSODSecuritySentimentProvider";
			this.cbSecuritySentiment.UseVisualStyleBackColor = true;
			// 
			// cbWSODFundamental
			// 
			this.cbWSODFundamental.AutoSize = true;
			this.cbWSODFundamental.Location = new System.Drawing.Point(9, 42);
			this.cbWSODFundamental.Name = "cbWSODFundamental";
			this.cbWSODFundamental.Size = new System.Drawing.Size(192, 17);
			this.cbWSODFundamental.TabIndex = 3;
			this.cbWSODFundamental.Text = "FidelityWSODFundamentalProvider";
			this.cbWSODFundamental.UseVisualStyleBackColor = true;
			// 
			// cbEstimatedEarnings
			// 
			this.cbEstimatedEarnings.AutoSize = true;
			this.cbEstimatedEarnings.Location = new System.Drawing.Point(216, 19);
			this.cbEstimatedEarnings.Name = "cbEstimatedEarnings";
			this.cbEstimatedEarnings.Size = new System.Drawing.Size(218, 17);
			this.cbEstimatedEarnings.TabIndex = 2;
			this.cbEstimatedEarnings.Text = "FidelityWSODEstimatedEarningsProvider";
			this.cbEstimatedEarnings.UseVisualStyleBackColor = true;
			// 
			// cbAnalystRatings
			// 
			this.cbAnalystRatings.AutoSize = true;
			this.cbAnalystRatings.Location = new System.Drawing.Point(9, 65);
			this.cbAnalystRatings.Name = "cbAnalystRatings";
			this.cbAnalystRatings.Size = new System.Drawing.Size(201, 17);
			this.cbAnalystRatings.TabIndex = 1;
			this.cbAnalystRatings.Text = "FidelityWSODAnalystRatingsProvider";
			this.cbAnalystRatings.UseVisualStyleBackColor = true;
			// 
			// cbFMDFundamental
			// 
			this.cbFMDFundamental.AutoSize = true;
			this.cbFMDFundamental.Location = new System.Drawing.Point(9, 19);
			this.cbFMDFundamental.Name = "cbFMDFundamental";
			this.cbFMDFundamental.Size = new System.Drawing.Size(181, 17);
			this.cbFMDFundamental.TabIndex = 0;
			this.cbFMDFundamental.Text = "FidelityFMDFundamentalProvider";
			this.cbFMDFundamental.UseVisualStyleBackColor = true;
			// 
			// btnClean
			// 
			this.btnClean.Location = new System.Drawing.Point(381, 309);
			this.btnClean.Name = "btnClean";
			this.btnClean.Size = new System.Drawing.Size(62, 23);
			this.btnClean.TabIndex = 36;
			this.btnClean.Text = "Clean";
			this.btnClean.UseVisualStyleBackColor = true;
			this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(451, 550);
			this.Controls.Add(this.btnClean);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.gpbFolders);
			this.Controls.Add(this.gpbParameters);
			this.Controls.Add(this.rtbLog);
			this.Controls.Add(this.lblLog);
			this.Name = "MainForm";
			this.Text = "WealthLab Data Converter 1.0.1.0 (by AnCh)";
			this.gpbParameters.ResumeLayout(false);
			this.gpbParameters.PerformLayout();
			this.gpbFolders.ResumeLayout(false);
			this.gpbFolders.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbOutputFolder;
		private System.Windows.Forms.Button btnOutputFolderDialog;
		private System.Windows.Forms.Label lbOutputFolder;
		private System.Windows.Forms.TextBox tbInputFolder;
		private System.Windows.Forms.Button btnInputFolderDialog;
		private System.Windows.Forms.Label lblInputFolder;
		private System.Windows.Forms.Label lblLog;
		private System.Windows.Forms.RichTextBox rtbLog;
		private System.Windows.Forms.GroupBox gpbParameters;
		private System.Windows.Forms.GroupBox gpbFolders;
		private System.Windows.Forms.ComboBox cbDataDelimiter;
		private System.Windows.Forms.Label lblDelimiter;
		private System.Windows.Forms.ComboBox cbDTFormatDelimiter;
		private System.Windows.Forms.ComboBox cbDTFormatTime;
		private System.Windows.Forms.ComboBox cbDTFormatDate;
		private System.Windows.Forms.Label lblDateTimeFormat;
		private System.Windows.Forms.ComboBox cbFileFormat;
		private System.Windows.Forms.Label lblFileFormat;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.ComboBox cbVolume;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbOHLC;
		private System.Windows.Forms.Label lblOHLCDigits;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox cbSecuritySentiment;
		private System.Windows.Forms.CheckBox cbWSODFundamental;
		private System.Windows.Forms.CheckBox cbEstimatedEarnings;
		private System.Windows.Forms.CheckBox cbAnalystRatings;
		private System.Windows.Forms.CheckBox cbFMDFundamental;
		private System.Windows.Forms.CheckBox cbEconomics;
		private System.Windows.Forms.Button btnClean;
	}
}


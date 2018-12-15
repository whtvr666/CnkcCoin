using CinkciarzCoin.Logic;

namespace CinkciarzCoin
{
	partial class CinkciarzCoinForm
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
			this.components = new System.ComponentModel.Container();
			this.btnStartGenerating = new System.Windows.Forms.Button();
			this.btnStopGenerating = new System.Windows.Forms.Button();
			this.lblAverageRate = new System.Windows.Forms.Label();
			this.lblMaxSpread = new System.Windows.Forms.Label();
			this.txbBuyRate = new System.Windows.Forms.TextBox();
			this.txbSellRate = new System.Windows.Forms.TextBox();
			this.lblBuyRate = new System.Windows.Forms.Label();
			this.lblSellRate = new System.Windows.Forms.Label();
			this.lblFrequency = new System.Windows.Forms.Label();
			this.lblCurrentSpread = new System.Windows.Forms.Label();
			this.txbCurrentSpread = new System.Windows.Forms.TextBox();
			this.txbAverageRate = new System.Windows.Forms.NumericUpDown();
			this.txbMaxSpread = new System.Windows.Forms.NumericUpDown();
			this.txbFrequency = new System.Windows.Forms.NumericUpDown();
			this.lblDrawsPerSecond = new System.Windows.Forms.Label();
			this.txbDrawsPerSecond = new System.Windows.Forms.TextBox();
			this.btnStartRecording = new System.Windows.Forms.Button();
			this.btnStopRecording = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.btnSave = new System.Windows.Forms.Button();
			this.logicBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.txbAverageRate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txbMaxSpread)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txbFrequency)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.logicBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// btnStartGenerating
			// 
			this.btnStartGenerating.Location = new System.Drawing.Point(12, 101);
			this.btnStartGenerating.Name = "btnStartGenerating";
			this.btnStartGenerating.Size = new System.Drawing.Size(95, 23);
			this.btnStartGenerating.TabIndex = 0;
			this.btnStartGenerating.Text = "Start generating";
			this.btnStartGenerating.UseVisualStyleBackColor = true;
			this.btnStartGenerating.Click += new System.EventHandler(this.btnStartGenerating_Click);
			// 
			// btnStopGenerating
			// 
			this.btnStopGenerating.Location = new System.Drawing.Point(116, 101);
			this.btnStopGenerating.Name = "btnStopGenerating";
			this.btnStopGenerating.Size = new System.Drawing.Size(91, 23);
			this.btnStopGenerating.TabIndex = 1;
			this.btnStopGenerating.Text = "Stop generating";
			this.btnStopGenerating.UseVisualStyleBackColor = true;
			this.btnStopGenerating.Click += new System.EventHandler(this.btnStopGenerating_Click);
			// 
			// lblAverageRate
			// 
			this.lblAverageRate.AutoSize = true;
			this.lblAverageRate.Location = new System.Drawing.Point(13, 15);
			this.lblAverageRate.Name = "lblAverageRate";
			this.lblAverageRate.Size = new System.Drawing.Size(68, 13);
			this.lblAverageRate.TabIndex = 3;
			this.lblAverageRate.Text = "Average rate";
			// 
			// lblMaxSpread
			// 
			this.lblMaxSpread.AutoSize = true;
			this.lblMaxSpread.Location = new System.Drawing.Point(13, 41);
			this.lblMaxSpread.Name = "lblMaxSpread";
			this.lblMaxSpread.Size = new System.Drawing.Size(62, 13);
			this.lblMaxSpread.TabIndex = 4;
			this.lblMaxSpread.Text = "Max spread";
			// 
			// txbBuyRate
			// 
			this.txbBuyRate.Enabled = false;
			this.txbBuyRate.Location = new System.Drawing.Point(116, 130);
			this.txbBuyRate.Name = "txbBuyRate";
			this.txbBuyRate.Size = new System.Drawing.Size(91, 20);
			this.txbBuyRate.TabIndex = 6;
			// 
			// txbSellRate
			// 
			this.txbSellRate.Enabled = false;
			this.txbSellRate.Location = new System.Drawing.Point(116, 156);
			this.txbSellRate.Name = "txbSellRate";
			this.txbSellRate.Size = new System.Drawing.Size(91, 20);
			this.txbSellRate.TabIndex = 7;
			// 
			// lblBuyRate
			// 
			this.lblBuyRate.AutoSize = true;
			this.lblBuyRate.Location = new System.Drawing.Point(13, 133);
			this.lblBuyRate.Name = "lblBuyRate";
			this.lblBuyRate.Size = new System.Drawing.Size(46, 13);
			this.lblBuyRate.TabIndex = 8;
			this.lblBuyRate.Text = "Buy rate";
			// 
			// lblSellRate
			// 
			this.lblSellRate.AutoSize = true;
			this.lblSellRate.Location = new System.Drawing.Point(13, 159);
			this.lblSellRate.Name = "lblSellRate";
			this.lblSellRate.Size = new System.Drawing.Size(45, 13);
			this.lblSellRate.TabIndex = 9;
			this.lblSellRate.Text = "Sell rate";
			// 
			// lblFrequency
			// 
			this.lblFrequency.AutoSize = true;
			this.lblFrequency.Location = new System.Drawing.Point(13, 67);
			this.lblFrequency.Name = "lblFrequency";
			this.lblFrequency.Size = new System.Drawing.Size(57, 13);
			this.lblFrequency.TabIndex = 10;
			this.lblFrequency.Text = "Frequency";
			// 
			// lblCurrentSpread
			// 
			this.lblCurrentSpread.AutoSize = true;
			this.lblCurrentSpread.Location = new System.Drawing.Point(13, 185);
			this.lblCurrentSpread.Name = "lblCurrentSpread";
			this.lblCurrentSpread.Size = new System.Drawing.Size(76, 13);
			this.lblCurrentSpread.TabIndex = 13;
			this.lblCurrentSpread.Text = "Current spread";
			// 
			// txbCurrentSpread
			// 
			this.txbCurrentSpread.Enabled = false;
			this.txbCurrentSpread.Location = new System.Drawing.Point(116, 182);
			this.txbCurrentSpread.Name = "txbCurrentSpread";
			this.txbCurrentSpread.Size = new System.Drawing.Size(91, 20);
			this.txbCurrentSpread.TabIndex = 12;
			// 
			// txbAverageRate
			// 
			this.txbAverageRate.DecimalPlaces = 4;
			this.txbAverageRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.txbAverageRate.Location = new System.Drawing.Point(87, 13);
			this.txbAverageRate.Name = "txbAverageRate";
			this.txbAverageRate.Size = new System.Drawing.Size(120, 20);
			this.txbAverageRate.TabIndex = 15;
			this.txbAverageRate.ThousandsSeparator = true;
			// 
			// txbMaxSpread
			// 
			this.txbMaxSpread.DecimalPlaces = 4;
			this.txbMaxSpread.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.txbMaxSpread.Location = new System.Drawing.Point(87, 39);
			this.txbMaxSpread.Name = "txbMaxSpread";
			this.txbMaxSpread.Size = new System.Drawing.Size(120, 20);
			this.txbMaxSpread.TabIndex = 16;
			this.txbMaxSpread.ThousandsSeparator = true;
			// 
			// txbFrequency
			// 
			this.txbFrequency.Location = new System.Drawing.Point(87, 67);
			this.txbFrequency.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.txbFrequency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.txbFrequency.Name = "txbFrequency";
			this.txbFrequency.Size = new System.Drawing.Size(120, 20);
			this.txbFrequency.TabIndex = 17;
			this.txbFrequency.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.txbFrequency.ValueChanged += new System.EventHandler(this.txbFrequency_ValueChanged);
			// 
			// lblDrawsPerSecond
			// 
			this.lblDrawsPerSecond.AutoSize = true;
			this.lblDrawsPerSecond.Location = new System.Drawing.Point(13, 209);
			this.lblDrawsPerSecond.Name = "lblDrawsPerSecond";
			this.lblDrawsPerSecond.Size = new System.Drawing.Size(93, 13);
			this.lblDrawsPerSecond.TabIndex = 19;
			this.lblDrawsPerSecond.Text = "Draws per second";
			// 
			// txbDrawsPerSecond
			// 
			this.txbDrawsPerSecond.Enabled = false;
			this.txbDrawsPerSecond.Location = new System.Drawing.Point(116, 206);
			this.txbDrawsPerSecond.Name = "txbDrawsPerSecond";
			this.txbDrawsPerSecond.Size = new System.Drawing.Size(91, 20);
			this.txbDrawsPerSecond.TabIndex = 18;
			// 
			// btnStartRecording
			// 
			this.btnStartRecording.Location = new System.Drawing.Point(12, 232);
			this.btnStartRecording.Name = "btnStartRecording";
			this.btnStartRecording.Size = new System.Drawing.Size(95, 23);
			this.btnStartRecording.TabIndex = 21;
			this.btnStartRecording.Text = "Start recording";
			this.btnStartRecording.UseVisualStyleBackColor = true;
			// 
			// btnStopRecording
			// 
			this.btnStopRecording.Location = new System.Drawing.Point(12, 232);
			this.btnStopRecording.Name = "btnStopRecording";
			this.btnStopRecording.Size = new System.Drawing.Size(95, 23);
			this.btnStopRecording.TabIndex = 22;
			this.btnStopRecording.Text = "Stop recording";
			this.btnStopRecording.UseVisualStyleBackColor = true;
			this.btnStopRecording.Visible = false;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(116, 232);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(91, 23);
			this.btnSave.TabIndex = 23;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			// 
			// logicBindingSource
			// 
			this.logicBindingSource.DataSource = typeof(CinkciarzCoin.Logic.AppLogic);
			// 
			// CinkciarzCoinForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(243, 288);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnStartRecording);
			this.Controls.Add(this.lblDrawsPerSecond);
			this.Controls.Add(this.txbDrawsPerSecond);
			this.Controls.Add(this.txbFrequency);
			this.Controls.Add(this.txbMaxSpread);
			this.Controls.Add(this.txbAverageRate);
			this.Controls.Add(this.lblCurrentSpread);
			this.Controls.Add(this.txbCurrentSpread);
			this.Controls.Add(this.lblFrequency);
			this.Controls.Add(this.lblSellRate);
			this.Controls.Add(this.lblBuyRate);
			this.Controls.Add(this.txbSellRate);
			this.Controls.Add(this.txbBuyRate);
			this.Controls.Add(this.lblMaxSpread);
			this.Controls.Add(this.lblAverageRate);
			this.Controls.Add(this.btnStopGenerating);
			this.Controls.Add(this.btnStartGenerating);
			this.Controls.Add(this.btnStopRecording);
			this.Name = "CinkciarzCoinForm";
			this.Text = "CinkciarzCoin";
			((System.ComponentModel.ISupportInitialize)(this.txbAverageRate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txbMaxSpread)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txbFrequency)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.logicBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnStartGenerating;
		private System.Windows.Forms.Button btnStopGenerating;
		private System.Windows.Forms.Label lblAverageRate;
		private System.Windows.Forms.Label lblMaxSpread;
		private System.Windows.Forms.TextBox txbBuyRate;
		private System.Windows.Forms.TextBox txbSellRate;
		private System.Windows.Forms.Label lblBuyRate;
		private System.Windows.Forms.Label lblSellRate;
		private System.Windows.Forms.Label lblFrequency;
		private System.Windows.Forms.Label lblCurrentSpread;
		private System.Windows.Forms.TextBox txbCurrentSpread;
		private System.Windows.Forms.NumericUpDown txbAverageRate;
		private System.Windows.Forms.NumericUpDown txbMaxSpread;
		private System.Windows.Forms.NumericUpDown txbFrequency;
		private System.Windows.Forms.Label lblDrawsPerSecond;
		private System.Windows.Forms.TextBox txbDrawsPerSecond;
		private System.Windows.Forms.Button btnStartRecording;
		private System.Windows.Forms.Button btnStopRecording;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.BindingSource logicBindingSource;
	}
}


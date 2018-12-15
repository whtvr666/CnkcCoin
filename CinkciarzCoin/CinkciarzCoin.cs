using System;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using CinkciarzCoin.Logic;
using CinkciarzCoin.Properties;

namespace CinkciarzCoin
{
	public partial class CinkciarzCoinForm : Form
	{
		private AppLogic _logic;
		private System.Timers.Timer _timer;

		public CinkciarzCoinForm()
		{
			InitializeComponent();
			InitializeDefaultValues();

			logicBindingSource.DataSource = _logic;
			InitializeDataBindings();
		}

		private void InitializeDataBindings()
		{
			txbAverageRate.DataBindings.Add(new Binding("Value", logicBindingSource, "AverageRate", true, DataSourceUpdateMode.OnPropertyChanged));
			txbMaxSpread.DataBindings.Add(new Binding("Value", logicBindingSource, "MaxSpread", true, DataSourceUpdateMode.OnPropertyChanged));
		}

		private void InitializeDefaultValues()
		{
			_logic = new AppLogic();
			_timer = new System.Timers.Timer();
			_timer.Elapsed += OnTimedEvent;
			txbAverageRate.Value = _logic.AverageRate;
			txbMaxSpread.Value = _logic.MaxSpread;
			txbFrequency.Value = _logic.Frequency;
		}

		private void OnTimedEvent(object sender, ElapsedEventArgs e)
		{
			_logic.GenerateValues();
			_logic.RecordValues();
			UpdateValues();
		}

		private void UpdateValues()
		{
			txbBuyRate.UpdateText(_logic.BuyRate.ToString("0.0000"));
			txbSellRate.UpdateText(_logic.SellRate.ToString("0.0000"));
			txbCurrentSpread.UpdateText(_logic.CurrentSpread.ToString("0.0000"));
			txbDrawsPerSecond.UpdateText(_logic.NumberOfDraws.ToString("0.00"));
		}

		#region Events

		private void btnSave_Click(object sender, EventArgs e)
		{
			saveFileDialog1.DefaultExt = "csv";
			DialogResult dialogResult = saveFileDialog1.ShowDialog();

			if (dialogResult == DialogResult.OK)
			{
				using (StreamWriter outputFile = new StreamWriter(Path.Combine(saveFileDialog1.FileName)))
				{
					outputFile.Write(_logic.GetRecordedData());
				}
			}
		}

		private void btnStartGenerating_Click(object sender, EventArgs e)
		{
			_timer.Start();
		}

		private void btnStartRecording_Click(object sender, EventArgs e)
		{
			btnStartRecording.Visible = false;
			btnStopRecording.Visible = true;
			_logic.StartRecording();
		}

		private void btnStopGenerating_Click(object sender, EventArgs e)
		{
			_timer.Stop();
		}

		private void btnStopRecording_Click(object sender, EventArgs e)
		{
			btnStartRecording.Visible = true;
			btnStopRecording.Visible = false;
			_logic.StopRecording();
		}

		private void CinkciarzCoinForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (_logic.RecordedRates.Count > 0)
			{
				if (MessageBox.Show(Resources.Warning_ExitWithoutSaving, Name, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
				{
					e.Cancel = true;
				}
			}
		}

		private void txbFrequency_ValueChanged(object sender, EventArgs e)
		{
			_logic.Frequency = (int)txbFrequency.Value;
			_timer.Interval = _logic.Frequency;
		}

		#endregion
	}
}
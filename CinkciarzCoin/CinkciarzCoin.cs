using System;
using System.IO;
using System.Windows.Forms;
using CinkciarzCoin.Logic;
using CinkciarzCoin.Logic.Adapters;
using CinkciarzCoin.Properties;

namespace CinkciarzCoin
{
	public partial class CinkciarzCoinForm : Form
	{
		private AppLogic _logic;

		public CinkciarzCoinForm()
		{
			InitializeComponent();
			InitializeDefaultValues();
			InitializeDataBindings();
			_logic.PropertyChanged += _logic_UpdateControls;
		}

		private void InitializeDataBindings()
		{
			logicBindingSource.DataSource = _logic;
			txbAverageRate.DataBindings.Add(new Binding("Value", logicBindingSource, "AverageRate", true, DataSourceUpdateMode.OnPropertyChanged));
			txbMaxSpread.DataBindings.Add(new Binding("Value", logicBindingSource, "MaxSpread", true, DataSourceUpdateMode.OnPropertyChanged));
			txbFrequency.DataBindings.Add(new Binding("Value", logicBindingSource, "Frequency", true, DataSourceUpdateMode.OnPropertyChanged));
			txbBuyRate.DataBindings.Add(new Binding("Text", logicBindingSource, "BuyRate", true, DataSourceUpdateMode.OnPropertyChanged));
			txbSellRate.DataBindings.Add(new Binding("Text", logicBindingSource, "SellRate", true, DataSourceUpdateMode.OnPropertyChanged));
			txbCurrentSpread.DataBindings.Add(new Binding("Text", logicBindingSource, "CurrentSpread", true, DataSourceUpdateMode.OnPropertyChanged));
			txbDrawsPerSecond.DataBindings.Add(new Binding("Text", logicBindingSource, "NumberOfDraws", true, DataSourceUpdateMode.OnPropertyChanged));
		}

		private void InitializeDefaultValues()
		{
			_logic = new AppLogic(new TimerAdapter(), new RandomAdapter());
			txbAverageRate.Value = _logic.AverageRate;
			txbMaxSpread.Value = _logic.MaxSpread;
			txbFrequency.Value = _logic.Frequency;
		}

		#region Events

		private void _logic_UpdateControls(object sender, EventArgs e)
		{
			BeginInvoke((MethodInvoker)(() => logicBindingSource.ResetBindings(false)));
		}

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
			_logic.StartGenerating();
		}

		private void btnStartRecording_Click(object sender, EventArgs e)
		{
			btnStartRecording.Visible = false;
			btnStopRecording.Visible = true;
			_logic.StartRecording();
		}

		private void btnStopGenerating_Click(object sender, EventArgs e)
		{
			_logic.StopGenerating();
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

		#endregion
	}
}
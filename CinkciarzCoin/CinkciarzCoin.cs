using System;
using System.Timers;
using System.Windows.Forms;
using CinkciarzCoin.Logic;

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

		private void InitializeDefaultValues()
		{

			_logic = new AppLogic();
			_timer = new System.Timers.Timer();
			_timer.Elapsed += OnTimedEvent;
			txbAverageRate.Value = _logic.AverageRate;
			txbMaxSpread.Value = _logic.MaxSpread;
			txbFrequency.Value = _logic.Frequency;

		}

		private void InitializeDataBindings()
		{
			txbAverageRate.DataBindings.Add(new Binding("Value", logicBindingSource, "AverageRate", true, DataSourceUpdateMode.OnPropertyChanged));
			txbMaxSpread.DataBindings.Add(new Binding("Value", logicBindingSource, "MaxSpread", true, DataSourceUpdateMode.OnPropertyChanged));
		}

		private void OnTimedEvent(object sender, ElapsedEventArgs e)
		{
			_logic.GenerateValues();
			UpdateValues();

		}

		private void UpdateValues()
		{
			txbBuyRate.Invoke((MethodInvoker)(() => txbBuyRate.Text = _logic.BuyRate.ToString("0.0000")));
			txbSellRate.Invoke((MethodInvoker)(() => txbSellRate.Text = _logic.SellRate.ToString("0.0000")));
			txbCurrentSpread.Invoke((MethodInvoker)(() => txbCurrentSpread.Text = _logic.CurrentSpread.ToString("0.0000")));
			txbDrawsPerSecond.Invoke((MethodInvoker)(() => txbDrawsPerSecond.Text = _logic.NumberOfDraws.ToString("0.00")));
		}

		private void btnStartGenerating_Click(object sender, EventArgs e)
		{
			_timer.Start();
		}

		private void btnStopGenerating_Click(object sender, EventArgs e)
		{
			_timer.Stop();
		}

		private void txbFrequency_ValueChanged(object sender, EventArgs e)
		{
			_logic.Frequency = (int)txbFrequency.Value;
			_timer.Interval = _logic.Frequency;
		}
	}
}

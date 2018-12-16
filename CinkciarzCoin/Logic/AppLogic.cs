using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Timers;
using CinkciarzCoin.Annotations;
using CinkciarzCoin.Logic.Interfaces;

namespace CinkciarzCoin.Logic
{
	public class AppLogic : INotifyPropertyChanged
	{
		public event EventHandler DataForChartChanged;
		public event PropertyChangedEventHandler PropertyChanged;

		private readonly IRandom _random;
		private readonly ITimer _timer;
		private decimal _averageRate;
		private bool _isRecording;
		private decimal _maxSpread;

		public AppLogic(ITimer timer, IRandom random)
		{
			_timer = timer;
			_timer.Elapsed += OnTimedEvent;
			_random = random;
			AverageRate = 3.55m;
			MaxSpread = 0.5m;
			Frequency = 1000;
			RecordedRates = new List<BuySellRate>();
		}

		public string GetRecordedData()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (var buySellRate in RecordedRates)
			{
				stringBuilder.AppendLine($"{buySellRate.Time.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture)};{buySellRate.BuyRate:0.0000};{buySellRate.SellRate:0.0000}");
			}

			RecordedRates = new List<BuySellRate>();
			return stringBuilder.ToString();
		}

		public void StartGenerating()
		{
			_timer.Start();
		}

		public void StartRecording()
		{
			RecordedRates = new List<BuySellRate>();
			_isRecording = true;
		}

		public void StopGenerating()
		{
			_timer.Stop();
		}

		public void StopRecording()
		{
			_isRecording = false;
		}

		private decimal DrawNewValue(decimal min, decimal max)
		{
			return Math.Round(Convert.ToDecimal(_random.NextDouble() * Convert.ToDouble(max - min) + Convert.ToDouble(min)), 4);
		}

		private void GenerateValues()
		{
			BuyRate = DrawNewValue(MinValue, AverageRate);
			SellRate = DrawNewValue(AverageRate, MaxValue);
			_bsrCollection.Add(new BuySellRate(DateTime.Now, BuyRate, SellRate));
		}

		private void NotifyDataForChartChanged()
		{
			DataForChartChanged?.Invoke(this, EventArgs.Empty);
		}

		[NotifyPropertyChangedInvocator]
		private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private void OnTimedEvent(object sender, ElapsedEventArgs e)
		{
			GenerateValues();
			RecordValues();
			NotifyDataForChartChanged();
		}

		private void RecordValues()
		{
			if (_isRecording)
			{
				RecordedRates.Add(new BuySellRate(DateTime.Now, BuyRate, SellRate));
			}
		}

		#region PROPERTIES

		private readonly List<BuySellRate> _bsrCollection = new List<BuySellRate>();

		public IEnumerable<BuySellRate> BsrCollection
		{
			get
			{
				return _bsrCollection.Skip(_bsrCollection.Count - 30).Take(30);
			}
		}

		public List<BuySellRate> RecordedRates { get; set; }

		public decimal AverageRate
		{
			get
			{
				return _averageRate;
			}
			set
			{
				_averageRate = value;
				NotifyPropertyChanged();
			}
		}

		public decimal MaxSpread
		{
			get
			{
				return _maxSpread;
			}
			set
			{
				_maxSpread = value;
				NotifyPropertyChanged();
			}
		}

		private int _frequency;

		public int Frequency
		{
			get
			{
				return _frequency;
			}
			set
			{
				_frequency = value;
				_timer.Interval = value;
				NotifyPropertyChanged();
			}
		}

		private decimal _buyRate;

		public decimal BuyRate
		{
			get
			{
				return _buyRate;
			}
			set
			{
				_buyRate = value;
				NotifyPropertyChanged(nameof(BuyRate));
			}
		}

		private decimal _sellRate;

		public decimal SellRate
		{
			get
			{
				return _sellRate;
			}
			set
			{
				_sellRate = value;
				NotifyPropertyChanged(nameof(SellRate));
			}
		}

		public decimal CurrentSpread
		{
			get
			{
				return SellRate - BuyRate;
			}
		}

		public decimal NumberOfDraws
		{
			get
			{
				return Math.Round(1000 / Convert.ToDecimal(Frequency), 2);
			}
		}

		private decimal MinValue
		{
			get
			{
				return AverageRate - 0.5m * MaxSpread;
			}
		}

		private decimal MaxValue
		{
			get
			{
				return AverageRate + 0.5m * MaxSpread;
			}
		}

		#endregion PROPERTIES
	}
}
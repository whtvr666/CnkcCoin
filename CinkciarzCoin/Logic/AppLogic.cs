using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Timers;
using CinkciarzCoin.Annotations;
using CinkciarzCoin.Logic.Interfaces;

namespace CinkciarzCoin.Logic
{
	public class AppLogic : INotifyPropertyChanged
	{
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
			RecordedRates = new Dictionary<DateTime, BuySellRate>();
		}

		public string GetRecordedData()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (var kvp in RecordedRates)
			{
				stringBuilder.AppendLine($"{kvp.Key.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture)};{kvp.Value.BuyRate};{kvp.Value.SellRate}");
			}

			RecordedRates = new Dictionary<DateTime, BuySellRate>();
			return stringBuilder.ToString();
		}

		public void StartGenerating()
		{
			_timer.Start();
		}

		public void StartRecording()
		{
			RecordedRates = new Dictionary<DateTime, BuySellRate>();
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
			CurrentSpread = SellRate - BuyRate;
			NumberOfDraws = Math.Round(1000 / Convert.ToDecimal(Frequency), 2);
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
		}

		private void RecordValues()
		{
			if (_isRecording)
			{
				RecordedRates.Add(DateTime.Now, new BuySellRate(BuyRate.ToString("0.0000"), SellRate.ToString("0.0000")));
			}
		}

		#region PROPERTIES

		public Dictionary<DateTime, BuySellRate> RecordedRates { get; set; }

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
				NotifyPropertyChanged(nameof(Frequency));
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

		private decimal _currentSpread;

		public decimal CurrentSpread
		{
			get
			{
				return _currentSpread;
			}
			set
			{
				_currentSpread = value;
				NotifyPropertyChanged(nameof(CurrentSpread));
			}
		}

		private decimal _numDraws;

		public decimal NumberOfDraws
		{
			get
			{
				return _numDraws;
			}
			set
			{
				_numDraws = value;
				NotifyPropertyChanged(nameof(NumberOfDraws));
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
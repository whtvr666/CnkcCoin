using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using CinkciarzCoin.Annotations;

namespace CinkciarzCoin.Logic
{
	public class AppLogic : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private readonly Random _random = new Random();
		private decimal _averageRate;
		private bool _isRecording;
		private decimal _maxSpread;

		public AppLogic()
		{
			AverageRate = 3.55m;
			MaxSpread = 0.5m;
			Frequency = 1000;
			RecordedRates = new Dictionary<DateTime, BuySellRate>();
		}

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

		public int Frequency { get; set; }

		public decimal BuyRate { get; set; }

		public decimal SellRate { get; set; }

		public decimal CurrentSpread { get; set; }

		public decimal NumberOfDraws { get; set; }

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

		public void GenerateValues()
		{
			BuyRate = Math.Round(Convert.ToDecimal(_random.NextDouble() * Convert.ToDouble(AverageRate - MinValue) + Convert.ToDouble(MinValue)), 4);
			SellRate = Math.Round(Convert.ToDecimal(_random.NextDouble() * Convert.ToDouble(MaxValue - AverageRate) + Convert.ToDouble(AverageRate)), 4);
			CurrentSpread = SellRate - BuyRate;
			NumberOfDraws = Math.Round(1000 / Convert.ToDecimal(Frequency), 2);
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

		public void RecordValues()
		{
			if (_isRecording)
			{
				RecordedRates.Add(DateTime.Now, new BuySellRate(BuyRate.ToString("0.0000"), SellRate.ToString("0.0000")));
			}
		}

		public void StartRecording()
		{
			RecordedRates = new Dictionary<DateTime, BuySellRate>();
			_isRecording = true;
		}

		public void StopRecording()
		{
			_isRecording = false;
		}

		[NotifyPropertyChangedInvocator]
		protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
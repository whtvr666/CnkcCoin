using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CinkciarzCoin.Annotations;

namespace CinkciarzCoin.Logic
{
	public class AppLogic : INotifyPropertyChanged
	{
		private decimal _averageRate;
		private decimal _maxSpread;

		private readonly Random _random = new Random();

		public AppLogic()
		{
			AverageRate = 3.55m;
			MaxSpread = 0.5m;
			Frequency = 1000;
		}
		

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

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

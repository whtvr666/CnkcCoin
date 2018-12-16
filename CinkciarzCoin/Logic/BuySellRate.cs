using System;

namespace CinkciarzCoin.Logic
{
	public class BuySellRate
	{
		public BuySellRate(DateTime time, decimal buyRate, decimal sellRate)
		{
			BuyRate = buyRate;
			SellRate = sellRate;
			Time = time;
		}

		public DateTime Time { get; set; }
		public decimal BuyRate { get; set; }
		public decimal SellRate { get; set; }
	}
}

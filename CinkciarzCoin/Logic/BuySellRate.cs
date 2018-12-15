using System;

namespace CinkciarzCoin.Logic
{
	public class BuySellRate
	{
		public BuySellRate(string buyRate, string sellRate)
		{
			BuyRate = buyRate;
			SellRate = sellRate;
		}

		public string BuyRate { get; set; }
		public string SellRate { get; set; }
	}
}

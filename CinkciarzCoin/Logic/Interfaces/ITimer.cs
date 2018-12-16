using System;
using System.Timers;

namespace CinkciarzCoin.Logic.Interfaces
{
	public interface ITimer
	{
		void Start();
		void Stop();
		double Interval { get; set; }
		event ElapsedEventHandler Elapsed;
	}
}

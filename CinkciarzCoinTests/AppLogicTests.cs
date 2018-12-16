using System;
using System.Linq;
using System.Timers;
using CinkciarzCoin.Logic;
using CinkciarzCoin.Logic.Interfaces;
using FakeItEasy;
using NUnit.Framework;

namespace CinkciarzCoinTests
{
	[TestFixture]
	public class AppLogicTests
	{
		private AppLogic _logic;
		private ITimer _mockTimer;
		private IRandom _mockRandom;
		private double _randomValue;

		[SetUp]
		public void BeforeEach()
		{
			_mockTimer = A.Fake<ITimer>();
			_mockRandom = A.Fake<IRandom>();
#pragma warning disable CS0618 // Type or member is obsolete
			A.CallTo(() => _mockTimer.Start()).Invokes(() => _mockTimer.Elapsed += Raise.With<ElapsedEventHandler>(new object(), new EventArgs() as ElapsedEventArgs));
#pragma warning restore CS0618 // Type or member is obsolete
			_logic = new AppLogic(_mockTimer, _mockRandom);
		}

		[Test]
		public void AverageRate_TestDefaultValue_IsAsExpected()
		{
			Assert.AreEqual(3.55m, _logic.AverageRate);
		}

		[Test]
		public void MaxSpread_TestDefaultValue_IsAsExpected()
		{
			Assert.AreEqual(0.5m, _logic.MaxSpread);
		}

		[Test]
		public void Frequency_TestDefaultValue_IsAsExpected()
		{
			Assert.AreEqual(1000, _logic.Frequency);
		}

		[Test]
		public void BuyRate_TestDefaultValue_IsAsExpected()
		{
			Assert.Zero(_logic.BuyRate);
		}

		[Test]
		public void BuyRate_TestGeneratingValues_ReturnsCorrectValue()
		{
			_logic.StartGenerating();

			Assert.NotZero(_logic.BuyRate);
		}

		[Test]
		public void SellRate_TestDefaultValue_IsAsExpected()
		{
			Assert.Zero(_logic.SellRate);
		}

		[Test]
		public void SellRate_TestGeneratingValues_ReturnsCorrectValue()
		{
			_logic.StartGenerating();

			Assert.NotZero(_logic.SellRate);
		}

		[Test]
		public void CurrentSpread_TestDefaultValue_IsAsExpected()
		{
			Assert.Zero(_logic.CurrentSpread);
		}

		[Test]
		public void CurrentSpread_TestGeneratingValues_ReturnsCorrectValue()
		{
			_logic.StartGenerating();

			Assert.NotZero(_logic.CurrentSpread);
		}

		[Test]
		public void NumberOfDraws_TestDefaultValue_IsAsExpected()
		{
			Assert.AreEqual(1, _logic.NumberOfDraws);
		}

		[Test]
		public void NumberOfDraws_TestGeneratingValues_ReturnsCorrectValue()
		{
			_logic.StartGenerating();

			Assert.AreEqual(1, _logic.NumberOfDraws);
		}

		[Test]
		public void RecordedRates_TestDefaultValue_CountIsZero()
		{
			Assert.Zero(_logic.RecordedRates.Count);
		}

		[Test]
		public void RecordedRates_TestStartRecording_CountIsZero()
		{
			_logic.StartRecording();

			Assert.Zero(_logic.RecordedRates.Count);
		}

		[Test]
		public void RecordedRates_TestRecording_ValuesAdded()
		{
			_logic.StartRecording();
			_logic.StartGenerating();

			Assert.AreEqual(1, _logic.RecordedRates.Count);
		}

		[Test]
		public void RecordedRates_TestStopRecording_ValuesNotAdded()
		{
			_logic.StartRecording();
			_logic.StartGenerating();
			_logic.StopRecording();
			_logic.StartGenerating();

			Assert.AreEqual(1, _logic.RecordedRates.Count);
		}


		[Test]
		public void RecordedRates_TestRecording_ValuesAddedProperly()
		{
			_randomValue = 1;
			A.CallTo(() => _mockRandom.NextDouble()).Returns(_randomValue);
			_logic.StartRecording();
			_logic.StartGenerating();

			BuySellRate buySellRate = _logic.RecordedRates.First();

			Assert.AreEqual(3.55m, buySellRate.BuyRate);
			Assert.AreEqual(3.8m, buySellRate.SellRate);
		}

		[Test]
		public void RecordedRates_TestGetRecordedData_ReturnsProperValues()
		{
			_randomValue = 1;
			A.CallTo(() => _mockRandom.NextDouble()).Returns(_randomValue);
			_logic.StartRecording();
			_logic.StartGenerating();

			string actual = _logic.GetRecordedData();

			Assert.That(actual, Does.Match("\\d{4}-\\d{2}-\\d{2} \\d{2}:\\d{2};3,5500;3,8000"));
		}

		[Test]
		public void RecordedRates_TestGetRecordedData_ReturnsMultipleLines()
		{
			_logic.StartRecording();
			_logic.StartGenerating();
			_logic.StartGenerating();

			var lines = _logic.GetRecordedData().Split('\n');

			Assert.AreEqual(3, lines.Length); //+1 due to empty line at the end
		}

		[Test]
		public void Timer_TestTimerStop_ResetTimerInterval()
		{
			A.CallTo(() => _mockTimer.Stop()).Invokes(() => _mockTimer.Interval = 0);

			_logic.StopGenerating();

			Assert.AreEqual(0, _mockTimer.Interval);
		}

		[Test]
		public void PropertyChangedEvent_TestEvent_IsFiredProperly()
		{
			bool changed = false;
			_logic.PropertyChanged += (sender, args) => changed = true;
			_logic.StartGenerating();

			Assert.True(changed);
		}

		[Test]
		public void DataForChartChanged_TestEvent_IsFiredProperly()
		{
			bool changed = false;
			_logic.DataForChartChanged += (sender, args) => changed = true;
			_logic.StartGenerating();

			Assert.True(changed);
		}

		[Test]
		public void BsrCollection_TestBsrCollection_ReturnsCorrectCountAfterOneRun()
		{
			_logic.StartGenerating();

			Assert.AreEqual(1, _logic.BsrCollection.Count());
		}

		[Test]
		public void BsrCollection_TestBsrCollection_ReturnsCorrectCountAfterOverThirtyRuns()
		{
			for (int i = 0; i <= 35; i++)
			{
				_logic.StartGenerating();
			}

			Assert.AreEqual(30, _logic.BsrCollection.Count());
		}


	}
}

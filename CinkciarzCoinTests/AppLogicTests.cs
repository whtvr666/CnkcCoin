using System;
using System.Collections.Generic;
using System.Linq;
using CinkciarzCoin.Logic;
using NUnit.Framework;

namespace CinkciarzCoinTests
{
	[TestFixture]
	public class AppLogicTests
	{
		private AppLogic _logic;

		[SetUp]
		public void BeforeEach()
		{
			_logic = new AppLogic();
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
			_logic.GenerateValues();
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
			_logic.GenerateValues();
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
			_logic.GenerateValues();
			Assert.NotZero(_logic.CurrentSpread);
		}

		[Test]
		public void NumberOfDraws_TestDefaultValue_IsAsExpected()
		{
			Assert.Zero(_logic.NumberOfDraws);
		}

		[Test]
		public void NumberOfDraws_TestGeneratingValues_ReturnsCorrectValue()
		{
			_logic.GenerateValues();
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
			_logic.RecordValues();
			Assert.AreEqual(1, _logic.RecordedRates.Count);
		}

		[Test]
		public void RecordedRates_TestStopRecording_ValuesNotAdded()
		{
			_logic.StartRecording();
			_logic.RecordValues();
			_logic.StopRecording();
			_logic.RecordValues();
			Assert.AreEqual(1, _logic.RecordedRates.Count);
		}


		[Test]
		public void RecordedRates_TestRecording_ValuesAddedProperly()
		{
			_logic.BuyRate = 1.1234m;
			_logic.SellRate = 4.4321m;
			_logic.StartRecording();
			_logic.RecordValues();

			BuySellRate buySellRate = _logic.RecordedRates.Values.First();

			Assert.AreEqual("1,1234", buySellRate.BuyRate);
			Assert.AreEqual("4,4321", buySellRate.SellRate);
		}

		[Test]
		public void RecordedRates_TestGetRecordedData_ReturnsProperValues()
		{
			_logic.BuyRate = 1.1234m;
			_logic.SellRate = 4.4321m;
			_logic.StartRecording();
			_logic.RecordValues();
			string actual = _logic.GetRecordedData();

			Assert.That(actual, Does.Contain(";1,1234;4,4321"));
		}
	}
}

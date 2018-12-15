using System;
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
	}
}

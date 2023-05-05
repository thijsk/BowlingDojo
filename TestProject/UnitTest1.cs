using BowlingDojo;

namespace TestProject
{
	public class UnitTest1
	{
		[Fact]
		public void TestNoRolls()
		{
			var sut = new Game();

			var score = sut.Score();

			Assert.Equal(0, score);
		}

		[Fact]
		public void TestFirstRoll()
		{
			var sut = new Game();

			sut.Roll(0);

			var score = sut.Score();

			Assert.Equal(0, score);
		}

		[Fact]
		public void TestAllGutterRoll()
		{
			var sut = new Game();


			foreach (var _ in Enumerable.Range(1, 20))
			{
				sut.Roll(0);
			}

			var score = sut.Score();

			Assert.Equal(0, score);
		}

		[Fact]
		public void TestFullSimpleGame()
		{
			var sut = new Game();

			foreach (var i in Enumerable.Range(1, 20))
			{
				sut.Roll(1);
			}

			var score = sut.Score();

			Assert.Equal(20, score);
		}

		[Fact]
		public void TestSpare()
		{
			var sut = new Game();


			sut.Roll(5);
			sut.Roll(5);
			sut.Roll(1);

			var score = sut.Score();

			Assert.Equal(12, score);

		}

		[Fact]
		public void TestStrike()
		{
			var sut = new Game();

			sut.Roll(10);

			sut.Roll(1);
			sut.Roll(1);
			sut.Roll(1);

			var score = sut.Score();

			Assert.Equal(15, score);

		}

		[Fact]
		public void TestAllStrike()
		{
			var sut = new Game();

			foreach (var i in Enumerable.Range(1, 12))
			{
				sut.Roll(10);
			}

			var score = sut.Score();

			Assert.Equal(300, score);

		}
	}
}
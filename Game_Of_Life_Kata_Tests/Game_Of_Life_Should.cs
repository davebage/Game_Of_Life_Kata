using Game_Of_Life_Kata;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;

namespace Game_Of_Life_Kata_Tests
{
    [TestFixture]
    public class Game_Of_Life_Should
    {
        [Test]
        public void Allow_Seed_Pattern()
        {
            var gameOfLife = new GameOfLife();

            Assert.IsTrue(gameOfLife.Seed(new bool[] { true }));
        }

        [Test]
        public void Not_Allow_Empty_Seed_Pattern()
        {
            var gameOfLife = new GameOfLife();

            Assert.IsFalse(gameOfLife.Seed(null));
        }

        [Test]
        [TestCase(new bool[] { true }, new bool[] { false })]
        [TestCase(new bool[] { false }, new bool[] { false })]
        public void Process_Single_Cell_For_Expected_Result(bool[] seed, bool[] expected)
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(seed);

            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(new bool[] { true, true }, new bool[] { false, false })]
        [TestCase(new bool[] { true, false }, new bool[] { false, false })]
        [TestCase(new bool[] { false, true }, new bool[] { false, false })]
        [TestCase(new bool[] { false, false }, new bool[] { false, false })]
        public void Process_Two_Cells_For_Expected_Result(bool[] seed, bool[] expected)
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(seed);

            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(new bool[] { false, false, false }, new bool[] { false, false, false })]
        [TestCase(new bool[] { true, false, false }, new bool[] { false, false, false })]
        [TestCase(new bool[] { true, true, false }, new bool[] { false, false, false })]
        public void Process_Three_Cells_For_Expected_Result(bool[] seed, bool[] expected)
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(seed);

            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }
    }
}
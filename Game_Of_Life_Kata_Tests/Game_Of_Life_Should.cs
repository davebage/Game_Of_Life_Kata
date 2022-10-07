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
        public void Process_Single_Cell_For_Expected_Result(bool[] seed, bool[] expected)
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(seed);

            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }
    }
}
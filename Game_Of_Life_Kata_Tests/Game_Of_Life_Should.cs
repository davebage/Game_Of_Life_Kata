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
        public void Process_Two_Live_Cells_In_A_Row()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[] { true, true });

            Assert.That(gameOfLife.Tick(), Is.EqualTo(new bool[] { false, false }));
        }

        [Test]
        public void Process_Two_Cells_Alive_Dead_In_A_Row()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[] { true, false });

            Assert.That(gameOfLife.Tick(), Is.EqualTo(new bool[] { false, false }));
        }

        [Test]
        public void Process_Two_Cells_Dead_Alive_In_A_Row()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[] { false, true });

            Assert.That(gameOfLife.Tick(), Is.EqualTo(new bool[] { false, false }));
        }

        [Test]
        public void Process_Two_Cells_Dead_Dead_In_A_Row()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[] { false, false });

            Assert.That(gameOfLife.Tick(), Is.EqualTo(new bool[] { false, false }));
        }

        [Test]
        public void Process_Three_Cells_Dead_Dead_Dead_In_A_Row()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[] { false, false, false });

            Assert.That(gameOfLife.Tick(), Is.EqualTo(new bool[] { false, false, false }));
        }

        [Test]
        public void Process_Three_Cells_Alive_Alive_Alive_In_A_Row()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[] { true, true, true });

            Assert.That(gameOfLife.Tick(), Is.EqualTo(new bool[] { false, true, false }));
        }

    }
}
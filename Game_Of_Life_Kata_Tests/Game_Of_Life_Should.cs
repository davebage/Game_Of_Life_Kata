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
        public void ProcessSingleLiveCell()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[] { true });

            Assert.That(gameOfLife.Tick(), Is.EqualTo(new bool[] { false }));
        }

        [Test]
        public void ProcessSingleDeadCell()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[] { false });

            Assert.That(gameOfLife.Tick(), Is.EqualTo(new bool[] { false }));
        }

        [Test]
        public void Process_Two_Alive_Cells()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[] { true, true });

            Assert.That(gameOfLife.Tick(), Is.EqualTo(new bool[] { false, false }));
        }

        [Test]
        public void Process_Two_Cells_Alive_Dead()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[] { true, false });

            Assert.That(gameOfLife.Tick(), Is.EqualTo(new bool[] { false, false }));
        }

        [Test]
        public void Process_Two_Cells_Dead_Alive()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[] { false, true });

            Assert.That(gameOfLife.Tick(), Is.EqualTo(new bool[] { false, false }));
        }

        [Test]
        public void Process_Two_Dead_Cells()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[] { false, false });

            Assert.That(gameOfLife.Tick(), Is.EqualTo(new bool[] { false, false }));
        }

        [Test]
        public void Process_Three_Cells_With_Zero_Live_Cells()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[] { false, false, false });

            Assert.That(gameOfLife.Tick(), Is.EqualTo(new bool[] { false, false, false }));
        }

        [Test]
        public void Process_Three_Cells_With_No_Live_Cells()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[] { false, false, false });

            Assert.That(gameOfLife.Tick(), Is.EqualTo(new bool[] { false, false, false }));
        }

        [Test]
        public void Process_Three_Cells_With_One_Live_Cell()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[] { true, false, false });

            Assert.That(gameOfLife.Tick(), Is.EqualTo(new bool[] { false, false, false }));
        }

        [Test]
        public void Process_Three_Cells_With_Two_Live_Cell()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[] { true, true, false });

            Assert.That(gameOfLife.Tick(), Is.EqualTo(new bool[] { false, false, false }));
        }
    }
}
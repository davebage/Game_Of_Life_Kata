using System;
using Game_Of_Life_Kata;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;

namespace Game_Of_Life_Kata_Tests
{
    [TestFixture]
    public class Game_Of_Life_Should
    {

        [Test]
        public void Not_Allow_Empty_Seed_Pattern()
        {
            var gameOfLife = new GameOfLife();

            Assert.Throws<ArgumentException>(() => gameOfLife.Seed(new bool[0, 0]));
        }

        [Test]
        public void Allow_Seed_Pattern()
        {
            var gameOfLife = new GameOfLife();

            Assert.IsTrue(gameOfLife.Seed(new bool[,] { { true } }));
        }

        [Test]
        public void ProcessSingleLiveCell()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[,] { { true } });

            var expected = GenerateExpected(new bool[] { false });
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void ProcessSingleDeadCell()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[,] { { false } });
            var expected = GenerateExpected(new bool[] { false });
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Two_Alive_Cells()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[,] { { true, true } });

            var expected = GenerateExpected(new bool[] { false, false });
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Two_Cells_Alive_Dead()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[,] { { true, false } });

            var expected = GenerateExpected(new bool[] { false, false });
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Two_Cells_Dead_Alive()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[,] { { false, true } });

            var expected = GenerateExpected(new bool[] { false, false });
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Two_Dead_Cells()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[,] { { false, false } });

            var expected = GenerateExpected(new bool[] { false, false });
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Three_Cells_With_Zero_Live_Cells()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[,] { { false, false, false } });

            var expected = GenerateExpected(new bool[] { false, false, false });
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Three_Cells_With_No_Live_Cells()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[,] { { false, false, false } });

            var expected = GenerateExpected(new bool[] { false, false, false });
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Three_Cells_With_One_Live_Cell()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[,] { { true, false, false } });
            var expected = GenerateExpected(new bool[] { false, false, false });
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Three_Cells_With_Two_Live_Cell()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[,] { { true, true, false } });
            var expected = GenerateExpected(new bool[] { false, false, false });
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Two_Rows_With_All_Dead_Cells()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new bool[,] { { false, false, false }, { false, false, false } });
            var expected = new bool[,] { { false, false, false }, { false, false, false } };
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));

        }

        private bool[,] GenerateExpected(bool[] oneDimensionalArray)
        {
            var result = new bool[1, oneDimensionalArray.Length];

            for (int elementIndex = 0; elementIndex < oneDimensionalArray.Length; elementIndex++)
            {
                result[0, elementIndex] = oneDimensionalArray[elementIndex];
            }

            return result;
        }
    }
}

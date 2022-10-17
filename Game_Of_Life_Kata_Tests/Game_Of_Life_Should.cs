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

            Assert.Throws<ArgumentException>(() => gameOfLife.Seed(new Cell[0, 0]));
        }

        [Test]
        public void Allow_Seed_Pattern()
        {
            var gameOfLife = new GameOfLife();

            Assert.IsTrue(gameOfLife.Seed(new Cell[,] { { new Cell(Status.Alive) } }));
        }

        [Test]
        public void ProcessSingleLiveCell()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new Cell[,] { { new Cell(Status.Alive) } });

            var expected = new Cell[,] { { new Cell(Status.Dead) } };
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void ProcessSingleDeadCell()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new Cell[,] { { new Cell(Status.Dead) } });
            var expected = new Cell[,] { { new Cell(Status.Dead) } };
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Two_Alive_Cells_In_A_Row()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new Cell[,] { { new Cell(Status.Alive), new Cell(Status.Alive) } });

            var expected = new Cell[,] { { new Cell(Status.Dead), new Cell(Status.Dead) } };
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Two_Cells_Alive_Dead_In_A_Row()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new Cell[,] { { new Cell(Status.Alive), new Cell(Status.Dead) } });

            var expected = new Cell[,] { { new Cell(Status.Dead), new Cell(Status.Dead) } };
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Two_Cells_Dead_Alive_In_A_Row()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new Cell[,] { { new Cell(Status.Dead), new Cell(Status.Alive) } });

            var expected = new Cell[,] { { new Cell(Status.Dead), new Cell(Status.Dead) } };
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Two_Dead_Cells_In_A_Row()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new Cell[,] { { new Cell(Status.Dead), new Cell(Status.Dead) } });

            var expected = new Cell[,] { { new Cell(Status.Dead), new Cell(Status.Dead) } };
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Three_Cells_In_A_Row_With_Zero_Live_Cells()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new Cell[,] { { new Cell(Status.Dead), new Cell(Status.Dead), new Cell(Status.Dead) } });

            var expected = new Cell[,] { { new Cell(Status.Dead), new Cell(Status.Dead), new Cell(Status.Dead) } };
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Three_Cells_In_A_Row_With_One_Live_Cell()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new Cell[,] { { new Cell(Status.Alive), new Cell(Status.Dead), new Cell(Status.Dead) } });
            var expected = new Cell[,] { { new Cell(Status.Dead), new Cell(Status.Dead), new Cell(Status.Dead) } };
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Three_Cells_In_A_Row_With_Two_Live_Cells_First()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new Cell[,] { { new Cell(Status.Alive), new Cell(Status.Alive), new Cell(Status.Dead) } });
            var expected = new Cell[,] { { new Cell(Status.Dead), new Cell(Status.Dead), new Cell(Status.Dead) } };
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Three_Cells_In_A_Row_With_Two_Live_Cells_First_And_Last()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new Cell[,] { { new Cell(Status.Alive), new Cell(Status.Dead), new Cell(Status.Alive) } });
            var expected = new Cell[,] { { new Cell(Status.Dead), new Cell(Status.Dead), new Cell(Status.Dead) } };
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Two_Dead_Cells_In_A_Column()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new Cell[,] { { new Cell(Status.Dead) }, { new Cell(Status.Dead) } });
            var expected = new Cell[,] { { new Cell(Status.Dead) }, { new Cell(Status.Dead) } };
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Three_Dead_Cells_In_A_Column()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new Cell[,] { { new Cell(Status.Dead) }, { new Cell(Status.Dead) }, { new Cell(Status.Dead) } });
            var expected = new Cell[,] { { new Cell(Status.Dead) }, { new Cell(Status.Dead) }, { new Cell(Status.Dead) } };
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Three_Live_Cells_In_A_Column()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new Cell[,]
            {
                { new Cell(Status.Alive) },
                { new Cell(Status.Alive) },
                { new Cell(Status.Alive) }
            });
            var expected = new Cell[,]
            {
                { new Cell(Status.Dead) , new Cell(Status.Dead), new Cell(Status.Dead) },
                { new Cell(Status.Alive), new Cell(Status.Alive), new Cell(Status.Alive) },
                { new Cell(Status.Dead) , new Cell(Status.Dead), new Cell(Status.Dead) }
            };
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Two_Live_Cells_In_A_Column()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new Cell[,] { { new Cell(Status.Alive) }, { new Cell(Status.Alive) }, { new Cell(Status.Dead) } });
            var expected = new Cell[,] { { new Cell(Status.Dead) }, { new Cell(Status.Dead) }, { new Cell(Status.Dead) } };
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Two_Live_Cells_In_A_Column_With_Dead_Cell_In_The_Middle()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new Cell[,] { { new Cell(Status.Alive) }, { new Cell(Status.Dead) }, { new Cell(Status.Alive) } });
            var expected = new Cell[,] { { new Cell(Status.Dead) }, { new Cell(Status.Dead) }, { new Cell(Status.Dead) } };
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Two_Rows_With_One_Live_Cell()
        {
            var gameOfLife = new GameOfLife();

            gameOfLife.Seed(new Cell[,] { { new Cell(Status.Alive), new Cell(Status.Dead), new Cell(Status.Dead) }, { new Cell(Status.Dead), new Cell(Status.Dead), new Cell(Status.Dead) } });
            var expected = new Cell[,] { { new Cell(Status.Dead), new Cell(Status.Dead), new Cell(Status.Dead) }, { new Cell(Status.Dead), new Cell(Status.Dead), new Cell(Status.Dead) } };
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));

        }

        [Test]
        public void Process_Three_Live_Cells_On_Row_Below()
        {
            var gameOfLife = new GameOfLife();

            var seed = new Cell[,] {
                { new Cell(Status.Dead), new Cell(Status.Dead), new Cell(Status.Dead) },
                { new Cell(Status.Alive), new Cell(Status.Alive), new Cell(Status.Alive) } };

            var expected = new Cell[,] {
                { new Cell(Status.Dead), new Cell(Status.Alive), new Cell(Status.Dead) },
                { new Cell(Status.Dead), new Cell(Status.Alive), new Cell(Status.Dead) },
                { new Cell(Status.Dead), new Cell(Status.Alive), new Cell(Status.Dead) } };

            gameOfLife.Seed(seed);
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Three_Live_Cells_In_Column_Right()
        {
            var gameOfLife = new GameOfLife();

            var seed = new Cell[,] {
                { new Cell(Status.Dead), new Cell(Status.Alive) },
                { new Cell(Status.Dead), new Cell(Status.Alive) },
                { new Cell(Status.Dead), new Cell(Status.Alive) }
            };

            var expected = new Cell[,]
            {
                { new Cell(Status.Dead), new Cell(Status.Dead), new Cell(Status.Dead) },
                { new Cell(Status.Alive), new Cell(Status.Alive), new Cell(Status.Alive) },
                { new Cell(Status.Dead), new Cell(Status.Dead), new Cell(Status.Dead) }
            };
            gameOfLife.Seed(seed);
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

        [Test]
        public void Process_Three_Live_Cells_In_Column_Left()
        {
            var gameOfLife = new GameOfLife();

            var seed = new Cell[,] {
                { new Cell(Status.Alive), new Cell(Status.Dead) },
                { new Cell(Status.Alive), new Cell(Status.Dead) },
                { new Cell(Status.Alive), new Cell(Status.Dead) }
            };

            var expected = new Cell[,]
            {
                { new Cell(Status.Dead), new Cell(Status.Dead), new Cell(Status.Dead) },
                { new Cell(Status.Alive), new Cell(Status.Alive), new Cell(Status.Alive) },
                { new Cell(Status.Dead), new Cell(Status.Dead), new Cell(Status.Dead) }
            };
            gameOfLife.Seed(seed);
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }


        [Test]
        public void Generate_New_Rows_When_Live_Cell_Needed()
        {
            var gameOfLife = new GameOfLife();

            var seed = new Cell[,] {
                { new Cell(Status.Alive), new Cell(Status.Alive), new Cell(Status.Alive) },
            };

            var expected = new Cell[,] {
                { new Cell(Status.Dead), new Cell(Status.Alive), new Cell(Status.Dead) },
                { new Cell(Status.Dead), new Cell(Status.Alive), new Cell(Status.Dead) },
                { new Cell(Status.Dead), new Cell(Status.Alive), new Cell(Status.Dead) } };

            gameOfLife.Seed(seed);
            Assert.That(gameOfLife.Tick(), Is.EqualTo(expected));
        }

    }
}

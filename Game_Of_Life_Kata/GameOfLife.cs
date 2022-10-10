namespace Game_Of_Life_Kata
{
    public class GameOfLife
    {
        private bool[,] _cells;
        public bool Seed(bool[,] seedPattern)
        {
            if (seedPattern == null) return false;
            _cells = seedPattern;
            return true;
        }

        public bool[,] Tick()
        {
            var result = new bool[_cells.GetLength(0), _cells.GetLength(1)];

            for (int rowIndex = 0; rowIndex <= _cells.GetLength(0) - 1; rowIndex++)
            {
                var liveNeighbours = 0;

                if (rowIndex - 1 >= 0 && _cells[rowIndex - 1, 0])
                    liveNeighbours++;

                if (rowIndex + 1 <= _cells.GetLength(0) - 1 && _cells[rowIndex + 1, 0])
                    liveNeighbours++;

                result[rowIndex, 0] = false;

                if (liveNeighbours == 2)
                    result[rowIndex, 0] = true;


            }

            return result;

        }
    }
}
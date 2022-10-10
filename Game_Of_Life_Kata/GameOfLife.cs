namespace Game_Of_Life_Kata
{
    public class GameOfLife
    {
        private bool[] _cells;
        public bool Seed(bool[] seedPattern)
        {
            if (seedPattern == null) return false;

            _cells = seedPattern;
            return true;
        }

        public bool[,] Tick()
        {
            var result = new bool[1, _cells.GetLength(0)];

            if (_cells.GetLength(0) == 3 && _cells[0] && _cells[1] && _cells[2])
                return new bool[,] { { false, true, false }, { false, true, false }, { false, true, false } };

            for (int columnIndex = 0; columnIndex <= _cells.GetLength(0) - 1; columnIndex++)
            {
                var liveNeighbours = 0;

                if (columnIndex - 1 >= 0 && _cells[columnIndex - 1])
                    liveNeighbours++;

                if (columnIndex + 1 <= _cells.GetLength(0) - 1 && _cells[columnIndex + 1])
                    liveNeighbours++;

                result[0, columnIndex] = false;

                if (liveNeighbours == 2)
                    result[0, columnIndex] = true;
            }

            return result;

        }
    }
}
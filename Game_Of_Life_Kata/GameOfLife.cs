namespace Game_Of_Life_Kata
{
    public class GameOfLife
    {
        private bool[,] _cells;
        public bool Seed(bool[] seedPattern)
        {
            if (seedPattern.Length == 0) throw new ArgumentException();

            _cells = new bool[1, seedPattern.Length];

            for (int columnIndex = 0; columnIndex < seedPattern.Length; columnIndex++)
                _cells[0, columnIndex] = seedPattern[columnIndex];
 
            return true;
        }
        public bool Seed(bool[,] seedPattern)
        {
            if (seedPattern == null) return false;

            _cells = seedPattern;
            return true;
        }

        public bool[,] Tick()
        {
            var result = new bool[_cells.GetLength(0), _cells.GetLength(1)];

            for (int columnIndex = 0; columnIndex <= _cells.GetLength(0) - 1; columnIndex++)
            {
                var liveNeighbours = 0;

                if (columnIndex - 1 >= 0 && _cells[0, columnIndex - 1])
                    liveNeighbours++;

                if (columnIndex + 1 <= _cells.GetLength(0) - 1 && _cells[0, columnIndex + 1])
                    liveNeighbours++;

                result[0, columnIndex] = false;

                if (liveNeighbours == 2)
                    result[0, columnIndex] = true;
            }

            return result;

        }
    }
}
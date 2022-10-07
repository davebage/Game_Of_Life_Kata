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

        public bool[] Tick()
        {
            var result = new bool[_cells.Length];

            for (int columnIndex = 0; columnIndex <= _cells.Length - 1; columnIndex++)
            {
                var liveNeighbours = 0;

                if (columnIndex - 1 >= 0 && _cells[columnIndex - 1])
                    liveNeighbours++;

                if (columnIndex + 1 <= _cells.Length - 1 && _cells[columnIndex + 1])
                    liveNeighbours++;

                result[columnIndex] = false;

                if (liveNeighbours == 2)
                    result[columnIndex] = true;


            }

            return result;

        }
    }
}
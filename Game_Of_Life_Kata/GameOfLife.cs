namespace Game_Of_Life_Kata
{
    public class GameOfLife
    {
        private bool[] _cells;
        public bool Seed(bool[] seedPattern)
        {
            if(seedPattern == null) return false;
            _cells = seedPattern;
            return true;
        }

        public bool[] Tick()
        {
            if(_cells.GetLength(0) == 2)
                return new bool[] { false, false };

            if (_cells.SequenceEqual(new bool[] { false, false, false }))
                return new bool[] { false, false, false };

            if (_cells.SequenceEqual(new bool[] { true, true, true }))
                return new bool[] { false, true, false };

            return new bool[] { false };
        }
    }
}
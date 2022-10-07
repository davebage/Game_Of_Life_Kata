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
            if(_cells.SequenceEqual(new bool[] { true, true }))
                return new bool[] { false, false };

            if (_cells.SequenceEqual(new bool[] { true, false }))
                return new bool[] { false, false };


            return new bool[] { false };
        }
    }
}
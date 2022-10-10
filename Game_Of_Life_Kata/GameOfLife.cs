namespace Game_Of_Life_Kata
{
    public class GameOfLife
    {
        private Universe _universe;

        public bool Seed(bool[,] seedPattern)
        {
            if (seedPattern.Length == 0) throw new ArgumentException();

            _universe = new Universe(seedPattern);
 
            return true;
        }

        public bool[,] Tick()
        {
            var result = _universe.NextGeneration();

            return result;

        }
    }
}
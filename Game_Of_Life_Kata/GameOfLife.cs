namespace Game_Of_Life_Kata
{
    public class GameOfLife
    {
        private Universe _universe;

        public bool Seed(List<Cell> seedPattern)
        {
            if (seedPattern.Count == 0) throw new ArgumentException();

            _universe = new Universe(seedPattern);
 
            return true;
        }

        public List<Cell> Tick()
        {
            var result = _universe.NextGeneration();

            return result;

        }
    }
}
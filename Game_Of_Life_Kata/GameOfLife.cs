namespace Game_Of_Life_Kata
{
    public class GameOfLife
    {
        public bool Seed(bool[] seedPattern)
        {
            if(seedPattern == null) return false;
            return true;
        }

        public bool[] Tick()
        {
            return new bool[] { false };
        }
    }
}
namespace MineSweeper.Models
{
    internal class Seeds
    {
        public int seed { get; set; }

        
        public int SeedInput(TimeOnly startTime)
        {
            Console.WriteLine("Type the game's seed: ");
            if (int.TryParse(Console.ReadLine(), out int seed))
            {
                return seed;
            }
            else
            {
                Console.WriteLine("invalid seed input; generating automatically");
                seed = (int)(DateTime.Now.Ticks & 0xFFFFFFFF);
                return seed;
            }
        }
        
        

        
    }
}

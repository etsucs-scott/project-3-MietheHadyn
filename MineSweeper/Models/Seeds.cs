namespace MineSweeper.Models
{
    internal class Seeds
    {
        public int seed { get; set; }

        TimeOnly startTime = new TimeOnly();

        public Seeds()
        {
            //idk how to do a constructor since it's a more method driven creation
        }
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
        //seed generation, storage; allow this to talk to the file I/O to save the seeds there, too.
        //seeds used to save bomb location?
    }
}

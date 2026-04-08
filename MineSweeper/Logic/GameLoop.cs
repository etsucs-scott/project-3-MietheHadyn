using MineSweeper.Models;

namespace MineSweeper.Logic
{
    internal class GameLoop
    {
        private static System.Timers.Timer gameTimer = new System.Timers.Timer(1000);
        DateTime startTime = DateTime.Now;

        //manage game loop, win/loss, timer
        public bool end = false; //bool to determine if the game ended 
        public bool win = false; //bool to determine win


        public static Tuple<DateTime, DateTime, bool> PlayGame()
        {
            bool End = false;
            bool win = false;

            var input = new MineSweeper.Logic.Input();
            var dims = input.BoardSelect(); //returns tuple of ints for width, height, and bomb count
            int width = dims.Item1;
            int height = dims.Item2;
            int bombs = dims.Item3;


            DateTime startTime = DateTime.Now;
            TimeOnly seedTime = new TimeOnly();
            int seed = new Seeds().SeedInput(seedTime);
            Console.WriteLine(seed);
            var board = new Board(width, height, bombs);
            board.seedPlaceBombs(seed, width, height, board.Bombcount);

            board.DisplayBoard(); //print the 2D array to console
            var flagger = new Flag(); //flag instancer
            var revealer = new Reveal(); //reveal instancer

            while (End == false)
            {
                string action = input.Action(); //returns string of either "reveal" or "flag"
                int y = input.YSelection(height); //returns int for y coordinate; apparently x
                int x = input.XSelection(width); //returns int for x coordinate; apparently y

                if (action == "reveal")
                {
                    Console.WriteLine("Reveal method");
                    bool bombFound = revealer.actReveal(x, y, board); //reveal the tile at the coordinates; if it's a bomb, End = true and win = false; if it's not a bomb, reveal the tile and check if the player has won
                    if (bombFound == true)
                    {
                        End = true;
                        win = false;
                        DateTime endTime = DateTime.Now;

                    }
                }
                else if (action == "flag")
                {
                    Console.WriteLine("Flaging method");
                    flagger.PlaceFlag(x, y, board);

                }
                board.DisplayBoard(); //print the 2D array to console
                                      //check win condition; if all non-bomb tiles are revealed, End = true and win = true
            }
            if (End == true && win == true)
            {
                Console.WriteLine("You win!");
                DateTime endTime = DateTime.Now;
                return Tuple.Create(endTime, startTime, true);
            }
            else //(End == true && win == false)
            {
                Console.WriteLine("You lose!");
                DateTime endTime = DateTime.Now;
                return Tuple.Create(endTime, startTime, false);
            }

        }

    }
}

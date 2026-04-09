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
            var game = new GameLoop();

            bool end = false;
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

            while (end == false)
            {
                string action = input.Action(); //returns string of either "reveal" or "flag"
                int y = input.YSelection(height); //returns int for y coordinate; apparently x
                int x = input.XSelection(width); //returns int for x coordinate; apparently y

                var winCheck = game.WinCondition(board);  //check win condition; if all non-bomb tiles are revealed, End = true and win = true
                end = winCheck.Item1;
                win = winCheck.Item2;

                if (action == "reveal")
                {
                    Console.WriteLine("Reveal method");
                    bool bombFound = revealer.actReveal(x, y, board); //reveal the tile at the coordinates; if it's a bomb, End = true and win = false; if it's not a bomb, reveal the tile and check if the player has won
                    if (bombFound == true)
                    {
                        end = true;
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
                

            }
            if (end == true && win == true)
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


        public Tuple<bool, bool> WinCondition(Board board) 
        {
            int hiddenCount = 0;
            foreach (var cell in board.board)
            {
                if (cell == null)
                {
                    hiddenCount++;
                }
                else if (cell.ToString() == Board.bomb)
                {
                    continue;
                }
                else if (cell.ToString() == Board.Hidden)
                {
                    hiddenCount++;
                }
                else if (cell.ToString() == Board.flag)
                {
                    continue;
                }
                else if (cell.ToString() == Board.emptyRevealed)
                {
                    continue;
                }
                else
                {
                    continue;
                }
            }

            if (hiddenCount == 0) //no more hidden cell (that aren't bombs)
            {
                end = true;
                win = true;
                return Tuple.Create(end, win);
            }
            else //any hidden cells means the game isn't over yet
            {
                end = false;
                win = false;
                return Tuple.Create(end, win);
            }

        }
    }
}

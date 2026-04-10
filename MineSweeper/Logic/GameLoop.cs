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
        

        public static Tuple<DateTime, DateTime, bool, int> PlayGame()
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

                

                if (action == "reveal")
                {
                    Console.WriteLine("Reveal...");
                    bool bombFound = revealer.actReveal(x, y, board); //reveal the tile at the coordinates; if it's a bomb, End = true and win = false; if it's not a bomb, reveal the tile and check if the player has won
                    if (bombFound == true)
                    {
                        end = true;
                        win = false;
                        DateTime endTime = DateTime.Now;
                    }
                    else
                    {
                        var winCheck = game.WinCondition(board);  //check win condition; if all non-bomb tiles are revealed, End = true and win = true
                        end = winCheck.Item1;
                        win = winCheck.Item2;
                    }
                }
                else if (action == "flag")
                {
                    Console.WriteLine("Flagging...");
                    flagger.PlaceFlag(x, y, board);
                }
                board.DisplayBoard(); //print the 2D array to console


            }
            if (end == true && win == true)
            {
                Console.WriteLine("You win!");
                DateTime endTime = DateTime.Now;
                return Tuple.Create(endTime, startTime, true, seed);
            }
            else //(End == true && win == false)
            {
                Console.WriteLine("You lose!");
                DateTime endTime = DateTime.Now;
                return Tuple.Create(endTime, startTime, false, seed);
            }

        }


        public Tuple<bool, bool> WinCondition(Board board)
        {
            int hiddenCount = 0;

            int rows = board.board.GetLength(0);
            int cols = board.board.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    var cell = board.board[i, j];

                    if (cell == null)
                    {
                        hiddenCount++;
                        continue;
                    }

                    var s = cell.ToString();

                    if (s == Board.Hidden)
                    {
                        hiddenCount++;
                    }
                    else if (s == Board.bomb)
                    {
                        continue;
                    }
                    else if (s == Board.flag)
                    {
                        continue;
                    }
                    else if (s == Board.emptyRevealed)
                    {
                        continue;
                    }
                }
            }

            if (hiddenCount == 0)
            {
                end = true;
                win = true;
                return Tuple.Create(true, true);
            }
            else
            {
                end = false;
                win = false;
                return Tuple.Create(false, false);
            }
        }
    }
}

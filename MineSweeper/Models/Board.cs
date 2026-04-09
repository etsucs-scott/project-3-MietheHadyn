using System.Text;


namespace MineSweeper.Models
{
    public class Board
    {
        private Random rand = new Random();

        public object cell { get; set; } //this will be used to determine what is in the cell
        public object[,] board { get; set; }
        public int Bombcount = 0; //this will be updated/replaced by the number of bombed based on level size
        public List<(int, int)> bombLocations = new List<(int, int)>();

        //display/visuals
        public static string Hidden = "#";
        public static string flag = "F";
        public static string bomb = "b"; //bomb display same as hidden as to not expose bomb location
        public static string explode = "X"; //explosion for loss
        public static string emptyRevealed = ".";
        public int NearBomb = 1; //between 1-8, if there's bombs nearby.

        /// <summary>
        /// Generate a game board based on player's size selection
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Board(int x, int y, int b)
        {
            //remember, this must be called AFTER asking player for board size input, variables from there used here
            board = new object[x, y];
            Bombcount = b;
        }


        /// <summary>
        /// finds an empty cell in an array
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public (int, int) FindEmptyCell(object[,] board, int width, int height)
        {
            int x, y;
            do
            {
                x = rand.Next(width); //avoid edges
                y = rand.Next(height);
            } while (board[x, y] != null); //keep looking until empty cell
            return (x, y);
        }

        /// <summary>
        /// Places specified number of bombs randomly on the board, using a seed for reproducibility
        /// </summary>
        public void seedPlaceBombs(int seed, int width, int height, int Bombcount)
        {
            Random r = new(seed);

            for (int i = 0; i < Bombcount; i++)
            {
                int x = r.Next(width);
                int y = r.Next(height);
                board[x, y] = bomb;
                bombLocations.Add((x, y));
            }
            Console.WriteLine($"board currently has {Bombcount} bombs");
        }



        public void DisplayBoard()
        {
            Console.Write("  ");
            for (int j = 0; j < board.GetLength(1); j++)
            {
                Console.Write(j + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    var cell = board[i, j];
                    //show hidden marker if null, otherwise the cell's display
                    Console.Write(cell == null ? Board.Hidden + " " : cell.ToString() + " ");
                }
                Console.WriteLine();
            }
        }

        public string ToString(Board[,] board)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (board[i, j] is null)
                    {
                        sb.Append("  ");
                        continue;

                    }
                    Type type = board[i, j].GetType();

                    if (type.Equals(typeof(Flag)))
                    {
                        sb.Append("F");
                    }
                    else if (type.Equals(typeof(Bomb)))
                    {
                        sb.Append("#"); //bombs are hidden until revealed, upon revealed, game loss //doesnt work
                    }
                    else
                    {
                        sb.Append(board[i, j]); //display character
                    }
                    sb.Append(' ');
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

    }
}

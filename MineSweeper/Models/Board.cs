using System.Text;


namespace MineSweeper.Models
{
    public class Board
    {
        private Random rand = new Random();

        public object tile { get; set; } //this will be used to determine what is in the cell
        public object[,] board { get; set; }
        private int Bombcount = 0; //this will be updated/replaced by the number of bombed based on level size

        //display/visuals
        public static string Hidden = "#";
        public static string flag = "F";
        public static string bomb = "b";
        public static string epmptyRevealed = ".";
        public int RevealNearBomb = 1; //between 1-8, if there's bombs nearby. make a method for being near a bomb to determine what number is placed based on how many nearby bombs

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
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public (int, int) FindEmptyCell(object[,] board, int width, int height)
        {
            int x, y;
            do
            {
                x = rand.Next(width-1, height-1); //avoid edges
                y = rand.Next(width-1, height-1);
            } while (board[x, y] != null); //keep looking until empty cell
            return (x, y);
        }

        public void PlaceBombs(Board board) //should this return something?
        {
            for (int i = 0; i < Bombcount; i++)
            {
                var (x, y) = FindEmptyCell(board.board, board.board.GetLength(0), board.board.GetLength(1));
                board.board[x, y] = bomb;
                Console.WriteLine($"board currently has {Bombcount} bombs");
                
            }
        }

        


        public void DisplayBoard(Board board)

        {
            for (int i = 0; i < board.board.GetLength(0); i++)
            {
                for (int j = 0; j < board.board.GetLength(1); j++)
                {
                    var cell = board.board[i, j];
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
                        sb.Append("b");
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

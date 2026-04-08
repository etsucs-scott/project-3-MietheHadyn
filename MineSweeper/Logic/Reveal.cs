using MineSweeper.Models;


namespace MineSweeper.Logic
{
    internal class Reveal
    {
        public bool isRevealed = new bool(); //is this even used?


        /// <summary>
        /// counts the number of bombs in the 8 surrounding tiles and updates the revealed tile with that number
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="board"></param>
        public void nearbyBombs(int x, int y, Board board)  
        {
            int bombCount = 0;
            int rows = board.board.GetLength(0);
            int cols = board.board.GetLength(1);
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int nr = x + i, nc = y + j;
                    if (nr < 0 || nr >= rows || nc < 0 || nc >= cols) continue;
                    if (board.board[nr, nc]?.ToString() == Board.bomb) bombCount++;
                }
            }
            board.board[x, y] = bombCount > 0 ? bombCount.ToString() : Board.emptyRevealed;
        } 

        


       
        /// <summary>
        /// reveals the selected tile, checks if it's a bomb or has bombs nearby, and updates the board accordingly.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool actReveal(int x, int y, Board board) 
        {
            var cell = board.board[x, y];
            bool bombFound = false;

            if (cell == null)
            {
                nearbyBombs(x, y, board);
                cell = Board.emptyRevealed;
                return bombFound = false;
            }
            else if (cell.ToString() == Board.bomb)
            {
                Console.WriteLine("Bomb Found! Game over.");
                board.board[x,y] = Board.explode; 
                return bombFound = true;
            }
            else if (cell.ToString() == Board.emptyRevealed)
            {
                Console.WriteLine("you've already revealed this space, try again.");
                return bombFound = false;
            }
            else
            {
                nearbyBombs(x, y, board);
                return bombFound = false;
            }
        }
    }
    

}


using MineSweeper.Models;


namespace MineSweeper.Logic
{
    internal class Reveal
    {
        public bool isRevealed = new bool(); //is this even used?


        public void nearbyBombs(int x, int y, Board board) //this is for the numbers that appear when you reveal a tile next to a bomb; it counts the number of bombs in the 8 surrounding tiles and updates the revealed tile with that number
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

        void BFSGrid(int[,] board, int x, int y) //code straight from the slide, unused?
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            var seen = new bool[rows, cols];
            var q = new Queue<(int r, int c)>();
            int[] dr = { 0, 1, 0, -1 }; //directions for BFS, right, down, left, up
            int[] dc = { 1, 0, -1, 0 }; //directions for BFS, right, down, left, up
            seen[x, y] = true; q.Enqueue((x, y));
            while (q.Count > 0)
            {
                var (r, c) = q.Dequeue();
                for (int k = 0; k < 4; k++)
                {
                    int nr = r + dr[k], nc = c + dc[k];
                    if (nr < 0 || nr >= rows || nc < 0 || nc >= cols || seen[nr, nc]) continue;
                    seen[nr, nc] = true; q.Enqueue((nr, nc));
                }
            }


        }

        public void actReveal(int x, int y, Board board) //probs should return something, what?
        {
            var cell = board.board[x, y];


            if (cell == null)
            {
                nearbyBombs(x, y, board);
                cell = Board.emptyRevealed;
            }
            else if (cell.ToString() == Board.bomb)
            {
                //lose
                Console.WriteLine("Bomb Found! Game over.");
                //something to end the game
            }
            else if (cell.ToString() == Board.emptyRevealed)
            {
                Console.WriteLine("you've already revealed this space, try again.");

            }
            else
            {
                nearbyBombs(x, y, board);
            }
        }
    }
    //code for revealing, if/else based on what is revealed, if bomb, lose, if empty, reveal nearby tiles, if number, reveal number and stop search

}


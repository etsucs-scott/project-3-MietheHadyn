using System.Security.Cryptography.X509Certificates;

namespace MineSweeper.Models
{
    public abstract class BombFlag
    {
        //both bomb and flag stuff goes here, since the search logic (complicated) is already contained in Reveal.cs
        //bomb placement & count referenced, but not created (maybe?). Flags placed based on user input and just sit there
        //complare bomb and flag placement to determine win
        //if bomb is revealed, lose

    }

    public class Bomb : BombFlag
    {
        //bomb placement, count goes here
        public string bomb = "b"; //display
        public bool isRevealed = false; //reveal logic, if true, game over

        public Bomb()
        {
            //obj contstruction logic, idk what to put here
        }

        /// <summary>
        /// Creates and places a bomb in a located empty space in the level
        /// </summary>
        /// <param name="board"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="BombCount"></param>
        public void placeBomb(Board[,] board, int width, int height, int BombCount) //maybe get rid of this one
        {
            if (board == null || board.Length == 0) return;
            (int, int) cellPlace = board[0,0].FindEmptyCell(board, width, height);
            //make that value of the board a bomb
            string bombName = $"bomb{BombCount + 1}";
            BombCount++;
        }
    }

    public class Flag : BombFlag
    {

        public string flag = "F"; //display
        public bool isPlaced = false; //flag placement logic, if true, flag is placed


        public bool PlaceFlag(int x, int y, Board[,] board)
        { 
            bool isPlaced = false;
            var cell = board[x, y];
            //check for valid placement (not revealed)
            if (board[x,y] == null || board[x, y].ToString() == Board.Hidden)
            {
                //place flag
                Board.flag = "F";
                isPlaced = true;
            }

            return isPlaced;
        }
        public Flag()
        {
            string flag = "F";
            isPlaced = true;
            //obj construction logic, idk what to put here
        }
    }
}

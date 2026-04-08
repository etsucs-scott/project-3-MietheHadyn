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
        public string explode = "X"; //explosion for loss
        public bool bombRevealed = false; //reveal logic, if true, game over
        public List<(int, int)> bombLocations = new List<(int, int)>(); //list of bomb locations for win condition checking
        

        /// <summary>
        /// Creates and places a bomb in a located empty space in the level
        /// </summary>
        /// <param name="board"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="BombCount"></param>
        


    }

    public class Flag : BombFlag
    {

        public string flag = "F"; //display
        public bool isPlaced = false; //flag placement logic, if true, flag is placed
        public List<(int, int)> flagLocations = new List<(int, int)>();


        /// <summary>
        /// flags the tile at the given coordinates; if it's already flagged, unflags it
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool PlaceFlag(int x, int y, Board board)
        {
            if (board == null) return false;
            if (x < 0 || x >= board.board.GetLength(0) || y < 0 || y >= board.board.GetLength(1)) return false;

            var cell = board.board[x, y];
            if (cell == null) //hidden
            {
                board.board[x, y] = Board.flag;
                flagLocations.Add((x, y));
                return true;
            }
            else if (cell?.ToString() == Board.flag) //unflag
            {
                board.board[x, y] = null;
                flagLocations.Remove((x, y));
                return false;
            }
            return false;
        }
        
    }
}

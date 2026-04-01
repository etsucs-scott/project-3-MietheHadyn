using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MineSweeper.Models
{
    internal class Board
    {
        //display/visuals
        public object[,] Gameboard { get; set; }
        private int Bombcount = 0; //this will be updated/replaced by the number of bombed based on level size

        public string Hidden = "#";
        public string flag = "F";
        public string bomb = "b";
        public string epmptyRevealed = ".";
        public int RevealNearBomb = 1; //between 1-8, if there's bombs nearby. make a method for being near a bomb to determine what number is placed based on how many nearby bombes

        /// <summary>
        /// Generate a game board based on player's size selection
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Board(int x, int y, int b)
        {
            //remember, this must be called AFTER asking player for board size input, variables from there used here
            Gameboard = new object[x, y];
            Bombcount = b;
        }

        /// <summary>
        /// places everything in the Board, including the bombs, labels, and empty spaces.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void BoardMaker(int x, int y)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == 0 || i == 9 || j == 0 || j == 9)
                    {
                        //fill top row with numbers 0 - (x-1)
                        /*
                         * pseudo for the numbers to organize thoughts
                         * for x = 0
                         *  number yeach y accoring to index
                         */
                        while (x == 0)
                        {
                            Gameboard[0, j] = j; //fill top row with numbers 0 - (x-1)

                        } //make an xunit test?

                        //fill left column with numbers 0 - (y-1)
                        while (y == 0)
                        {
                            Gameboard[i, 0] = i; //fill left column with numbers 0 - (y-1)
                        } //make xUnit test?

                    }
                    else
                    {
                        Gameboard[i, j] = null;

                    }
                }
            }
        }


    }
}

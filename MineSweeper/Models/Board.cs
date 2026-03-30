using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper.Models
{
    internal class Board
    {
        //display/visuals
        public object[,] Gameboard { get; set; }

        public string Hidden = "#";
        public string flag = "F";
        public string bomb = "b";
        public string epmptyRevealed = ".";
        public int RevealNearBomb = 1; //between 1-8, if there's bombs nearby


    }
}

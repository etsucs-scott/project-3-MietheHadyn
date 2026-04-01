using System;
using System.Collections.Generic;
using System.Text;

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
    }

    public class Flag : BombFlag
    {
        
        public string flag = "F"; //display
        public bool isPlaced = false; //flag placement logic, if true, flag is placed

        public Flag()
        {
            //obj construction logic, idk what to put here
        }
    }
}

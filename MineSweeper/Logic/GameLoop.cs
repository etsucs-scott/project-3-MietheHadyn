using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Timers;
using MineSweeper.Models;

namespace MineSweeper.Logic
{
    internal class GameLoop
    {
        private static System.Timers.Timer gameTimer = new System.Timers.Timer(1000);

        //manage game loop, win/loss, timer
        public bool End = false; //bool to determine if the game ended 
        public bool win = false; //bool to determine win

        
        public static void PlayGame() //prob returns something, figure it out later
        {
            bool End = false;
            bool win = false;

            var input = new MineSweeper.Logic.Input();
            var dims = input.AltBoardSelect();  //returns Tuple<int,int,int>
            int width = dims.Item1;
            int height = dims.Item2;
            int bombs = dims.Item3;

            TimeOnly startTime = new TimeOnly();
            int seed = new Seeds().SeedInput(startTime);
            Console.WriteLine(seed);
            var board = new Board(width, height, bombs);
            board.PlaceBombs(); //causes the code to kinda stop dead; no crash, just no continuing and no inputs

            board.DisplayBoard(); //print the 2D array to console
            var flagger = new Flag(); //flag instancer

            while (End == false)
            {
                string action = input.Action(); //returns string of either "reveal" or "flag"
                int x = input.XSelection(); //returns int for x coordinate
                int y = input.YSelection(); //returns int for y coordinate
                if (action == "reveal")
                {
                    Console.WriteLine("Reveal method");
                    //Reveal.actReveal(x, y, board); //reveal the tile at the coordinates; if it's a bomb, End = true and win = false; if it's not a bomb, reveal the tile and check if the player has won
                }
                else if (action == "flag")
                {
                    Console.WriteLine("Flaging method");
                    flagger.PlaceFlag(x, y, board); //flag the tile at the coordinates; if it's already flagged, unflag it
                    //this doesn't work at all
                }
                board.DisplayBoard(); //print the 2D array to console
                 //check win condition; if all non-bomb tiles are revealed, End = true and win = true
            }//auto-generated; does this work? test

        }

    }
}

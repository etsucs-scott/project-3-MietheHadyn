using System;
using System.Collections.Generic;
using System.Text;


namespace MineSweeper.Models
{
    internal class HighScores
    {
      //ref timer in program.cs for score: fastes completion tme in seconds, or 0000 if loss; save to file with seed
      public static int ScoreCalc( DateTime startTime, DateTime endTime, bool win)
        {
            int score = 0000;

            //calced via endtime - startTime, or 0000 if loss
            if (win)
            {
                //convert times to ints
                int intStartTime = (int)startTime.TimeOfDay.TotalSeconds;
                int intEndTime = (int)endTime.TimeOfDay.TotalSeconds;
                //calc score
                score = intEndTime - intStartTime;
                return score;

            }
            else
            {
                return score = 00000;
            }

        }
    }
}

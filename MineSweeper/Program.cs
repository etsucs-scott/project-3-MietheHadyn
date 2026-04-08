//Credits: debugging and some coding assistance provided by Github copilot, General aid in the coding process provied by Professor Scott
//Most code, logic, and structure provided by me

using MineSweeper.Logic;
using MineSweeper.Models;


Console.WriteLine("Playing Minesweeper: Seeds will not save the game state, only highscore and bomb location");
Console.WriteLine("Main menu:");

var results = GameLoop.PlayGame();
DateTime endTime = results.Item1;
DateTime startTime = results.Item2;
bool win = results.Item3;
int highscore =  HighScores.ScoreCalc(endTime, startTime, win);
Console.WriteLine($"Your score is:{highscore}");











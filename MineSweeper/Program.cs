//Credits: debugging and some coding assistance provided by Github copilot, Most code, logic, and structure provided by me

using MineSweeper.Logic;
using MineSweeper.Models;

/* order of operations, delete once actually done:
 * print basic menu, simple writelines in main
 * ask player input for board size
 * ask player for a seed, if none given, generate based on date
 * create board based on that size & seed; display it
 * start timer for highscore
 * gameplay loop:
 *    ask for player x, then y, then what to do r/f
 *    do that, update and display board
 * once an win/loss condition is met, end game, display and save score&seed (IF LOSS: SCORE IS 0000)
 */


Console.WriteLine("Playing Minesweeper: Seeds will not save the game state, only highscore and bomb location");
Console.WriteLine("Main menu:");

GameLoop.PlayGame();









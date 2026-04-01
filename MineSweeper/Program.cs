using MineSweeper.Models;

Console.WriteLine("Playing Minesweeper: Seeds will not save the game state, only highscore and bomb location");
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

Board board = new Board(10, 10, 10); //temp build just to see if it works
Console.WriteLine(board);
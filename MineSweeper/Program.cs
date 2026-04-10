//Credits: debugging and some coding assistance provided by Github copilot, General aid in the coding process provied by Professor Scott
//Most code, logic, and structure provided by me

using MineSweeper.Logic;
using MineSweeper.Models;


Console.WriteLine("Playing Minesweeper: Seeds will not save the game state, only highscore and bomb location");
Console.WriteLine("Main menu:");


while (true)
{
    Console.WriteLine("Do you want to Play a game or View a highscore? (enter P or V)");
    string? input = Console.ReadLine()?.Trim().ToLower();
    if (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("Invalid input. Try again.");
        continue;
    }
    if (input == "p" || input == "play")
    {
        var results = GameLoop.PlayGame();
        DateTime endTime = results.Item1;
        DateTime startTime = results.Item2;
        bool win = results.Item3;
        int seed = results.Item4;
        int highscore = HighScores.ScoreCalc(endTime, startTime, win);
        Console.WriteLine($"Your score is:{highscore}");
        //save highscore and seed to file
        var fileIo = new FileIO();
        fileIo.SaveHighScore(seed, highscore);
        Environment.Exit(0);
    }
    else if (input == "v" || input == "view")
    {
        var fileIo = new FileIO();
        var loadScore = fileIo.LoadHighScore();
        int seed = loadScore.Item1;
        int score = loadScore.Item2;
        HighScores.DisplayHighScores(score, seed);
        
    }
    else
    {
        Console.WriteLine("Invalid input. Try again.");
    }
}



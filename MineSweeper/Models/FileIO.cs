using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper.Models
{
    internal class FileIO
    {
        //store high scores, seeds in files
        string ItmFileType = "txt";
        string ItmFileName = "HighScore_File";
        string Itempath;

        public FileIO()
        {
            Itempath = $@"{ItmFileName}.{ItmFileType}";
        }

        public void SaveHighScore(int seed, int score)
        {
            Console.WriteLine("What is the player's name?");
            string playerName = Console.ReadLine();
            string highScoreEntry = $"{seed}: {score}";
            try
            {
                using (StreamWriter sw = new StreamWriter(Itempath, true))
                {
                    sw.WriteLine(highScoreEntry); 
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving high score: {ex.Message}");
            } //xunit test to make sure file works
        }

        public Tuple<int, int> LoadHighScore()
        {
            try
            {
                using (StreamReader sr = new StreamReader(Itempath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var parts = line.Split(':');
                        if (parts.Length == 2 && int.TryParse(parts[0].Trim(), out int seed) && int.TryParse(parts[1].Trim(), out int score))
                        {
                            return Tuple.Create(seed, score);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading high score: {ex.Message}");
            }
            return null; //xunit test to make sure file works
        } //this whole thing was autofilled so idk how well this may work
    }
}

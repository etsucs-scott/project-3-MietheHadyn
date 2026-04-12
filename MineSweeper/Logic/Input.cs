using MineSweeper.Models;

namespace MineSweeper.Logic
{
    internal class Input
    {
        //manage user input here, especially all the Try/Catch and Exception handling

        /// <summary>
        /// gets user input to select size of board and number of bombs
        /// </summary>
        /// <returns> x and y dimensions </returns>
        public Tuple<int, int, int> BoardSelect()
        {
            while (true)
            {
                Console.WriteLine("Select Board size: \n1) [8,8] \n2) [12,12] \n3) [16,16]");
                string? raw = Console.ReadLine();
                if (int.TryParse(raw, out int choice) && choice >= 1 && choice <= 3)
                {
                    if (choice == 1)
                    {
                        Console.WriteLine("Maze dimenstions: 8x8 || Mine count: 10");
                        return Tuple.Create(8, 8, 10);
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("Maze dimenstions: 12x12 || Mine count: 25");
                        return Tuple.Create(12, 12, 25);
                    }
                    else // choice == 3
                    {
                        Console.WriteLine("Maze dimenstions: 16x16 || Mine count: 40");
                        return Tuple.Create(16, 16, 40);
                    }
                }

                Console.WriteLine("Invalid input; try again.");
            }
        } //xUnit test for this? sounds good?

        /// <summary>
        /// gets user input of user's action druing play
        /// </summary>
        /// <returns></returns>
        public string Action()
        {
            while (true)
            {
                Console.WriteLine("Reveal (r) or Flag (f)? ");
                string? input = Console.ReadLine()?.Trim().ToLower();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Invalid action. Try again.");
                    continue;
                }

                if (input == "r" || input == "reveal")
                {
                    return "reveal";
                }
                else if (input == "f" || input == "flag")
                {
                    return "flag";
                }
                else
                {
                    Console.WriteLine("Invalid action. Try again.");
                }
            }
        }

        /// <summary>
        /// gets user input for X coodinate
        /// </summary>
        /// <returns></returns>
        public int XSelection(int? width = null) //y and x are flipped in the board?? this gets the y coordinate
        {
            while (true)
            {
                if (width.HasValue)
                    Console.WriteLine($"Enter The Y coordinate (0-indexed, 0...{width.Value - 1}): ");
                else
                    Console.WriteLine("Enter The Y coordinate (0-indexed): ");

                string? raw = Console.ReadLine();
                if (int.TryParse(raw, out int x) && x >= 0 && (!width.HasValue || x < width.Value))
                {
                    return x;
                }

                Console.WriteLine("Invalid input; try again.");
            }
        }

        /// <summary>
        /// Get's user input for Y coodinate
        /// </summary>
        /// <returns></returns>
        public int YSelection(int? height = null) //x and y are flipped on the board?? this gets the x coordinate
        {
            while (true)
            {
                if (height.HasValue)
                    Console.WriteLine($"Enter The X coordinate (0-indexed, 0..{height.Value - 1}): ");
                else
                    Console.WriteLine("Enter The X coordinate (0-indexed): ");

                string? raw = Console.ReadLine();
                if (int.TryParse(raw, out int y) && y >= 0 && (!height.HasValue || y < height.Value))
                {
                    return y;
                }

                Console.WriteLine("Invalid input; try again.");
            }
        }
        //add xUnit tests to verify valid/invalid input, [theory] or [Fact]?
    }
}

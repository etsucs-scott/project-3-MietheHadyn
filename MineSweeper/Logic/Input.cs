using MineSweeper.Models;

namespace MineSweeper.Logic
{
    internal class Input
    {
        //manage user input here, especially all the Try/Catch and Exception handling

        /// <summary>
        /// gets user input to select size of board
        /// </summary>
        /// <returns> x and y dimensions </returns>
        public static Board[,] BoardSelect()
        {

            Console.WriteLine("Select Board size: \n1) [8,8] \n2) [12,12] \n3) [16,16]");
            if (int.TryParse(Console.ReadLine(), out int choice) && 0 <= choice && choice <= 3)
            {
                if (choice == 1)
                {
                    object[,] board = new object[8, 8];
                    return (Board[,])board;
                }
                else if (choice == 2)
                {
                    object[,] board = new object[12, 12];
                    return (Board[,])board;
                }
                else if (choice == 3)
                {
                    object[,] board = new object[16, 16];
                    return (Board[,])board;
                }
                else
                {
                    Console.WriteLine("Invalid input; try again (temporary default to [8,8])");
                    object[,] board = new object[8, 8];
                    return (Board[,])board; //temporary default
                }

            }
            else
            {
                Console.WriteLine("Invalid input; try again (temporary default to [8,8])");
                object[,] board = new object[8, 8];
                return (Board[,])board; //temporary default
            }


        } //xUnit test for this? sounds good?

        public Tuple<int, int, int> AltBoardSelect()
        {

            Console.WriteLine("Select Board size: \n1) [8,8] \n2) [12,12] \n3) [16,16]");
            if (int.TryParse(Console.ReadLine(), out int choice) && 0 <= choice && choice <= 3)
            {
                if (choice == 1)
                {
                    Console.WriteLine("Maze dimenstions: 8x8 || Mine count: 6");
                    return Tuple.Create(8, 8, 6);
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Maze dimenstions: 12x12 || Mine count: 10");
                    return Tuple.Create(12, 12, 10);
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Maze dimenstions: 16x16 || Mine count: 14");
                    return Tuple.Create(16, 16, 12);
                }
                else
                {
                    Console.WriteLine("Invalid input; try again (temporary default to [8,8] w/ 6 bombs)");
                    return Tuple.Create(8, 8, 6); //temporary default
                }

            }
            else
            {
                Console.WriteLine("Invalid input; try again (temporary default to [8,8] w/ 6 bombs)");
                return Tuple.Create(8, 8, 6); //temporary default
            }


        } //xUnit test for this? sounds good?

        /// <summary>
        /// gets user input of user's action druing play
        /// </summary>
        /// <returns></returns>
        public string Action()
        {
            Console.WriteLine("Reveal or flag? ");
            if (Console.ReadLine().ToLower() == "r")
            {
                return "r";
            }
            else if (Console.ReadLine().ToLower() == "f")
            {
                return "f";
            }
            else
            {
                Console.WriteLine("Invalid action. Try again");
                return "shits fucked my guy"; //temp default
            }

        }

        /// <summary>
        /// gets user input for X coodinate
        /// </summary>
        /// <returns></returns>
        public int XSelection()
        {
            Console.WriteLine("Enter The X coordinate: ");
            if (int.TryParse(Console.ReadLine(), out int x) && 0 <= x && x <= 9)
            {
                return x;
            }
            else
            {
                Console.WriteLine("Invalid input; try again (temporary default to 0)");
                return 0; //temporary default
            }
        }

        /// <summary>
        /// Get's user input for Y coodinate
        /// </summary>
        /// <returns></returns>
        public int YSelection()
        {
            Console.WriteLine("Enter The Y coordinate: ");
            if (int.TryParse(Console.ReadLine(), out int y) && 0 <= y && y <= 9)
            {
                return y;
            }
            else
            {
                Console.WriteLine("Invalid input; try again (temporary default to 0)");
                return 0; //temporary default
            }
        }
        //add xUnit tests to verify valid/invalid input, [theory] or [Fact]?



    }
}

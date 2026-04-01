using System.Security.Cryptography.X509Certificates;

namespace MineSweeper.Logic
{
    internal class Input
    {
        //manage user input here, especially all the Try/Catch and Exception handling


        public Tuple<int,int> BoardSelect() 
        {
            
            Console.WriteLine("Select Board size: \n1) [8,8] \n2) [12,12] \n3) [16,16]");
            if (int.TryParse(Console.ReadLine(), out int choice) && 0 <= choice && choice <= 3)
            {
                if (choice == 1)
                {
                    return Tuple.Create(8, 8);
                }
                else if (choice == 2)
                {
                    return Tuple.Create(12, 12);
                }
                else if (choice == 3)
                {
                    return Tuple.Create(16, 16);
                }
                else
                {
                    Console.WriteLine("Invalid input; try again (temporary default to [8,8])");
                    return Tuple.Create(8, 8); //temporary default
                }
                
            }
            else
            {
                Console.WriteLine("Invalid input; try again (temporary default to [8,8])");
                return Tuple.Create(8, 8); //temporary default
            }


        } //xUnit test for this? sounds good?

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

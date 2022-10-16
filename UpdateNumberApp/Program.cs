using System;

namespace UpdateNumberApp
{
    internal class Program
    {
        private static readonly string fileName = @"TotalNumber.txt";

        private static void Main(string[] args)
        {
            var numUpdate = new UpdateNumber(0);

            while (true)
            {
                // Ask for input.
                Console.WriteLine("Please enter a number: ");
                string useInput = null;
                var intVal = 0;
                try
                {
                    useInput = Console.ReadLine();
                    intVal = Convert.ToInt32(useInput);
                }
                catch (Exception e)
                {
                    if (useInput?.ToLower() == "exit")
                        break;

                    Console.WriteLine(e.Message);
                    continue;
                }

                // Update the number.
                numUpdate.ReadNumber(fileName);
                numUpdate.CalculateTotal(intVal);
                numUpdate.WriteNumber(fileName);

                Console.WriteLine("Total number: {0}\n", numUpdate.Number);
            }
        }
    }
}
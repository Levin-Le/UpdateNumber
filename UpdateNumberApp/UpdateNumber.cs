using System;
using System.IO;

namespace UpdateNumberApp
{
    public class UpdateNumber : IUpdateNumber
    {
        private const int Threshold = 152;

        public UpdateNumber(int number)
        {
            Number = number;
        }

        public int Number { get; private set; }


        public bool ReadNumber(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    using var reader = new StreamReader(path);

                    //Read the first line of text as the total number.
                    var line = reader.ReadLine();
                    Number = Convert.ToInt32(line);

                    if (reader.ReadLine() != null)
                        Console.WriteLine("Warning! There are multiple numbers in the file.");
                }
                else
                {
                    //if the file is not exists, give a default value 0.
                    Number = 0;
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Number = 0;
                return false;
            }
        }

        public bool WriteNumber(string path)
        {
            try
            {
                using var writer = new StreamWriter(path, false);

                writer.WriteLine(Number);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Write failed: " + e.Message);
                return false;
            }
        }

        public int CalculateTotal(int inputNumber)
        {
            try
            {
                Number += inputNumber;

                if (Number > Threshold)
                    Number -= Threshold;
                return Number;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Number = 0;
                return Number;
            }
        }
    }
}
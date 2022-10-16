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
                    using var reader = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None));

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
                long totalNumber = (long) Number + (long) inputNumber;

                if (totalNumber >= int.MaxValue || totalNumber <= int.MinValue)
                {
                    Number = 0;
                }
                else
                {
                    if (totalNumber > Threshold)
                        Number = (int) totalNumber - Threshold;
                    else
                        Number = (int) totalNumber;
                }

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
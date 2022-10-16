using System;

namespace UpdateNumberApp
{
    public class UpdateNumber : IUpdateNumber
    {
        public UpdateNumber(int number)
        {
            Number = number;
        }
        
        public int Number { get; }


        public bool ReadNumber(string path)
        {
            throw new NotImplementedException();
        }

        public bool WriteNumber(string path)
        {
            throw new NotImplementedException();
        }

        public int CalculateTotal(int inputNumber)
        {
            throw new NotImplementedException();
        }
    }
}
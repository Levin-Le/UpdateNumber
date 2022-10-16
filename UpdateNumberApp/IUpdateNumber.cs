using System;
using System.Collections.Generic;
using System.Text;

namespace UpdateNumberApp
{
    interface IUpdateNumber
    {
        int Number { get; }

        /// <summary>
        /// Read the number from the source
        /// </summary>
        /// <param name="path">source</param>
        /// <returns>The read number</returns>
        bool ReadNumber(string path);

        /// <summary>
        /// Write the total number to the source.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        bool WriteNumber(string path);
    }
}

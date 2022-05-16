using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class WordBank
    {
        public string Word { get; set; }

        /// <summary>
        /// WordBank Parameterized Constructor
        /// Sets parameter data to property data for corresponding WordBank object
        /// </summary>
        /// <param name="inputWrd"></param>
        public WordBank(string inputWrd)
        {
            Word = inputWrd;
        }
    }
}

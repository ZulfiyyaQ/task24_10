using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task16.Exeptions
{
    internal class QuizAlreadyExits : Exception
    {
        private const string _message = "Bu quiz artiq movcutdur";
        public QuizAlreadyExits(string message = _message) : base(message)
        {

        }
    }
}

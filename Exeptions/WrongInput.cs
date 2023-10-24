using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task16.Exeptions
{
    internal class WrongInput:Exception
    {
        private const string _message = "Sehv deyer daxil edildi";
        public WrongInput(string message = _message) : base(message)
        {

        }
    }
}
 
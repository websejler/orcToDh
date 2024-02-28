using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orcToDh.Exceptions
{
    public class WrongDataFormatExeception : Exception
    {
        public WrongDataFormatExeception() : base("Wrong data format")
        {
        }
        
        public WrongDataFormatExeception(string message) : base(message)
        {
        }

        public WrongDataFormatExeception(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}

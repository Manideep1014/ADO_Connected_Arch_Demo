using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Connected_Arch_Demo.Exceptions
{
    internal class IdNotFoundException:Exception
    {
        public IdNotFoundException(string msg):base(msg)
        { 
        }
    }
}

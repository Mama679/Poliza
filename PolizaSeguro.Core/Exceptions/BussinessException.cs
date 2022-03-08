using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolizaSeguro.Core.Exceptions
{
    public class BussinessException:Exception
    {
        public BussinessException() { }

        public BussinessException(string mensaje) : base(mensaje)
        {

        }
    }
}

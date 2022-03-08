using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolizaSeguro.Api.Response
{
    public class Respuesta<T>
    {
        public T Datos{get; set;}

        public Respuesta( T dato)
        {
            Datos = dato;
        }
    }
}

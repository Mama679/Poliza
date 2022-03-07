using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolizaSeguro.Core.DTO
{
    public class ClienteDto    
    {        
        public int IdCliente { get; set; }
        public string Identificacion { get; set; }
        public string NombresCliente { get; set; }
        public string ApellidosCliente { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
    }
}

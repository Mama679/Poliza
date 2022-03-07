using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolizaSeguro.Core.DTO
{
    public class AutoDto
    {
        public int IdAuto { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string CiudadPlaca { get; set; }
        public bool? Inspeccion { get; set; }
        public int? ClienteId { get; set; }
    }
}

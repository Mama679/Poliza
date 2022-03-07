using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolizaSeguro.Core.DTO
{
    public class RadicadoDto
    {
        public int IdRadicado { get; set; }
        public string NumPoliza { get; set; }
        public int? PolizaId { get; set; }
        public DateTime? FechaRad { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? AutoId { get; set; }
    }
}

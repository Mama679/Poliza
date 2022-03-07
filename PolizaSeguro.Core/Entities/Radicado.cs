using System;
using System.Collections.Generic;

#nullable disable

namespace PolizaSeguro.Core.Entities
{
    public partial class Radicado
    {
        public int IdRadicado { get; set; }
        public string NumPoliza { get; set; }
        public int? PolizaId { get; set; }
        public DateTime? FechaRad { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? AutoId { get; set; }

        public virtual Auto Auto { get; set; }
        public virtual Poliza Poliza { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace PolizaSeguro.Core.Entities
{
    public partial class Auto
    {
        public Auto()
        {
            Radicados = new HashSet<Radicado>();
        }

        public int IdAuto { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string CiudadPlaca { get; set; }
        public bool? Inspeccion { get; set; }
        public int? ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Radicado> Radicados { get; set; }
    }
}

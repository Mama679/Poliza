using System;
using System.Collections.Generic;

#nullable disable

namespace PolizaSeguro.Core.Entities
{
    public partial class Poliza
    {
        public Poliza()
        {
            Radicados = new HashSet<Radicado>();
        }

        public int IdPoliza { get; set; }
        public string NombrePoliza { get; set; }
        public string Cobertura { get; set; }
        public decimal ValorMaximo { get; set; }
        public bool Activa { get; set; }

        public virtual ICollection<Radicado> Radicados { get; set; }
    }
}

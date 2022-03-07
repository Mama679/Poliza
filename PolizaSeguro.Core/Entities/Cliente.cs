using System;
using System.Collections.Generic;

#nullable disable

namespace PolizaSeguro.Core.Entities
{
    public partial class Cliente
    {
        public Cliente()
        {
            Autos = new HashSet<Auto>();
        }

        public int IdCliente { get; set; }
        public string Identificacion { get; set; }
        public string NombresCliente { get; set; }
        public string ApellidosCliente { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }

        public virtual ICollection<Auto> Autos { get; set; }
    }
}

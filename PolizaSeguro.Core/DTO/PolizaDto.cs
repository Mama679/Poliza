using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolizaSeguro.Core.DTO
{
    public class PolizaDto
    {
        public int IdPoliza { get; set; }
        public string NombrePoliza { get; set; }
        public string Cobertura { get; set; }
        public decimal ValorMaximo { get; set; }
        public bool Activa { get; set; }
    }
}

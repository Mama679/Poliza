using PolizaSeguro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolizaSeguro.Core.Interfaces
{
    public interface IPolizaRepository
    {
        Task<IEnumerable<Poliza>> getPolizas();
        Task<Poliza> getPoliza(int id);
        Task<bool> addPoliza(Poliza poliza);

        Task<bool> updatePoliza(Poliza poliza);
        
    }
}

using PolizaSeguro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolizaSeguro.Core.Interfaces
{
    public interface IClienteServices
    {
        Task<IEnumerable<Cliente>> getClientes();
        Task<Cliente> getCliente(int id);
        Task<bool> addCliente(Cliente cliente);

        Task<bool> updateCliente(Cliente cliente);
        Task<bool> deleteCliente(int id);
    }
}

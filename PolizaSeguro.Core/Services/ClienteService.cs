using PolizaSeguro.Core.Entities;
using PolizaSeguro.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolizaSeguro.Core.Services
{
    public class ClienteService : IClienteServices
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteService(IClienteRepository _clienteRepository)
        {
            clienteRepository = _clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> getClientes()
        {
            return await clienteRepository.getClientes();
        }

        public async Task<Cliente> getCliente(int id)
        {
            return await clienteRepository.getCliente(id);
        }        

        public async Task<bool> addCliente(Cliente cliente)
        {
            return await clienteRepository.addCliente(cliente);
        }

        public async Task<bool> updateCliente(Cliente cliente)
        {
            return await clienteRepository.updateCliente(cliente);
        }

        public async Task<bool> deleteCliente(int id)
        {
            return await clienteRepository.deleteCliente(id);
        }

       

    }
}

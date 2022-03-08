using PolizaSeguro.Core.Entities;
using PolizaSeguro.Core.Exceptions;
using PolizaSeguro.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolizaSeguro.Core.Services
{
    public class AutoService : IAutoService
    {

        private readonly IAutoRepository autoRepository;
        private readonly IClienteRepository clienteRepository;

        public AutoService(IAutoRepository _autoRepository, IClienteRepository _clienteRepository)
        {
            autoRepository = _autoRepository;
            clienteRepository = _clienteRepository;
        }
        public async Task<bool> addAuto(Auto auto)
        {
            var cliente = await clienteRepository.getCliente(auto.ClienteId);
            if(cliente == null)
            {
                throw new BussinessException("Cliente no Existe");
            }
            return await autoRepository.addAuto(auto);
        }

        public async Task<bool> deleteAuto(int id)
        {
            return await autoRepository.deleteAuto(id);
        }

        public async Task<Auto> getAuto(int id)
        {
            return await autoRepository.getAuto(id);
        }

        public async Task<IEnumerable<Auto>> getAutos()
        {
            return await autoRepository.getAutos();
        }

        public async Task<bool> updateAuto(Auto auto)
        {
            return await autoRepository.updateAuto(auto);
        }
    }
}

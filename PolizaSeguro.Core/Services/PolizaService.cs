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
    public class PolizaService: IPolizaService
    {
        private readonly IPolizaRepository polizaRepository;

        public PolizaService(IPolizaRepository _polizaRepository)
        {
            polizaRepository = _polizaRepository;
        }

        public async Task<bool> addPoliza(Poliza poliza)
        {
            return await polizaRepository.addPoliza(poliza);
        }

        public async Task<Poliza> getPoliza(int id)
        {
            return await polizaRepository.getPoliza(id);
        }

        public async Task<IEnumerable<Poliza>> getPolizas()
        {
            return await polizaRepository.getPolizas();
        }

        public async Task<bool> updatePoliza(Poliza poliza)
        {
            return await polizaRepository.updatePoliza(poliza);
        }
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PolizaSeguro.Core.DTO;
using PolizaSeguro.Core.Entities;
using PolizaSeguro.Core.Interfaces;
using PolizaSeguro.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolizaSeguro.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly BD_PolizasContext context;

        public ClienteRepository(BD_PolizasContext _context)
        {
            this.context = _context;
        }
        public async Task<IEnumerable<Cliente>> getClientes()
        {
            var clientes = await context.Clientes
                                        .FromSqlRaw("ProcObtenerClientes")
                                        .ToListAsync();           

            return clientes;
        }

        public async Task<Cliente> getCliente(int id)
        {
            var lstcliente = await context.Clientes
                                        .FromSqlRaw("ProcObtenerCliente {0}",id)
                                        .ToListAsync();
            var cliente = lstcliente.First();           
            return cliente;
        }
    }
}

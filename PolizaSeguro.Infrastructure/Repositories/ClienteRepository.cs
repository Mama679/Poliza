using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PolizaSeguro.Core.Entities;
using PolizaSeguro.Core.Interfaces;
using PolizaSeguro.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
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
            var lstcliente = context.Clientes
                                 .FromSqlInterpolated($"EXEC ProcObtenerCliente @clientId = {id}")
                                 .AsAsyncEnumerable();

           await foreach(var cliente in lstcliente)
            {
                return cliente;
            }

            return null;

        }

        public async Task<bool> addCliente(Cliente cliente)
        {
            var parameterID = new SqlParameter("@id",SqlDbType.Int);
            parameterID.Direction = ParameterDirection.Output;

            await context.Database
                         .ExecuteSqlInterpolatedAsync($@"EXEC ProcInsertarCliente
                          @identificacion ={cliente.Identificacion},
                          @nombre_cliente={cliente.NombresCliente},
                          @apellido_cliente = {cliente.ApellidosCliente},
                          @fecha_nacimiento = {cliente.FechaNacimiento},
                          @telefono = {cliente.Telefono},
                          @direccion = {cliente.Direccion},
                          @ciudad = {cliente.Ciudad},
                          @id={parameterID} OUTPUT");
            var id = (int)parameterID.Value;

            return id > 0;
        }

        public async Task<bool> updateCliente(Cliente cliente)
        {
            var parameterID = new SqlParameter("@rows", SqlDbType.Int);
            parameterID.Direction = ParameterDirection.Output;

            var clienteActual = await getCliente(cliente.IdCliente);
            clienteActual.Identificacion = cliente.Identificacion;
            clienteActual.NombresCliente = cliente.NombresCliente;
            clienteActual.ApellidosCliente = cliente.ApellidosCliente;
            clienteActual.FechaNacimiento = cliente.FechaNacimiento;
            clienteActual.Telefono = cliente.Telefono;
            clienteActual.Direccion = cliente.Direccion;
            clienteActual.Ciudad = cliente.Ciudad;

            await context.Database
                         .ExecuteSqlInterpolatedAsync($@"EXEC ProcActualizarClient
                                                      @id_cliente = {clienteActual.IdCliente},
                                                      @identificacion ={clienteActual.Identificacion},
                                                      @nombre_cliente={clienteActual.NombresCliente},
                                                      @apellido_cliente = {clienteActual.ApellidosCliente},
                                                      @fecha_nacimiento = {clienteActual.FechaNacimiento},
                                                      @telefono = {clienteActual.Telefono},
                                                      @direccion = {clienteActual.Direccion},
                                                      @ciudad = {clienteActual.Ciudad},
                                                      @rows={parameterID} OUTPUT");

            var rows = (int)parameterID.Value;
            return rows > 0;
           
        }

        public async Task<bool> deleteCliente(int id)
        {
            var parameterID = new SqlParameter("@rows", SqlDbType.Int);
            parameterID.Direction = ParameterDirection.Output;

            var clienteActual = await getCliente(id);
            

            await context.Database
                         .ExecuteSqlInterpolatedAsync($@"EXEC ProcEliminarCliente
                                                      @id_cliente = {clienteActual.IdCliente},                                                    
                                                      @rows={parameterID} OUTPUT");

            var rows = (int)parameterID.Value;
            return rows > 0;
        }
    }
}

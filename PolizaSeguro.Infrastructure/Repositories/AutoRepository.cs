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
    public class AutoRepository : IAutoRepository
    {
        private readonly BD_PolizasContext context;

        public AutoRepository(BD_PolizasContext _context)
        {
            context = _context;
        }


        public async Task<bool> addAuto(Auto auto)
        {
            var parameterID = new SqlParameter("@id", SqlDbType.Int);
            parameterID.Direction = ParameterDirection.Output;

            await context.Database
                         .ExecuteSqlInterpolatedAsync($@"EXEC ProcInsertarAuto
                            @placa ={auto.Placa},
                            @modelo={auto.Modelo},
                            @ciudad_placa = {auto.CiudadPlaca},
                            @inspeccion = {auto.Inspeccion},
                            @cliente_id = {auto.ClienteId},                         
                            @id={parameterID} OUTPUT");
            var id = (int)parameterID.Value;

            return id > 0;
        }

        public async Task<bool> deleteAuto(int id)
        {
            var parameterID = new SqlParameter("@rows", SqlDbType.Int);
            parameterID.Direction = ParameterDirection.Output;

            var autoActual = await getAuto(id);

            await context.Database
                         .ExecuteSqlInterpolatedAsync($@"EXEC ProcEliminarAuto
                                                      @id_cliente = {autoActual.IdAuto},                                                    
                                                      @rows={parameterID} OUTPUT");
            var rows = (int)parameterID.Value;
            return rows > 0;
        }

        public async Task<Auto> getAuto(int id)
        {
            var lstAutos = context.Autos
                                  .FromSqlInterpolated($"EXEC ProcObtenerAuto @autoId = {id}")
                                  .AsAsyncEnumerable();

            await foreach (var auto in lstAutos)
            {
                return auto;
            }

            return null;
        }

        public async Task<IEnumerable<Auto>> getAutos()
        {
            var autos = await context.Autos
                                       .FromSqlRaw("ProcObtenerAutos")
                                       .ToListAsync();


            return autos;
        }

        public async Task<bool> updateAuto(Auto auto)
        {
            var parameterID = new SqlParameter("@rows", SqlDbType.Int);
            parameterID.Direction = ParameterDirection.Output;

            var autoActual = await getAuto(auto.IdAuto);
            autoActual.IdAuto = auto.IdAuto;
            autoActual.Placa = auto.Placa;
            autoActual.Modelo = auto.Modelo;
            autoActual.CiudadPlaca = auto.CiudadPlaca;
            autoActual.Inspeccion = auto.Inspeccion;
            autoActual.ClienteId = auto.ClienteId;

            await context.Database
                         .ExecuteSqlInterpolatedAsync($@"EXEC ProcActualizarAuto
                                                      @placa = {autoActual.Placa},
                                                      @modelo ={autoActual.Modelo},
                                                      @ciudad_placa={autoActual.CiudadPlaca},
                                                      @inspeccion = {autoActual.Inspeccion},
                                                      @cliente_id = {autoActual.ClienteId},
                                                      @id_auto = {autoActual.IdAuto},
                                                      @rows={parameterID} OUTPUT");

            var rows = (int)parameterID.Value;
            return rows > 0;

        }
    }
}

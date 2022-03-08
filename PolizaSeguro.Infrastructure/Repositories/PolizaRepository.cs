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
    public class PolizaRepository : IPolizaRepository
    {

        private readonly BD_PolizasContext context;

        public PolizaRepository(BD_PolizasContext _context)
        {
            context = _context;
        }

        public async Task<bool> addPoliza(Poliza poliza)
        {
            var parameterID = new SqlParameter("@id", SqlDbType.Int);
            parameterID.Direction = ParameterDirection.Output;

            await context.Database
                         .ExecuteSqlInterpolatedAsync($@"EXEC ProcInsertarPoliza
                            @nombre_poliza ={poliza.NombrePoliza},
                            @cobertura={poliza.Cobertura},
                            @valo_maximo = {poliza.ValorMaximo},
                            @activa = {poliza.Activa},                   
                            @id={parameterID} OUTPUT");
            var id = (int)parameterID.Value;

            return id > 0;
        }

        public async Task<Poliza> getPoliza(int id)
        {
            var lstPolizas = context.Polizas
                                  .FromSqlInterpolated($"EXEC ProcObtenerPoliza @polizaId = {id}")
                                  .AsAsyncEnumerable();

            await foreach (var poliza in lstPolizas)
            {
                return poliza;
            }

            return null;
        }

        public async Task<IEnumerable<Poliza>> getPolizas()
        {
            var polizas = await context.Polizas
                                        .FromSqlRaw("ProcGetPolizas")
                                        .ToListAsync();


            return polizas;
        }

        public async Task<bool> updatePoliza(Poliza poliza)
        {
            var parameterID = new SqlParameter("@rows", SqlDbType.Int);
            parameterID.Direction = ParameterDirection.Output;

            var polizaActual = await getPoliza(poliza.IdPoliza);
            polizaActual.IdPoliza = poliza.IdPoliza;
            polizaActual.NombrePoliza = poliza.NombrePoliza;
            polizaActual.Cobertura = poliza.Cobertura;
            polizaActual.ValorMaximo = poliza.ValorMaximo;
            polizaActual.Activa = poliza.Activa;


            await context.Database
                         .ExecuteSqlInterpolatedAsync($@"EXEC ProcActualizarPoliza
                                                      @nombre_poliza = {polizaActual.NombrePoliza},
                                                      @cobertura ={polizaActual.Cobertura},
                                                      @valo_maximo={polizaActual.ValorMaximo},
                                                      @activa= {poliza.Activa},
                                                      @id_poliza = {polizaActual.IdPoliza},
                                                      @rows={parameterID} OUTPUT");

            var rows = (int)parameterID.Value;
            return rows > 0;
        }
    }
}

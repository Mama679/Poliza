using AutoMapper;
using PolizaSeguro.Core.DTO;
using PolizaSeguro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolizaSeguro.Infrastructure.Mappings
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, Cliente>();

            CreateMap<Auto, AutoDto>();
            CreateMap<AutoDto, Auto>();

            CreateMap<Poliza, PolizaDto>();
            CreateMap<PolizaDto, Poliza>();

            CreateMap<Radicado, RadicadoDto>();
            CreateMap<RadicadoDto, Radicado>();
        }
    }
}

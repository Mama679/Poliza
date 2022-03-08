using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolizaSeguro.Api.Response;
using PolizaSeguro.Core.DTO;
using PolizaSeguro.Core.Entities;
using PolizaSeguro.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolizaSeguro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PolizaController : ControllerBase
    {
        private readonly IPolizaService polizaService;
        private readonly IMapper mapper;

        public PolizaController(IPolizaService _polizaService, IMapper _mapper)
        {
            polizaService = _polizaService;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPolizas()
        {
            var polizas = await polizaService.getPolizas();

            var polizaDtos = mapper.Map<IEnumerable<PolizaDto>>(polizas);
            var respuesta = new Respuesta<IEnumerable<PolizaDto>>(polizaDtos);

            return Ok(respuesta);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPoliza(int id)
        {
            var poliza = await polizaService.getPoliza(id);
            var polizaDto = mapper.Map<PolizaDto>(poliza);
            var respuesta = new Respuesta<PolizaDto>(polizaDto);

            if (polizaDto == null)
            {
                var respuesta1 = new Respuesta<string>("Poliza No existe");
                //return BadRequest();
                return Ok(respuesta1);
            }

            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> PostPoliza(PolizaDto polizaDto)
        {
            var poliza = mapper.Map<Poliza>(polizaDto);
            var resp = await polizaService.addPoliza(poliza);
            var respuesta = new Respuesta<bool>(resp);
            return Ok(respuesta);
        }

        [HttpPut]
        public async Task<IActionResult> PutPoliza(int id, PolizaDto polizadto)
        {
            var poliza = mapper.Map<Poliza>(polizadto);
            poliza.IdPoliza = id;

            var resp = await polizaService.updatePoliza(poliza);
            var respuesta = new Respuesta<bool>(resp);
            return Ok(respuesta);
        }
    }
}

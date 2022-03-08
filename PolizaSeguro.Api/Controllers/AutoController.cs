using AutoMapper;
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
    public class AutoController : ControllerBase
    {
        private readonly IAutoService autoService;
        private readonly IMapper mapper;

        public AutoController(IAutoService _autoService, IMapper _mapper)
        {
            autoService = _autoService;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAutos()
        {
            var autos = await autoService.getAutos();

            var autosDto = mapper.Map<IEnumerable<AutoDto>>(autos);
            var respuesta = new Respuesta<IEnumerable<AutoDto>>(autosDto);

            return Ok(respuesta);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuto(int id)
        {
            var auto = await autoService.getAuto(id);
            var autoDto = mapper.Map<AutoDto>(auto);
            var respuesta = new Respuesta<AutoDto>(autoDto);

            if (autoDto == null)
            {
                var respuesta1 = new Respuesta<string>("Auto No existe");
                //return BadRequest();
                return Ok(respuesta1);
            }

            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> PostAuto(AutoDto autoDto)
        {
            var auto = mapper.Map<Auto>(autoDto);
            var resp = await autoService.addAuto(auto);
            var respuesta = new Respuesta<bool>(resp);
            return Ok(respuesta);
        }

        [HttpPut]
        public async Task<IActionResult> PutAuto(int id, AutoDto autoDto)
        {
            var auto = mapper.Map<Auto>(autoDto);
            auto.IdAuto = id;

            var resp = await autoService.updateAuto(auto);
            var respuesta = new Respuesta<bool>(resp);
            return Ok(respuesta);
        }
    }
}

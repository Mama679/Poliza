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
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IMapper mapper;

        public ClienteController(IClienteRepository _clienteRepository, IMapper _mapper)
        {
            clienteRepository = _clienteRepository;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await clienteRepository.getClientes();

            var clientesDtos = mapper.Map<IEnumerable<ClienteDto>>(clientes);
            var respuesta = new Respuesta<IEnumerable<ClienteDto>>(clientesDtos);

            return Ok(respuesta);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            var cliente = await clienteRepository.getCliente(id);
            var clienteDto = mapper.Map<ClienteDto>(cliente);
            var respuesta = new Respuesta<ClienteDto>(clienteDto);

            if (clienteDto == null)
            {
                var respuesta1 = new Respuesta<string>("Cliente No existe");
                //return BadRequest();
                return Ok(respuesta1);
            }           

            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> PostCliente(ClienteDto clienteDto)
        {
            var cliente = mapper.Map<Cliente>(clienteDto);
            var resp = await clienteRepository.addCliente(cliente);
            var respuesta = new Respuesta<bool>(resp);
            return Ok(respuesta);
        }

        [HttpPut]
        public async Task<IActionResult> PutCliente(int id, ClienteDto clientedto)
        {
            var cliente = mapper.Map<Cliente>(clientedto);
            cliente.IdCliente = id;

            var resp = await clienteRepository.updateCliente(cliente);
            var respuesta = new Respuesta<bool>(resp);
            return Ok(respuesta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var resp = await clienteRepository.deleteCliente(id);
            var respuesta = new Respuesta<bool>(resp);
            return Ok(respuesta);
          
        }
    }
}

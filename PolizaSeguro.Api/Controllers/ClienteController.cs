using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(clientesDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            var cliente = await clienteRepository.getCliente(id);
            var clienteDto = mapper.Map<ClienteDto>(cliente);

            if (clienteDto == null)
            {
                return BadRequest("Cliente No existe");
            }

            return Ok(clienteDto);
        }

       [HttpPost]
       public async Task<IActionResult> PostCliente(ClienteDto clienteDto)
        {
            var cliente = mapper.Map<Cliente>(clienteDto);
            var resp = await clienteRepository.addCliente(cliente);

            return Ok(resp);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolizaSeguro.Core.DTO;
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

        public ClienteController(IClienteRepository _clienteRepository)
        {
            clienteRepository = _clienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await clienteRepository.getClientes();

            var clientesDto = clientes.Select(x => new ClienteDto
            {
                IdCliente = x.IdCliente,
                Identificacion = x.Identificacion,
                NombresCliente = x.NombresCliente,
                ApellidosCliente = x.ApellidosCliente,
                FechaNacimiento = x.FechaNacimiento,
                Direccion = x.Direccion,
                Telefono = x.Telefono,
                Ciudad = x.Ciudad

            });
            return Ok(clientesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            var cliente = await clienteRepository.getCliente(id);

            var clienteDto = new ClienteDto
            {
                IdCliente = cliente.IdCliente,
                Identificacion = cliente.Identificacion,
                NombresCliente = cliente.NombresCliente,
                ApellidosCliente = cliente.ApellidosCliente,
                FechaNacimiento = cliente.FechaNacimiento,
                Direccion = cliente.Direccion,
                Telefono = cliente.Telefono,
                Ciudad = cliente.Ciudad
            };

            return Ok(clienteDto);
        }
    }
}

using FluentValidation;
using PolizaSeguro.Core.DTO;
using PolizaSeguro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolizaSeguro.Infrastructure.Validators
{
    public class ClienteValidator:AbstractValidator<ClienteDto>
    {
        public ClienteValidator()
        {
            RuleFor(Cliente => Cliente.Identificacion)
                   .NotNull();

            RuleFor(Cliente => Cliente.NombresCliente)
                .NotNull();

            RuleFor(Cliente => Cliente.ApellidosCliente)
                .NotNull();

            RuleFor(Cliente => Cliente.FechaNacimiento)
                .NotNull()
                .LessThan (DateTime.Now);
        }
    }
}

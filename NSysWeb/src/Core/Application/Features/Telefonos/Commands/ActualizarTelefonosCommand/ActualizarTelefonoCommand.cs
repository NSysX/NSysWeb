using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Telefonos.Commands.ActualizarTelefonosCommand
{
    public class ActualizarTelefonoCommand : IRequest<Respuesta<int>>
    {
        public int IdTelefono { get; set; }
        public string Estatus { get; set; }
        public string CodigoPais { get; set; }
        public string TipoTelefono { get; set; }
        public string Numero { get; set; }
    }

    public class ActualizarTelefono_Manejador : IRequestHandler<ActualizarTelefonoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Telefono> _repositorioAsync;
        private readonly IMapper _mapper;

        public ActualizarTelefono_Manejador(IRepositorioAsync<Telefono> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(ActualizarTelefonoCommand request, CancellationToken cancellationToken)
        {
            Telefono telefono = await _repositorioAsync.GetByIdAsync(request.IdTelefono, cancellationToken);
            if (telefono == null)
                throw new KeyNotFoundException($"No se encontro el Registro con el Id = { request.IdTelefono }");

            await _repositorioAsync.DeleteAsync(telefono, cancellationToken);

            return new Respuesta<int>(request.IdTelefono);
        }
    }
}

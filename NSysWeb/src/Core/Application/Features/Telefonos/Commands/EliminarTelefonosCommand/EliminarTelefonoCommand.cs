using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Telefonos.Commands.EliminarTelefonosCommand
{
    public class EliminarTelefonoCommand : IRequest<Respuesta<int>>
    {
        public int IdTelefono { get; set; }
    }

    public class EliminarTelefono_Manejador : IRequestHandler<EliminarTelefonoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Telefono> _repositorioAsync;

        public EliminarTelefono_Manejador(IRepositorioAsync<Telefono> repositorioAsync)
        {
            this._repositorioAsync = repositorioAsync;
        }

        public async Task<Respuesta<int>> Handle(EliminarTelefonoCommand request, CancellationToken cancellationToken)
        {
            // verificamos que exista el registro y usamos el objeto creado para eliminar
            Telefono telefono = await _repositorioAsync.GetByIdAsync(request.IdTelefono, cancellationToken);

            if (telefono == null)
                throw new KeyNotFoundException($"No se encontro el Registro con el Id = { request.IdTelefono }");

            await _repositorioAsync.DeleteAsync(telefono, cancellationToken);

            return new Respuesta<int>(telefono.IdTelefono);
        }
    }
}

using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Personas.Commands.EliminarPersonasCommand
{
    public class EliminarPersonaCommand : IRequest<Respuesta<int>>
    {
        public int IdPersona { get; set; }
    }

    public class EliminarPersona_Manejador : IRequestHandler<EliminarPersonaCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Persona> _repositorioAsync;

        public EliminarPersona_Manejador(IRepositorioAsync<Persona> repositorioAsync)
        {
            this._repositorioAsync = repositorioAsync;
        }
        public async Task<Respuesta<int>> Handle(EliminarPersonaCommand request, CancellationToken cancellationToken)
        {
            Persona persona = await _repositorioAsync.GetByIdAsync(request.IdPersona, cancellationToken);

            if (persona == null)
                throw new KeyNotFoundException($"No se encontro el Registro con el Id = { request.IdPersona }");

            await _repositorioAsync.DeleteAsync(persona, cancellationToken);

            return new Respuesta<int>(request.IdPersona);
        }
    }
}

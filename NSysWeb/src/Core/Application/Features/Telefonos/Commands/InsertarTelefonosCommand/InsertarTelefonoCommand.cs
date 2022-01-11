using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Telefonos.Commands.InsertarTelefonosCommand
{
    public class InsertarTelefonoCommand : IRequest<Respuesta<int>>
    {
        public int IdPersona { get; set; }
        public string Estatus { get; set; }
        public string CodigoPais { get; set; }
        public string TipoTelefono { get; set; }
        public string Numero { get; set; }
    }

    public class InsertarTelefono_Manejador : IRequestHandler<InsertarTelefonoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<PersonaTelefono> _repositorioPersonaTelefono;
        private readonly IRepositorioAsync<Persona> _repositorioAsyncPersona;
        private readonly IMapper _mapper;

        public InsertarTelefono_Manejador(IRepositorioAsync<PersonaTelefono> repositorioPersonaTelefono,
                                          IRepositorioAsync<Persona> repositorioAsyncPersona,
                                          IMapper mapper)
        {
            this._repositorioPersonaTelefono = repositorioPersonaTelefono;
            this._repositorioAsyncPersona = repositorioAsyncPersona;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(InsertarTelefonoCommand request, CancellationToken cancellationToken)
        {
            // Verifico que exista Persona
            var personaExiste = await _repositorioAsyncPersona.GetByIdAsync(request.IdPersona, cancellationToken);
            if (personaExiste == null)
                throw new KeyNotFoundException($"No Existe Persona Id ={ request.IdPersona }");

            PersonaTelefono personaTelefono = new()
            {
                IdPersona = request.IdPersona,
                Telefono = _mapper.Map<Telefono>(request)
            };

            var resultado = await _repositorioPersonaTelefono.AddAsync(personaTelefono,cancellationToken);
            return new Respuesta<int>(resultado.IdTelefono);
        }
    }
}

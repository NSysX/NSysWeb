using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CorreosElectronicos.Commands.InsertarCorreosElectronicosCommand
{
    public class InsertarCorreoElectronicoCommand : IRequest<Respuesta<int>>
    {
        public int IdPersona { get; set; }
        public string Estatus { get; set; }
        public string Correo { get; set; }
        public string TipoCorreo { get; set; }
    }

    public class InsertarCorreoElectronico_Manejador : IRequestHandler<InsertarCorreoElectronicoCommand, Respuesta<int>>
    {
       // private readonly IRepositorioAsync<CorreoElectronico> _repositorioAsync;
        private readonly IRepositorioAsync<PersonaCorreoElectronico> _repositorioPersonaCorreoElectronico;
        private readonly IRepositorioAsync<Persona> _repositorioAsyncPersona;
        private readonly IMapper _mapper;

        public InsertarCorreoElectronico_Manejador(IRepositorioAsync<PersonaCorreoElectronico> repositorioPersonaCorreoElectronico,
            IRepositorioAsync<Persona> repositorioAsyncPersona,
            IMapper mapper)
        {
            this._repositorioPersonaCorreoElectronico = repositorioPersonaCorreoElectronico;
            this._repositorioAsyncPersona = repositorioAsyncPersona;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(InsertarCorreoElectronicoCommand request, CancellationToken cancellationToken)
        {
            // verifico que exista la persona
            var personaExiste = await _repositorioAsyncPersona.GetByIdAsync(request.IdPersona, cancellationToken);
            if (personaExiste == null)
                throw new KeyNotFoundException($"No existe la Persona Id = { request.IdPersona }");

            PersonaCorreoElectronico personaCorreoElectronico = new()
            {
                IdPersona = request.IdPersona,
                CorreoElectronico = _mapper.Map<CorreoElectronico>(request)
            };

            PersonaCorreoElectronico personaCorreoElec = await _repositorioPersonaCorreoElectronico.AddAsync(personaCorreoElectronico, cancellationToken);

            return new Respuesta<int>(personaCorreoElec.IdCorreoElectronico);
        }
    }
}

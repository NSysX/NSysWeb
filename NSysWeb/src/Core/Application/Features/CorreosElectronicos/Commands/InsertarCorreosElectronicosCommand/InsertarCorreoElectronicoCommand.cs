using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
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
        private readonly IMapper _mapper;

        public InsertarCorreoElectronico_Manejador(IRepositorioAsync<PersonaCorreoElectronico> repositorioPersonaCorreoElectronico,
            IMapper mapper)
        {
            this._repositorioPersonaCorreoElectronico = repositorioPersonaCorreoElectronico;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(InsertarCorreoElectronicoCommand request, CancellationToken cancellationToken)
        {
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

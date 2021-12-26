using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Telefonos.Commands.InsertarTelefonosCommand
{
    public class InsertarTelefonoCommand : IRequest<Respuesta<int>>
    {
        public string Estatus { get; set; }
        public string CodigoPais { get; set; }
        public string TipoTelefono { get; set; }
        public string Numero { get; set; }
    }

    public class InsertarTelefono_Manejador : IRequestHandler<InsertarTelefonoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Telefono> _repositorioAsync;
        private readonly IMapper _mapper;

        public InsertarTelefono_Manejador(IRepositorioAsync<Telefono> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(InsertarTelefonoCommand request, CancellationToken cancellationToken)
        {
            Telefono telefono = _mapper.Map<Telefono>(request);
            var resultado = await _repositorioAsync.AddAsync(telefono, cancellationToken);
            return new Respuesta<int>(resultado.IdTelefono);
        }
    }
}

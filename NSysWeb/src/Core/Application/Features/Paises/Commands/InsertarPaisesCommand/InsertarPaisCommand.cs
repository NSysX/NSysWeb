using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Paises.Commands.InsertarPaisesCommand
{
    public class InsertarPaisCommand : IRequest<Respuesta<int>>
    {
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
    }

    public class InsertarPais_Manejador : IRequestHandler<InsertarPaisCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Pais> _repositorioAsync;
        private readonly IMapper _mapper;

        public InsertarPais_Manejador(IRepositorioAsync<Pais> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(InsertarPaisCommand request, CancellationToken cancellationToken)
        {
            Pais pais = _mapper.Map<Pais>(request);
            var respuesta = await _repositorioAsync.AddAsync(pais, cancellationToken);
            return new Respuesta<int>(respuesta.IdPais);
        }
    }
}

using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Municipios.Commands.InsertarMunicipiosCommand
{
    public class InsertarMunicipioCommand : IRequest<Respuesta<int>>
    {
        public int IdEstado { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        public int Clave { get; set; }
        public string Ciudad { get; set; }
    }

    public class InsertarMunicipio_Manejador : IRequestHandler<InsertarMunicipioCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Municipio> _reposiotorioAsync;
        private readonly IRepositorioAsync<Estado> _repositorioEstado;
        private readonly IMapper _mapper;

        public InsertarMunicipio_Manejador(IRepositorioAsync<Municipio> reposiotorioAsync,
                                           IRepositorioAsync<Estado> repositorioEstado, 
                                           IMapper mapper)
        {
            this._reposiotorioAsync = reposiotorioAsync;
            this._repositorioEstado = repositorioEstado;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(InsertarMunicipioCommand request, CancellationToken cancellationToken)
        {
            // Verifico que exista el estado
            var estadoExiste = await _repositorioEstado.GetByIdAsync(request.IdEstado, cancellationToken);
            if (estadoExiste == null)
                throw new KeyNotFoundException($"No existe el Estado con el Id = { request.IdEstado }");

            Municipio municipio = _mapper.Map<Municipio>(request);          
            var respuesta = await _reposiotorioAsync.AddAsync(municipio);
            return new Respuesta<int>(respuesta.IdMunicipio);
        }
    }
}

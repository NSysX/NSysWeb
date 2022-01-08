using Application.DTOs;
using Application.Interfaces;
using Application.Specifications.Paises;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Paises.Queries.PaisesXParametros
{
    public class PaisesXParametrosQuery : IRequest<RespuestaPaginada<List<PaisDTO>>>
    {
        public int NumeroDePagina { get; set; }
        public int RegistrosXPagina { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
    }

    public class PaisesXParametros_Manejador : IRequestHandler<PaisesXParametrosQuery, RespuestaPaginada<List<PaisDTO>>>
    {
        private readonly IRepositorioAsync<Pais> _repositorioAsync;
        private readonly IMapper _mapper;

        public PaisesXParametros_Manejador(IRepositorioAsync<Pais> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<RespuestaPaginada<List<PaisDTO>>> Handle(PaisesXParametrosQuery request, CancellationToken cancellationToken)
        {
            List<Pais> pais = await _repositorioAsync.ListAsync(new PaisesXParametrosSpec(request.NumeroDePagina, request.RegistrosXPagina, request.Nombre, request.Abreviatura), cancellationToken);

            List<PaisDTO> paisDTOs = _mapper.Map<List<PaisDTO>>(pais);

            return new RespuestaPaginada<List<PaisDTO>>(paisDTOs, request.NumeroDePagina, request.RegistrosXPagina);
        }
    }
}

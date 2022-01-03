using Application.DTOs;
using Application.Interfaces;
using Application.Specifications.Municipios;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Municipios.Queries.MunicipiosXParametros
{
    public class MunicipiosXParametrosQuery : IRequest<RespuestaPaginada<List<MunicipioDTO>>>
    {
        public int NumeroDePagina { get; set; }
        public int RegistrosXPagina { get; set; }
        public string Nombre { get; set; }
        public int Clave { get; set; }
    }

    public class MunicipiosXParametros_Manejador : IRequestHandler<MunicipiosXParametrosQuery, RespuestaPaginada<List<MunicipioDTO>>>
    {
        private readonly IRepositorioAsync<Municipio> _repositorioAsync;
        private readonly IMapper _mapper;

        public MunicipiosXParametros_Manejador(IRepositorioAsync<Municipio> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<RespuestaPaginada<List<MunicipioDTO>>> Handle(MunicipiosXParametrosQuery request, CancellationToken cancellationToken)
        {
            List<Municipio> municipio = await _repositorioAsync.ListAsync(new MunicipiosXParametrosSpec(request.NumeroDePagina, request.RegistrosXPagina, request.Nombre, request.Clave),cancellationToken);

            List<MunicipioDTO> municipioDTOs = _mapper.Map<List<MunicipioDTO>>(municipio);

            return new RespuestaPaginada<List<MunicipioDTO>>(municipioDTOs, request.NumeroDePagina, request.RegistrosXPagina);
        }
    }
}
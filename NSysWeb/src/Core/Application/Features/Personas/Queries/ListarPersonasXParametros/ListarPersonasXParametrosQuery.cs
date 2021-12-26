using Application.DTOs;
using Application.Interfaces;
using Application.Specifications.Personas;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Personas.Queries.ListarPersonasXParametros
{
    public class ListarPersonasXParametrosQuery : IRequest<RespuestaPaginada<List<PersonaDTO>>>
    {
        public int NumeroDePagina { get; set; }
        public int RegistrosXPagina { get; set; }
        public string Estatus { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
    }

    public class ListarPersonasXParametros_Manejador : IRequestHandler<ListarPersonasXParametrosQuery, RespuestaPaginada<List<PersonaDTO>>>
    {
        private readonly IRepositorioAsync<Persona> _repositorioAsync;
        private readonly IMapper _mapper;

        public ListarPersonasXParametros_Manejador(IRepositorioAsync<Persona> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<RespuestaPaginada<List<PersonaDTO>>> Handle(ListarPersonasXParametrosQuery request, CancellationToken cancellationToken)
        {
            List<Persona> personas = await _repositorioAsync.ListAsync(new ListarPersonasXParametrosSpec(request.NumeroDePagina, request.RegistrosXPagina, request.Estatus, request.ApellidoPaterno, request.ApellidoMaterno, request.Nombres), cancellationToken);

            List<PersonaDTO> personaDTOs = _mapper.Map<List<PersonaDTO>>(personas);

            return new RespuestaPaginada<List<PersonaDTO>>(personaDTOs, request.NumeroDePagina, request.RegistrosXPagina);
        }
    }
}

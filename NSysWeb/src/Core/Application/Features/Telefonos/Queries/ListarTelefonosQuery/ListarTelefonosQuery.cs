using Application.DTOs;
using Application.Interfaces;
using Application.Specifications.Telefonos;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Telefonos.Queries.ListarTelefonosQuery
{
    public class ListarTelefonosQuery : IRequest<RespuestaPaginada<List<TelefonoDTO>>>
    {
        public int NumeroDePagina { get; set; }
        public int RegistrosXPagina { get; set; }
        public string Estatus { get; set; }
        public string CodigoPais { get; set; }
        public string Numero { get; set; }
    }

    public class ListarTelefonos_Manejador : IRequestHandler<ListarTelefonosQuery, RespuestaPaginada<List<TelefonoDTO>>>
    {
        private readonly IRepositorioAsync<Telefono> _repositorioAsync;
        private readonly IMapper _mapper;

        public ListarTelefonos_Manejador(IRepositorioAsync<Telefono> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<RespuestaPaginada<List<TelefonoDTO>>> Handle(ListarTelefonosQuery request, CancellationToken cancellationToken)
        {
            List<Telefono> telefonos = await _repositorioAsync.ListAsync(new TelefonosPaginadosSpec(request.NumeroDePagina, request.RegistrosXPagina, request.Estatus, request.CodigoPais, request.Numero), cancellationToken);

            List<TelefonoDTO> telefonosDTO = _mapper.Map<List<TelefonoDTO>>(telefonos);

            return new RespuestaPaginada<List<TelefonoDTO>>(telefonosDTO, request.NumeroDePagina, request.RegistrosXPagina);
        }
    }
}

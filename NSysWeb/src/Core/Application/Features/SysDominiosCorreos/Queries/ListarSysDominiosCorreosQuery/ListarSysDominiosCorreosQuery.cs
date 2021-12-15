using Application.DTOs;
using Application.Interfaces;
using Application.Specifications.SysDominiosCorreos;
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

namespace Application.Features.SysDominiosCorreos.Queries.ListarSysDominiosCorreosQuery
{
    public class ListarSysDominiosCorreosQuery : IRequest<RespuestaPaginada<List<SysDominioCorreoDTO>>>
    {
        public int NumeroPagina { get; set; }
        public int RegistrosXPagina { get; set; }
        public string Estatus { get; set; }
        public string Dominio { get; set; }
    }

    public class ListarSysDominioCorreo_Manejador : IRequestHandler<ListarSysDominiosCorreosQuery, RespuestaPaginada<List<SysDominioCorreoDTO>>>
    {
        private readonly IRepositorioAsync<SysDominioCorreo> _repositorioAsync;
        private readonly IMapper _mapper;

        public ListarSysDominioCorreo_Manejador(IRepositorioAsync<SysDominioCorreo> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<RespuestaPaginada<List<SysDominioCorreoDTO>>> Handle(ListarSysDominiosCorreosQuery request, CancellationToken cancellationToken)
        {
            List<SysDominioCorreo> sysDominiosCorreos = await _repositorioAsync.ListAsync(new SysDominiosCorreosPaginadosSpec(request.RegistrosXPagina, request.NumeroPagina, request.Estatus, request.Dominio), cancellationToken);

            List<SysDominioCorreoDTO> sysDominioCorreoDTOs = _mapper.Map<List<SysDominioCorreoDTO>>(sysDominiosCorreos);

            return new RespuestaPaginada<List<SysDominioCorreoDTO>>(sysDominioCorreoDTOs, request.NumeroPagina, request.RegistrosXPagina);
        }
    }
}

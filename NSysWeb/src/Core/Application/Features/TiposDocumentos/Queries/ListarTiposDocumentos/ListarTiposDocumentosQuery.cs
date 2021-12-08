using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
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

namespace Application.Features.TiposDocumentos.Queries.ListarTiposDocumentos
{
    // esta clase crea el objeto que vamos a mandar desde el httpget
    public class ListarTiposDocumentosQuery : IRequest<RespuestaPaginada<List<TipoDocumentoDTO>>>
    {
        public int NumeroPagina { get; set; }
        public int RegistrosXPagina { get; set; }
        public string Nombre { get; set; }
        public string Abreviacion { get; set; }
        public string Estatus { get; set; }
    }

    // luego creamos el manejador
    public class ListarTiposDocumentos_Manejador : IRequestHandler<ListarTiposDocumentosQuery, RespuestaPaginada<List<TipoDocumentoDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioAsync<DocumentoTipo> _repositorioAsync;

        public ListarTiposDocumentos_Manejador(IRepositorioAsync<DocumentoTipo> repositorioAsync, IMapper mapper) 
        {
            this._mapper = mapper;
            this._repositorioAsync = repositorioAsync;
        }

        // interfaz de Mediatr
        public async Task<RespuestaPaginada<List<TipoDocumentoDTO>>> Handle(ListarTiposDocumentosQuery request, CancellationToken cancellationToken)
        {
            var tiposDocumentos = await _repositorioAsync.ListAsync(new TiposDocumentosPaginadosSpec(request.RegistrosXPagina, request.NumeroPagina, request.Nombre , request.Abreviacion, request.Estatus));

            var tiposDocumentosDTOs = _mapper.Map<List<TipoDocumentoDTO>>(tiposDocumentos);

            return new RespuestaPaginada<List<TipoDocumentoDTO>>(tiposDocumentosDTOs, request.NumeroPagina, request.RegistrosXPagina);
        }
    }
}

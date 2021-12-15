using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DocumentosTipos.Queries.ListarDocumentosTipos
{
    // esta clase crea el objeto que vamos a mandar desde el httpget
    public class ListarDocumentosTiposQuery : IRequest<RespuestaPaginada<List<DocumentoTipoDTO>>>
    {
        public int NumeroPagina { get; set; }
        public int RegistrosXPagina { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        public string Estatus { get; set; }
    }

    // luego creamos el manejador
    public class ListarDocumentosTipos_Manejador : IRequestHandler<ListarDocumentosTiposQuery, RespuestaPaginada<List<DocumentoTipoDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioAsync<DocumentoTipo> _repositorioAsync;

        public ListarDocumentosTipos_Manejador(IRepositorioAsync<DocumentoTipo> repositorioAsync, IMapper mapper) 
        {
            this._mapper = mapper;
            this._repositorioAsync = repositorioAsync;
        }

        // interfaz de Mediatr
        public async Task<RespuestaPaginada<List<DocumentoTipoDTO>>> Handle(ListarDocumentosTiposQuery request, CancellationToken cancellationToken)
        {
            var documentosTipos = await _repositorioAsync.ListAsync(new DocumentosTiposPaginadosSpec(request.RegistrosXPagina, request.NumeroPagina, request.Nombre , request.Abreviatura, request.Estatus));

            var documentosTiposDTOs = _mapper.Map<List<DocumentoTipoDTO>>(documentosTipos);

            return new RespuestaPaginada<List<DocumentoTipoDTO>>(documentosTiposDTOs, request.NumeroPagina, request.RegistrosXPagina);
        }
    }
}

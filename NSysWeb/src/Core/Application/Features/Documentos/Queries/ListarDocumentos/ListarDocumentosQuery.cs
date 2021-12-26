using Application.DTOs;
using Application.Interfaces;
using Application.Specifications.Documentos;
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

namespace Application.Features.Documentos.Queries.ListarDocumentos
{
    public class ListarDocumentosQuery : IRequest<RespuestaPaginada<List<DocumentoDTO>>>
    {
        public int NumeroDePagina { get; set; }
        public int RegistrosXPagina { get; set; }
        public string Estatus { get; set; }
        public string CodigoUnico { get; set; }
        public string Imagen { get; set; }
        public int IdDocumentoTipo { get; set; }
    }

    public class ListarDocumento_Manejador : IRequestHandler<ListarDocumentosQuery, RespuestaPaginada<List<DocumentoDTO>>>
    {
        private readonly IRepositorioAsync<Documento> _repositorioAsync;
        private readonly IMapper _mapper;

        public ListarDocumento_Manejador(IRepositorioAsync<Documento> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<RespuestaPaginada<List<DocumentoDTO>>> Handle(ListarDocumentosQuery request, CancellationToken cancellationToken)
        {
            List<Documento> documentos = await _repositorioAsync.ListAsync(new ListarDocumentosXParametrosSpec(request.NumeroDePagina, request.RegistrosXPagina, request.Estatus, request.CodigoUnico), cancellationToken);

            List<DocumentoDTO> documentoDTO = _mapper.Map<List<DocumentoDTO>>(documentos);

            return new RespuestaPaginada<List<DocumentoDTO>>(documentoDTO, request.NumeroDePagina, request.RegistrosXPagina);
        }
    }
}

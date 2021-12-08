using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TiposDocumentos.Queries.ObtenerXIdTipoDocumento
{
    public class ObtenerXIdTipoDocumentoQuery : IRequest<Respuesta<TipoDocumentoDTO>>
    {
        public int IdTipoDocumento { get; set; }
    }

    public class ObtenerXIdTipoDocumento_Manejador : IRequestHandler<ObtenerXIdTipoDocumentoQuery, Respuesta<TipoDocumentoDTO>>
    {
        private readonly IRepositorioAsync<DocumentoTipo> _repositorioAsync;
        private readonly IMapper _mapper;

        public ObtenerXIdTipoDocumento_Manejador(IRepositorioAsync<DocumentoTipo> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<TipoDocumentoDTO>> Handle(ObtenerXIdTipoDocumentoQuery request, CancellationToken cancellationToken)
        {
            DocumentoTipo tipoDocumento = await _repositorioAsync.GetByIdAsync(request.IdTipoDocumento);

            if (tipoDocumento == null)
                throw new KeyNotFoundException($"No se Encontro el registro con el Id = {request.IdTipoDocumento}");

            TipoDocumentoDTO tipoDocumentoDTO = _mapper.Map<TipoDocumentoDTO>(tipoDocumento);

            return new Respuesta<TipoDocumentoDTO>(tipoDocumentoDTO);
        }
    }

}

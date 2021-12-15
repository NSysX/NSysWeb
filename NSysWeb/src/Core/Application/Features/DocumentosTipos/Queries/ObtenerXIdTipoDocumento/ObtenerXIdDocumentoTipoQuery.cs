using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DocumentosTipos.Queries.ObtenerXIdDocumentoTipo
{
    public class ObtenerXIdDocumentoTipoQuery : IRequest<Respuesta<DocumentoTipoDTO>>
    {
        public int IdDocumentoTipo { get; set; }
    }

    public class ObtenerXIdDocumentoTipo_Manejador : IRequestHandler<ObtenerXIdDocumentoTipoQuery, Respuesta<DocumentoTipoDTO>>
    {
        private readonly IRepositorioAsync<DocumentoTipo> _repositorioAsync;
        private readonly IMapper _mapper;

        public ObtenerXIdDocumentoTipo_Manejador(IRepositorioAsync<DocumentoTipo> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<DocumentoTipoDTO>> Handle(ObtenerXIdDocumentoTipoQuery request, CancellationToken cancellationToken)
        {
            DocumentoTipo documentoTipo = await _repositorioAsync.GetByIdAsync(request.IdDocumentoTipo);

            if (documentoTipo == null)
                throw new KeyNotFoundException($"No se Encontro el registro con el Id = {request.IdDocumentoTipo}");

            DocumentoTipoDTO documentoTipoDTO = _mapper.Map<DocumentoTipoDTO>(documentoTipo);

            return new Respuesta<DocumentoTipoDTO>(documentoTipoDTO);
        }
    }
}

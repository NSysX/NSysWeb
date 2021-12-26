using Application.DTOs;
using Application.Interfaces;
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

namespace Application.Features.Documentos.Queries.ObtenerXIdDocumento
{
    public class ObtenerXIdDocumentoQuery : IRequest<Respuesta<DocumentoDTO>>
    {
        public int IdDocumento { get; set; }
    }

    public class ObtenerXIdDocumento_Manejador : IRequestHandler<ObtenerXIdDocumentoQuery, Respuesta<DocumentoDTO>>
    {
        private readonly IRepositorioAsync<Documento> _repositorioAsync;
        private readonly IMapper _mapper;

        public ObtenerXIdDocumento_Manejador(IRepositorioAsync<Documento> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }
        public async Task<Respuesta<DocumentoDTO>> Handle(ObtenerXIdDocumentoQuery request, CancellationToken cancellationToken)
        {
            Documento documento = await _repositorioAsync.GetByIdAsync(request.IdDocumento, cancellationToken);

            if (documento == null)
                throw new KeyNotFoundException($"No se encontro el Registro con el Id = { request.IdDocumento }");

            DocumentoDTO documentoDTO = _mapper.Map<DocumentoDTO>(documento);

            return new Respuesta<DocumentoDTO>(documentoDTO);
        }
    }
}

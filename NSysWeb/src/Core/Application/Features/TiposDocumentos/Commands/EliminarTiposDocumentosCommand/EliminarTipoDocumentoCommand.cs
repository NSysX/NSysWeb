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

namespace Application.Features.TiposDocumentos.Commands.EliminarTiposDocumentosCommand
{
    public class EliminarTipoDocumentoCommand : IRequest<Respuesta<int>>
    {
        public int IdTipoDocumento { get; set; }
    }

    public class EliminarTipoDocumentoCommand_Handler : IRequestHandler<EliminarTipoDocumentoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<DocumentoTipo> _repositorioAsync;
        private readonly IMapper _mapper;

        public EliminarTipoDocumentoCommand_Handler(IRepositorioAsync<DocumentoTipo> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(EliminarTipoDocumentoCommand request, CancellationToken cancellationToken)
        {
            DocumentoTipo tipoDocumento = await _repositorioAsync.GetByIdAsync(request.IdTipoDocumento, cancellationToken);

            if (tipoDocumento == null)
                throw new KeyNotFoundException($"Registro no Encontrado con el Id = {request.IdTipoDocumento}");

            await _repositorioAsync.DeleteAsync(tipoDocumento);
            return new Respuesta<int>(tipoDocumento.IdTipoDocumento);
        }
    }
}

using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DocumentosTipos.Commands.EliminarDocumentosTiposCommand
{
    public class EliminarDocumentoTipoCommand : IRequest<Respuesta<int>>
    {
        public int IdDocumentoTipo { get; set; }
    }

    public class EliminarDocumentoTipoCommand_Handler : IRequestHandler<EliminarDocumentoTipoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<DocumentoTipo> _repositorioAsync;
        private readonly IMapper _mapper;

        public EliminarDocumentoTipoCommand_Handler(IRepositorioAsync<DocumentoTipo> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(EliminarDocumentoTipoCommand request, CancellationToken cancellationToken)
        {
            DocumentoTipo documentoTipo = await _repositorioAsync.GetByIdAsync(request.IdDocumentoTipo, cancellationToken);

            if (documentoTipo == null)
                throw new KeyNotFoundException($"Registro no Encontrado con el Id = {request.IdDocumentoTipo}");

            await _repositorioAsync.DeleteAsync(documentoTipo);
            return new Respuesta<int>(documentoTipo.IdDocumentoTipo);
        }
    }
}

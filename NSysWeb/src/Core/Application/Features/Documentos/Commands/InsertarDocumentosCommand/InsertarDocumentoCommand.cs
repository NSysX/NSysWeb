using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Documentos.Commands.InsertarDocumentosCommand
{
    public class InsertarDocumentoCommand : IRequest<Respuesta<int>>
    {
        public int IdDocumentoTipo { get; set; }
        public string Estatus { get; set; }
        public string CodigoUnico { get; set; }
        public string Imagen { get; set; }
    }

    public class InsertarDocumentosCommand_Manejador : IRequestHandler<InsertarDocumentoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Documento> _repositoryAsync;
        private readonly IMapper _mapper;

        public InsertarDocumentosCommand_Manejador(IRepositorioAsync<Documento> repositoryAsync, IMapper mapper)
        {
            this._repositoryAsync = repositoryAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(InsertarDocumentoCommand request, CancellationToken cancellationToken)
        {
            Documento documento = _mapper.Map<Documento>(request);
            
            var data = await _repositoryAsync.AddAsync(documento, cancellationToken);
            return new Respuesta<int>(data.IdDocumento);
        }
    }
}
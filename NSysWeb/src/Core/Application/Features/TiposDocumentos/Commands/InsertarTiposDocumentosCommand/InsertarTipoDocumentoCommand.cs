using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TiposDocumentos.Commands.InsertarTiposDocumentosCommand
{
    // la clase para enviarla desde el controlador
    public class InsertarTipoDocumentoCommand : IRequest<Respuesta<int>>
    {
        // los datos a insertar
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviacion { get; set; }
        public int Longitud { get; set; }
    }

    // manejador
    public class InsertarTipoDocumentosCommand_Manejador : IRequestHandler<InsertarTipoDocumentoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<DocumentoTipo> _repositorioAsync;
        private readonly IMapper _mapper;

        public InsertarTipoDocumentosCommand_Manejador(IRepositorioAsync<DocumentoTipo> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(InsertarTipoDocumentoCommand request, CancellationToken cancellationToken)
        {
            DocumentoTipo nuevoTipoDocumento = _mapper.Map<DocumentoTipo>(request);
            var data = await _repositorioAsync.AddAsync(nuevoTipoDocumento, cancellationToken);
            return new Respuesta<int>(data.IdTipoDocumento);
        }
    }

}

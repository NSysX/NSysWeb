using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DocumentosTipos.Commands.InsertarDocumentosTiposCommand
{
    // la clase para enviarla desde el controlador
    public class InsertarDocumentoTipoCommand : IRequest<Respuesta<int>>
    {
        // los datos a insertar
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        public int LongitudMax { get; set; }
    }

    // manejador
    public class InsertarDocumentoTipoCommand_Manejador : IRequestHandler<InsertarDocumentoTipoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<DocumentoTipo> _repositorioAsync;
        private readonly IMapper _mapper;

        public InsertarDocumentoTipoCommand_Manejador(IRepositorioAsync<DocumentoTipo> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(InsertarDocumentoTipoCommand request, CancellationToken cancellationToken)
        {
            DocumentoTipo nuevoDocumentoTipo = _mapper.Map<DocumentoTipo>(request);
            var data = await _repositorioAsync.AddAsync(nuevoDocumentoTipo, cancellationToken);
            return new Respuesta<int>(data.IdDocumentoTipo);
        }
    }

}

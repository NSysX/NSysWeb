using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TiposDocumentos.Commands.ActualizarTiposDocumentosCommand
{
    public class ActualizarTipoDocumentoCommand : IRequest<Respuesta<int>>
    {
        public int IdTipoDocumento { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviacion { get; set; }
        public int Longitud { get; set; }
    }

    public class ActualizarTipoDocumentoCommand_Manejador : IRequestHandler<ActualizarTipoDocumentoCommand, Respuesta<int>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioAsync<DocumentoTipo> _RepositorioAsync;

        public ActualizarTipoDocumentoCommand_Manejador(IRepositorioAsync<DocumentoTipo> repositorioAsync, IMapper mapper)
        {
            this._mapper = mapper;
            this._RepositorioAsync = repositorioAsync;
        }

        public async Task<Respuesta<int>> Handle(ActualizarTipoDocumentoCommand request, CancellationToken cancellationToken)
        {
            DocumentoTipo tipoDocumento = await _RepositorioAsync.GetByIdAsync(request.IdTipoDocumento);

            if (tipoDocumento == null)
                throw new KeyNotFoundException($"No existe el registro con el Id = {request.IdTipoDocumento}");

            tipoDocumento.Estatus = request.Estatus.Trim();
            tipoDocumento.Nombre = request.Nombre.Trim();
            tipoDocumento.Abreviacion = request.Abreviacion.Trim();
            tipoDocumento.Longitud = request.Longitud;

            await _RepositorioAsync.UpdateAsync(tipoDocumento);
            // puedes devolver todod el objeto borrado
            return new Respuesta<int>(tipoDocumento.IdTipoDocumento);
        }
    }
}

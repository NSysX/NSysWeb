using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DocumentosTipos.Commands.ActualizarDocumentosTiposCommand
{
    public class ActualizarDocumentoTipoCommand : IRequest<Respuesta<int>>
    {
        public int IdDocumentoTipo { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        public int LongitudMax { get; set; }
    }

    public class ActualizarDocumentoTipoCommand_Manejador : IRequestHandler<ActualizarDocumentoTipoCommand, Respuesta<int>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioAsync<DocumentoTipo> _RepositorioAsync;

        public ActualizarDocumentoTipoCommand_Manejador(IRepositorioAsync<DocumentoTipo> repositorioAsync, IMapper mapper)
        {
            this._mapper = mapper;
            this._RepositorioAsync = repositorioAsync;
        }

        public async Task<Respuesta<int>> Handle(ActualizarDocumentoTipoCommand request, CancellationToken cancellationToken)
        {
            DocumentoTipo documentoTipo = await _RepositorioAsync.GetByIdAsync(request.IdDocumentoTipo);

            if (documentoTipo == null)
                throw new KeyNotFoundException($"No existe el registro con el Id = { request.IdDocumentoTipo }");

            documentoTipo.Estatus = request.Estatus.Trim();
            documentoTipo.Nombre = request.Nombre.Trim();
            documentoTipo.Abreviatura = request.Abreviatura.Trim();
            documentoTipo.LongitudMax = request.LongitudMax;

            await _RepositorioAsync.UpdateAsync(documentoTipo);
            // puedes devolver todod el objeto borrado
            return new Respuesta<int>(documentoTipo.IdDocumentoTipo);
        }
    }
}

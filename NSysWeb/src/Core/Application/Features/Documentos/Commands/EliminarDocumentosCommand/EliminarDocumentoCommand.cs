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

namespace Application.Features.Documentos.Commands.EliminarDocumentosCommand
{
    public class EliminarDocumentoCommand : IRequest<Respuesta<int>>
    {
        public int IdDocumento { get; set; }
    }

    public class EliminarDocumento_Manejador : IRequestHandler<EliminarDocumentoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Documento> _repositorioAsync;
        private readonly IMapper _mapper;

        public EliminarDocumento_Manejador(IRepositorioAsync<Documento> repositorioAsync,
                                           IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(EliminarDocumentoCommand request, CancellationToken cancellationToken)
        {
            Documento existe = await _repositorioAsync.GetByIdAsync(request.IdDocumento);

            if (existe == null)
                throw new KeyNotFoundException($"No existe el Registro con el Id = {request.IdDocumento}");

            await _repositorioAsync.DeleteAsync(existe);

            return new Respuesta<int>(request.IdDocumento);
        }
    }
}

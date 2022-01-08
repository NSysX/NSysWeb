using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Application.Features.Documentos.Commands.InsertarDocumentosCommand
{
    public class InsertarDocumentoCommand : IRequest<Respuesta<int>>
    {
        public int IdPersona { get; set; }
        public int IdDocumentoTipo { get; set; }
        public string Estatus { get; set; }
        public string CodigoUnico { get; set; }
        public string Foto { get; set; }
    }

    public class InsertarDocumentosCommand_Manejador : IRequestHandler<InsertarDocumentoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<PersonaDocumento> _repositorioPersonaDocto;

        // private readonly IRepositorioAsync<Documento> _repositoryAsync;

        private readonly IRepositorioAsync<DocumentoTipo> _repositorioDocumentoTipo;
        private readonly IMapper _mapper;

        //IRepositorioAsync<Documento> repositoryAsync, 
        public InsertarDocumentosCommand_Manejador(IRepositorioAsync<PersonaDocumento> repositorioPersonaDocto,
                                                   IRepositorioAsync<DocumentoTipo> repositorioDocumentoTipo,
                                                   IMapper mapper)
        {
            this._repositorioPersonaDocto = repositorioPersonaDocto;
            //this._repositoryAsync = repositoryAsync;
            this._repositorioDocumentoTipo = repositorioDocumentoTipo;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(InsertarDocumentoCommand request, CancellationToken cancellationToken)
        {
            // Verifico que exista el Documento Tipo
            var documentoTipoExiste = await _repositorioDocumentoTipo.GetByIdAsync(request.IdDocumentoTipo, cancellationToken);

            if (documentoTipoExiste == null)
                throw new KeyNotFoundException($"No se Encontro el Documento Tipo con el Id = { request.IdDocumentoTipo }");

            if (request.CodigoUnico.Length > documentoTipoExiste.Longitud)
                throw new ArgumentOutOfRangeException(nameof(InsertarDocumentoCommand.CodigoUnico), $"La longitud debe tener un maximo de { documentoTipoExiste.Longitud }");

            PersonaDocumento personaDocumento = new()
            {
                IdPersona = request.IdPersona,
                Documento = _mapper.Map<Documento>(request)
            };

            PersonaDocumento personaDocto = await _repositorioPersonaDocto.AddAsync(personaDocumento);
            return new Respuesta<int>(personaDocto.IdDocumento);
        }
    }
}
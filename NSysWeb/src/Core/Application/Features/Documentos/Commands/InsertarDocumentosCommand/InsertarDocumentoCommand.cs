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
        private readonly IRepositorioAsync<PersonaDocumento> _repositorioAsyncPersonaDocto;
        private readonly IRepositorioAsync<DocumentoTipo> _repositorioAsyncDocumentoTipo;
        private readonly IRepositorioAsync<Persona> _repositorioAsyncPersona;
        private readonly IMapper _mapper;

        public InsertarDocumentosCommand_Manejador(IRepositorioAsync<PersonaDocumento> repositorioAsyncPersonaDocto,
                                                   IRepositorioAsync<DocumentoTipo> repositorioAsyncDocumentoTipo,
                                                   IRepositorioAsync<Persona> repositorioAsyncPersona,
                                                   IMapper mapper)
        {
            this._repositorioAsyncPersonaDocto = repositorioAsyncPersonaDocto;
            this._repositorioAsyncDocumentoTipo = repositorioAsyncDocumentoTipo;
            this._repositorioAsyncPersona = repositorioAsyncPersona;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(InsertarDocumentoCommand request, CancellationToken cancellationToken)
        {
            // Verifico que exista la persona
            var personaExiste = await _repositorioAsyncPersona.GetByIdAsync(request.IdPersona, cancellationToken);
            if (personaExiste == null)
                throw new KeyNotFoundException($"No Existe Persona id = { request.IdPersona }");

            // Verifico que exista el Documento Tipo
            var documentoTipoExiste = await _repositorioAsyncDocumentoTipo.GetByIdAsync(request.IdDocumentoTipo, cancellationToken);

            if (documentoTipoExiste == null)
                throw new KeyNotFoundException($"No se Encontro el Documento Tipo con el Id = { request.IdDocumentoTipo }");

            if (request.CodigoUnico.Length > documentoTipoExiste.LongitudMax)
                throw new ArgumentOutOfRangeException(nameof(InsertarDocumentoCommand.CodigoUnico), $"La longitud debe tener un maximo de { documentoTipoExiste.LongitudMax }");

            PersonaDocumento personaDocumento = new()
            {
                IdPersona = request.IdPersona,
                Documento = _mapper.Map<Documento>(request)
            };

            PersonaDocumento personaDocto = await _repositorioAsyncPersonaDocto.AddAsync(personaDocumento);
            return new Respuesta<int>(personaDocto.IdDocumento);
        }
    }
}
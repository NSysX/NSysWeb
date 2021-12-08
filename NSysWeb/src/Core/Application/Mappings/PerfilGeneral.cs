using Application.DTOs;
using Application.Features.Documentos.Commands.InsertarDocumentosCommand;
using Application.Features.EstadosCiviles.Commands.InsertarEstadosCivilesCommand;
using Application.Features.Nacionalidades.Commands;
using Application.Features.Personas.Commands.InsertarPersonasCommand;
using Application.Features.TiposDocumentos.Commands.InsertarTiposDocumentosCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class PerfilGeneral : Profile
    {
        public PerfilGeneral()
        {
            // vamos a ir agrupando todos los mapeos de comandos
            #region MapeoEstadoCivil
            CreateMap<InsertarEstadoCivilCommand, EstadoCivil>();
            CreateMap<EstadoCivil, EstadoCivilDTO>().ReverseMap();
            //CreateMap<ActualizarEstadoCivilCommand, EstadoCivil>();
            #endregion

            #region MapeoTipoDocumento
            CreateMap<InsertarTipoDocumentoCommand, DocumentoTipo>().ReverseMap();
            CreateMap<DocumentoTipo, TipoDocumentoDTO>().ReverseMap();
            #endregion

            #region Documento
            CreateMap<InsertarDocumentoCommand, Documento>().ReverseMap();
            #endregion

            #region Persona
            CreateMap<InsertarPersonaCommand, Persona>().ReverseMap();
            #endregion

            #region Nacionalidad
            CreateMap<InsertaNacionalidadCommand, Nacionalidad>().ReverseMap();
            CreateMap<Nacionalidad, NacionalidadDTO>().ReverseMap();
            #endregion
        }
    }
}

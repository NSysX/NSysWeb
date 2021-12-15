using Application.DTOs;
using Application.Features.Documentos.Commands.InsertarDocumentosCommand;
using Application.Features.EstadosCiviles.Commands.InsertarEstadosCivilesCommand;
using Application.Features.Nacionalidades.Commands;
using Application.Features.Personas.Commands.InsertarPersonasCommand;
using Application.Features.DocumentosTipos.Commands.InsertarDocumentosTiposCommand;
using AutoMapper;
using Domain.Entities;
using Application.Features.Estados.Commands;
using Application.Features.AsentamientosTipos.Commands.InsertarAsentamientosTipos;
using Application.Features.AsentamientosTipos.Commands.ActualizaAsentamientosTipos;
using Application.Features.SysDominiosCorreos.Commands.InsertarSysDominiosCorreosCommand;

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

            #region DocumentoTipo
            CreateMap<InsertarDocumentoTipoCommand, DocumentoTipo>().ReverseMap();
            CreateMap<DocumentoTipo, DocumentoTipoDTO>().ReverseMap();
            #endregion

            #region Documento
            CreateMap<InsertarDocumentoCommand, Documento>().ReverseMap();
            #endregion

            #region Persona
            CreateMap<InsertarPersonaCommand, Persona>().ReverseMap();
            #endregion

            #region Nacionalidad
            CreateMap<InsertarNacionalidadCommand, Nacionalidad>().ReverseMap();
            CreateMap<Nacionalidad, NacionalidadDTO>().ReverseMap();
            #endregion

            #region Estado
            CreateMap<InsertarEstadoCommand, Estado>().ReverseMap();
            CreateMap<EstadoDTO, Estado>().ReverseMap();
            #endregion

            #region AsentamientoTipo
            CreateMap<InsertarAsentamientoTipoCommand, AsentamientoTipo>().ReverseMap();
            CreateMap<AsentamientoTipo, AsentamientoTipoDTO>().ReverseMap();
            #endregion

            #region SysDominioCorreo
            CreateMap<InsertarSysDominioCorreoCommand, SysDominioCorreo>().ReverseMap();
            #endregion

            #region SysDominioCorreo
            CreateMap<InsertarSysDominioCorreoCommand, SysDominioCorreo>().ReverseMap();
            CreateMap<SysDominioCorreo, SysDominioCorreoDTO>().ReverseMap();
            #endregion
        }
    }
}

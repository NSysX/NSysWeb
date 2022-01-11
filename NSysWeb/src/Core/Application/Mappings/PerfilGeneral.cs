using Application.DTOs;
using Application.Features.Asentamientos.Commands.InsertarAsentamientosCommand;
using Application.Features.AsentamientosTipos.Commands.InsertarAsentamientosTipos;
using Application.Features.CorreosElectronicos.Commands.InsertarCorreosElectronicosCommand;
using Application.Features.Direcciones.Commands.ActualizarDireccionesCommand;
using Application.Features.Direcciones.Commands.InsertarDireccionesCommand;
using Application.Features.Documentos.Commands.InsertarDocumentosCommand;
using Application.Features.DocumentosTipos.Commands.InsertarDocumentosTiposCommand;
using Application.Features.Estados.Commands;
using Application.Features.EstadosCiviles.Commands.InsertarEstadosCivilesCommand;
using Application.Features.Municipios.Commands.InsertarMunicipiosCommand;
using Application.Features.Nacionalidades.Commands;
using Application.Features.Paises.Commands.InsertarPaisesCommand;
using Application.Features.Personas.Commands.InsertarPersonasCommand;
using Application.Features.SysDominiosCorreos.Commands.InsertarSysDominiosCorreosCommand;
using Application.Features.Telefonos.Commands.InsertarTelefonosCommand;
using AutoMapper;
using Domain.Entities;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace Application.Mappings
{
    public class PerfilGeneral : Profile
    {
        public PerfilGeneral()
        {
            // vamos a ir agrupando todos los mapeos de comandos
            #region Asentamiento
            CreateMap<InsertarAsentamientoCommand, Asentamiento>();
            CreateMap<Asentamiento, AsentamientoDTO>();
            #endregion

            #region EstadoCivil
            CreateMap<InsertarEstadoCivilCommand, EstadoCivil>();
            CreateMap<EstadoCivil, EstadoCivilDTO>().ReverseMap();
            //CreateMap<ActualizarEstadoCivilCommand, EstadoCivil>();
            #endregion

            #region Direccion

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            CreateMap<InsertarDireccionCommand, Direccion>()
                .ForMember(dest => dest.CoordenadasGeo, opt => opt.MapFrom(src => 
                          geometryFactory.CreatePoint(new Coordinate(src.Longitud, src.Latitud))));

            CreateMap<ActualizarDireccionCommand, Direccion>()
                .ForMember(dest => dest.CoordenadasGeo, opt => opt.MapFrom(src =>
                          geometryFactory.CreatePoint(new Coordinate(src.Longitud, src.Latitud))));

            CreateMap<Direccion, DireccionDTO>()
                .ForMember(dest => dest.Longitud, opt => opt.MapFrom(src => src.CoordenadasGeo.X))
                .ForMember(dest => dest.Latitud, opt => opt.MapFrom(src => src.CoordenadasGeo.Y));

            #endregion

            #region DocumentoTipo
            CreateMap<InsertarDocumentoTipoCommand, DocumentoTipo>().ReverseMap();
            CreateMap<DocumentoTipo, DocumentoTipoDTO>().ReverseMap();
            #endregion

            #region Documento
            CreateMap<InsertarDocumentoCommand, Documento>().ReverseMap();
            CreateMap<Documento, DocumentoDTO>();
               //.ForMember(dest => dest.DocumentoTipoDto,opt => opt.MapFrom(src => src.IdDocumentoTipoNavigation));
            #endregion

            #region Persona
            CreateMap<InsertarPersonaCommand, Persona>().ReverseMap();
            CreateMap<PersonaDocumentoDTO, PersonaDocumento>().ReverseMap();
            CreateMap<PersonaTelefono, PersonaTelefonoDTO>().ReverseMap();
            CreateMap<PersonaCorreoElectronico, PersonaCorreoElectronicoDTO>().ReverseMap();
            CreateMap<PersonaDireccion, PersonaDireccionDTO>().ReverseMap();
            CreateMap<Persona, PersonaDTO>();
            //CreateMap<DocumentoDTO, Documento>().ReverseMap();
            //.ForMember(dest => dest.EstadoCivil, opt => opt.MapFrom(src => src.IdEstadoCivilNavigation))
            //.ForMember(dest => dest.Nacionalidad, opt => opt.MapFrom(src => src.IdNacionalidadNavigation))
            //.ForMember(personaDTO => personaDTO.PersonaDocumentos, opt => opt.MapFrom(persona => persona.PersonaDocumentos));
            //.ForMember(personaDTO => personaDTO.Documentos, opt => opt.MapFrom(persona => persona.Documentos));
            #endregion

            #region Pais
            CreateMap<InsertarPaisCommand, Pais>();
            CreateMap<Pais, PaisDTO>();
            #endregion

            #region Nacionalidad
            CreateMap<InsertarNacionalidadCommand, Nacionalidad>().ReverseMap();
            CreateMap<Nacionalidad, NacionalidadDTO>().ReverseMap();
            #endregion

            #region Municipio
            CreateMap<InsertarMunicipioCommand, Municipio>().ReverseMap();
            CreateMap<MunicipioDTO, Municipio>().ReverseMap();
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
            CreateMap<SysDominioCorreo, SysDominioCorreoDTO>().ReverseMap();
            #endregion

            #region Telefono
            CreateMap<InsertarTelefonoCommand, Telefono>().ReverseMap();
            CreateMap<TelefonoDTO, Telefono>().ReverseMap();
            #endregion

            #region CorreoElectronico
            CreateMap<InsertarCorreoElectronicoCommand, CorreoElectronico>().ReverseMap();
            CreateMap<CorreoElectronicoDTO, CorreoElectronico>().ReverseMap();
            #endregion

        }
    }
}

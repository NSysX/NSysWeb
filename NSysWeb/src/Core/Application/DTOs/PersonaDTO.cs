using System;
using System.Collections.Generic;

namespace Application.DTOs
{
    public class PersonaDTO
    {
        public int IdPersona { get; set; }
        public int IdNacionalidad { get; set; }
        public int IdEstadoCivil { get; set; }
        public string Estatus { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Foto { get; set; }
        public string Notas { get; set; }

        public EstadoCivilDTO EstadoCivil { get; set; }
        public NacionalidadDTO Nacionalidad { get; set; }
        public List<PersonaDocumentoDTO> PersonaDocumentos { get; set; }
        public List<PersonaTelefonoDTO> PersonaTelefonos { get; set; }
        public List<PersonaCorreoElectronicoDTO> PersonaCorreosElectronicos { get; set; }
    }
}

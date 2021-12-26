using Domain.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Persona : EntidadBaseAuditable
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

        public virtual EstadoCivil EstadoCivil { get; set; }
        public virtual Nacionalidad Nacionalidad { get; set; }
        public List<PersonaDocumento> PersonaDocumentos { get; set; }
        public List<PersonaTelefono> PersonaTelefonos { get; set; }
        public List<PersonaCorreoElectronico> PersonaCorreosElectronicos { get; set; }
    }
}

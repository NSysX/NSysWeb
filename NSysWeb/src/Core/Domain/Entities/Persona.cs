using Domain.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class Persona : EntidadBaseAuditable
    {
        public Persona()
        {
            PersonaCorreoElectronicos = new HashSet<PersonaCorreoElectronico>();
            PersonaDireccions = new HashSet<PersonaDireccion>();
            PersonaDocumentos = new HashSet<PersonaDocumento>();
            PersonaTelefonos = new HashSet<PersonaTelefono>();
        }

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

        public virtual EstadoCivil IdEstadoCivilNavigation { get; set; }
        public virtual Nacionalidad IdNacionalidadNavigation { get; set; }
        public virtual ICollection<PersonaCorreoElectronico> PersonaCorreoElectronicos { get; set; }
        public virtual ICollection<PersonaDireccion> PersonaDireccions { get; set; }
        public virtual ICollection<PersonaDocumento> PersonaDocumentos { get; set; }
        public virtual ICollection<PersonaTelefono> PersonaTelefonos { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Almacena la informacion de todas las personas
    /// </summary>
    public partial class Persona
    {
        public Persona()
        {
            PersonaDireccions = new HashSet<PersonaDireccion>();
            PersonaDocumentos = new HashSet<PersonaDocumento>();
            PersonaEmails = new HashSet<PersonaEmail>();
            PersonaTelefonos = new HashSet<PersonaTelefono>();
        }

        /// <summary>
        /// id consecutivo de la tabla personas
        /// </summary>
        public int IdPersona { get; set; }
        /// <summary>
        /// id Nacionalidad de la persona
        /// </summary>
        public int IdNacionalidad { get; set; }
        /// <summary>
        /// El estado civil de la persona Casado, Divorciado, Soltero, union libre
        /// </summary>
        public int IdEstadoCivil { get; set; }
        /// <summary>
        /// Fecha de la Creacion del registro
        /// </summary>
        public DateTime FechaCreacion { get; set; }
        /// <summary>
        /// Usuario que creo el registro
        /// </summary>
        public string UsuarioCreacion { get; set; } = null!;
        /// <summary>
        /// Fecha de la ultima modificacion 
        /// </summary>
        public DateTime FechaModificacion { get; set; }
        /// <summary>
        /// Ultimo usuario que modifico 
        /// </summary>
        public string UsuarioModificacion { get; set; } = null!;
        /// <summary>
        /// Si el registro esta habilitado 
        /// </summary>
        public bool EsHabilitado { get; set; }
        /// <summary>
        /// Estatus de la Persona 
        /// </summary>
        public string Estatus { get; set; } = null!;
        /// <summary>
        /// Apellido paterno de la persona
        /// </summary>
        public string ApellidoPaterno { get; set; } = null!;
        /// <summary>
        /// Apellido materno de la persona
        /// </summary>
        public string ApellidoMaterno { get; set; } = null!;
        /// <summary>
        /// Nombre o Nombres de la persona
        /// </summary>
        public string Nombres { get; set; } = null!;
        /// <summary>
        /// Fecha de nacimiento de la persona
        /// </summary>
        public DateTime FechaNacimiento { get; set; }
        /// <summary>
        /// M = Masculino , F = Femenino
        /// </summary>
        public string Sexo { get; set; } = null!;
        /// <summary>
        /// El path de la foto de la persona
        /// </summary>
        public string Foto { get; set; } = null!;
        /// <summary>
        /// Notas importantes de la persona
        /// </summary>
        public string Notas { get; set; } = null!;

        public virtual EstadoCivil IdEstadoCivilNavigation { get; set; } = null!;
        public virtual Nacionalidad IdNacionalidadNavigation { get; set; } = null!;
        public virtual ICollection<PersonaDireccion> PersonaDireccions { get; set; }
        public virtual ICollection<PersonaDocumento> PersonaDocumentos { get; set; }
        public virtual ICollection<PersonaEmail> PersonaEmails { get; set; }
        public virtual ICollection<PersonaTelefono> PersonaTelefonos { get; set; }
    }
}

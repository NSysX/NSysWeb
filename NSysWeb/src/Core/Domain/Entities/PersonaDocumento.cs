using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// La relacion de los documentos que puede tener una persona
    /// </summary>
    public partial class PersonaDocumento
    {
        public int IdPersonaDocumento { get; set; }
        /// <summary>
        /// El idPersona de la tabla Personas
        /// </summary>
        public int IdPersona { get; set; }
        /// <summary>
        /// IdDocumento de la Tabla Documento
        /// </summary>
        public int IdDocumento { get; set; }

        public virtual Documento IdDocumentoNavigation { get; set; } = null!;
        public virtual Persona IdPersonaNavigation { get; set; } = null!;
    }
}

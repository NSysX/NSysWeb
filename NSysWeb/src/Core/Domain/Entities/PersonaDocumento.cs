using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class PersonaDocumento
    {
        public int IdPersona { get; set; }
        public int IdDocumento { get; set; }

        public virtual Documento IdDocumentoNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
    }
}

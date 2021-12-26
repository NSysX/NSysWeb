#nullable disable

using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class PersonaDocumento
    {
        public int IdPersonaDocumento { get; set; }
        public int IdPersona { get; set; }
        public int IdDocumento { get; set; }

        public virtual Documento Documento { get; set; }
        public virtual Persona Persona { get; set; }
    }
}

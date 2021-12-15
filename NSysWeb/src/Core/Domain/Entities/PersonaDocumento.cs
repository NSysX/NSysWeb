using Domain.Common;

#nullable disable

namespace Domain.Entities
{
    public partial class PersonaDocumento : EntidadBaseAuditable
    {
        public int IdPersona { get; set; }
        public int IdDocumento { get; set; }

        public virtual Documento IdDocumentoNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
    }
}

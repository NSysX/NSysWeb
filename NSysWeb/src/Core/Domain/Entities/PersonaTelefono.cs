using Domain.Common;

#nullable disable

namespace Domain.Entities
{
    public partial class PersonaTelefono : EntidadBaseAuditable
    {
        public int IdPersona { get; set; }
        public int IdTelefono { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual Telefono IdTelefonoNavigation { get; set; }
    }
}

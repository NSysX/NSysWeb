using Domain.Common;

#nullable disable

namespace Domain.Entities
{
    public partial class PersonaCorreoElectronico : EntidadBaseAuditable
    {
        public int IdPersona { get; set; }
        public int IdCorreoElectronico { get; set; }

        public virtual CorreoElectronico IdCorreoElectronicoNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
    }
}

#nullable disable

namespace Domain.Entities
{
    public partial class PersonaCorreoElectronico
    {
        public int IdPersonaCorreoElectronico { get; set; }
        public int IdPersona { get; set; }
        public int IdCorreoElectronico { get; set; }

        public virtual CorreoElectronico CorreoElectronico { get; set; }
        public virtual Persona Persona { get; set; }
    }
}

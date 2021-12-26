#nullable disable

namespace Domain.Entities
{
    public partial class PersonaTelefono
    {
        public int IdPersonaTelefono { get; set; }
        public int IdPersona { get; set; }
        public int IdTelefono { get; set; }

        public virtual Persona Persona { get; set; }
        public virtual Telefono Telefono { get; set; }
    }
}

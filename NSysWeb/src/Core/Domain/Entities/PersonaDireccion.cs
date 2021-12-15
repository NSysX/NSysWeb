using Domain.Common;

#nullable disable

namespace Domain.Entities
{
    public partial class PersonaDireccion : EntidadBaseAuditable
    {
        public int IdPersona { get; set; }
        public int IdDireccion { get; set; }

        public virtual Direccion IdDireccionNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
    }
}

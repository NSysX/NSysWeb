using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class PersonaTelefono
    {
        public int IdPersona { get; set; }
        public int IdTelefono { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual Telefono IdTelefonoNavigation { get; set; }
    }
}

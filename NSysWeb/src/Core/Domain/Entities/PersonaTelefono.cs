using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class PersonaTelefono
    {
        public int IdPersonaTelefono { get; set; }
        public int IdPersona { get; set; }
        public int IdTelefono { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual Telefono IdTelefonoNavigation { get; set; }
    }
}

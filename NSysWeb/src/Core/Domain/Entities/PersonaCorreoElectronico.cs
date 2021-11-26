using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class PersonaCorreoElectronico
    {
        public int IdPersonaCorreoElectronico { get; set; }
        public int IdPersona { get; set; }
        public int IdCorreoElectronico { get; set; }

        public virtual CorreoElectronico IdCorreoElectronicoNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
    }
}

using Domain.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class CorreoElectronico : EntidadBaseAuditable
    {
        public CorreoElectronico()
        {
            PersonaCorreoElectronicos = new HashSet<PersonaCorreoElectronico>();
        }

        public int IdCorreoElectronico { get; set; }
        public string Estatus { get; set; }
        public string Correo { get; set; }
        public string TipoEmail { get; set; }

        public virtual ICollection<PersonaCorreoElectronico> PersonaCorreoElectronicos { get; set; }
    }
}

using Domain.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class EstadoCivil : EntidadBaseAuditable
    {
        public EstadoCivil()
        {
            Personas = new HashSet<Persona>();
        }

        public int IdEstadoCivil { get; set; }
        public string Estatus { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}

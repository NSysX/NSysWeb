using Domain.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Nacionalidad : EntidadBaseAuditable
    {
        public Nacionalidad()
        {
            Personas = new HashSet<Persona>();
        }

        public int IdNacionalidad { get; set; }
        public string Estatus { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}

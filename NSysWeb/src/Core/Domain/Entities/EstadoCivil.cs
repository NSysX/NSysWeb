﻿using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class EstadoCivil : EntidadBaseAuditable
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

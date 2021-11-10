﻿using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Estado :EntidadBaseAuditable
    {
        public Estado()
        {
            Municipios = new HashSet<Municipio>();
        }

        public int IdEstado { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }

        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}

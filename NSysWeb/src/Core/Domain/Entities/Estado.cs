using Domain.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class Estado : EntidadBaseAuditable
    {
        public Estado()
        {
            Municipios = new HashSet<Municipio>();
        }

        public int IdEstado { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }

        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}

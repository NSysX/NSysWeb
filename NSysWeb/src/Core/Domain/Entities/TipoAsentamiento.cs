using Domain.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class TipoAsentamiento : EntidadBaseAuditable
    {
        public TipoAsentamiento()
        {
            Asentamientos = new HashSet<Asentamiento>();
        }

        public int IdTipoAsentamiento { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }

        public virtual ICollection<Asentamiento> Asentamientos { get; set; }
    }
}

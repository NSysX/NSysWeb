using Domain.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class Telefono : EntidadBaseAuditable
    {
        public Telefono()
        {
            PersonaTelefonos = new HashSet<PersonaTelefono>();
        }

        public int IdTelefono { get; set; }
        public string Estatus { get; set; }
        public string TipoTelefono { get; set; }
        public string CodigoPais { get; set; }
        public string Numero { get; set; }

        public virtual ICollection<PersonaTelefono> PersonaTelefonos { get; set; }
    }
}

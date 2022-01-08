using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Pais : EntidadBaseAuditable
    {
        public Pais()
        {
            Estados = new HashSet<Estado>();
        }

        public int IdPais { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }

        public virtual ICollection<Estado> Estados { get; set; }
    }
}

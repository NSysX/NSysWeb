using Domain.Common;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class AsentamientoTipo : EntidadBaseAuditable
    {
        public AsentamientoTipo()
        {
            Asentamientos = new HashSet<Asentamiento>();
        }

        public int IdAsentamientoTipo { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }

        public virtual ICollection<Asentamiento> Asentamientos { get; set; }
    }
}

using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class TipoAsentamiento : EntidadBaseAuditable
    {
        public TipoAsentamiento()
        {
            Asentamientos = new HashSet<Asentamiento>();
        }

        public int IdTipoAsentamiento { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }

        public virtual ICollection<Asentamiento> Asentamientos { get; set; }
    }
}

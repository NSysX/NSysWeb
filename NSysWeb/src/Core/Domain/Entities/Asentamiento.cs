using Domain.Common;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Asentamiento : EntidadBaseAuditable
    {
        public Asentamiento()
        {
            Direcciones = new HashSet<Direccion>();
        }

        public int IdAsentamiento { get; set; }
        public int IdAsentamientoTipo { get; set; }
        public int IdMunicipio { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public int CodigoPostal { get; set; }

        public virtual AsentamientoTipo AsentamientoTipo { get; set; }
        public virtual Municipio Municipio { get; set; }
        public virtual ICollection<Direccion> Direcciones { get; set; }
    }
}

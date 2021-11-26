using Domain.Common;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class Asentamiento : EntidadBaseAuditable
    {
        public Asentamiento()
        {
            Direccions = new HashSet<Direccion>();
        }

        public int IdAsentamiento { get; set; }
        public int IdTipoAsentamiento { get; set; }
        public int IdMunicipio { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public int CodigoPostal { get; set; }

        public virtual Municipio IdMunicipioNavigation { get; set; }
        public virtual TipoAsentamiento IdTipoAsentamientoNavigation { get; set; }
        public virtual ICollection<Direccion> Direccions { get; set; }
    }
}

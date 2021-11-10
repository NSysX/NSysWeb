using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class Asentamiento : EntidadBaseAuditable
    {
        public Asentamiento()
        {
            Direccions = new HashSet<Direccion>();
        }

        public int IdAsentamiento { get; set; }
        public int IdTipoAsentamiento { get; set; }
        public int IdMunicipio { get; set; }
        public string Nombre { get; set; }
        public int Codigo_Postal { get; set; }

        public virtual Municipio IdMunicipioNavigation { get; set; }
        public virtual TipoAsentamiento IdTipoAsentamientoNavigation { get; set; }
        public virtual ICollection<Direccion> Direccions { get; set; }
    }
}

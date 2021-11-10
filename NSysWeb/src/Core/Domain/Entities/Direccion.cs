using Domain.Common;
using NetTopologySuite.Geometries;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Direccion : EntidadBaseAuditable
    {
        public Direccion()
        {
            PersonaDireccions = new HashSet<PersonaDireccion>();
        }

        public int IdDireccion { get; set; }
        public string Estatus { get; set; }
        public string Calle { get; set; }
        public string Numero_Exterior { get; set; }
        public string Numero_Interior { get; set; }
        public int IdAsentamiento { get; set; }
        public Geometry Coordenadas_Geo { get; set; }
        public string Referencia { get; set; }
        public string Foto { get; set; }
        public bool Es_Fiscal { get; set; }

        public virtual Asentamiento IdAsentamientoNavigation { get; set; }
        public virtual ICollection<PersonaDireccion> PersonaDireccions { get; set; }
    }
}

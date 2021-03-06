using Domain.Common;
using NetTopologySuite.Geometries;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Direccion : EntidadBaseAuditable
    {
        public int IdDireccion { get; set; }
        public int IdAsentamiento { get; set; }
        public string Estatus { get; set; }
        public string Calle { get; set; }
        public string EntreLaCalle { get; set; }
        public string YlaCalle { get; set; }
        public string NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }
        public Point CoordenadasGeo { get; set; }
        public string Referencia { get; set; }
        public string Foto { get; set; }
        public bool EsFiscal { get; set; }

        public virtual Asentamiento Asentamiento { get; set; }
        public List<PersonaDireccion> PersonaDirecciones { get; set; }
    }
}
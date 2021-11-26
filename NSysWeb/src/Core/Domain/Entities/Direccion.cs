using System;
using System.Collections.Generic;
using Domain.Common;
using NetTopologySuite.Geometries;

#nullable disable

namespace Domain.Entities
{
    public class Direccion : EntidadBaseAuditable
    {
        public Direccion()
        {
            PersonaDireccions = new HashSet<PersonaDireccion>();
        }

        public int IdDireccion { get; set; }
        public int IdAsentamiento { get; set; }
        public string Estatus { get; set; }
        public string Calle { get; set; }
        public string EntreLaCalle { get; set; }
        public string YlaCalle { get; set; }
        public string NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }
        public Geometry CoordenadasGeo { get; set; }
        public string Referencia { get; set; }
        public string Foto { get; set; }
        public bool EsFiscal { get; set; }

        public virtual Asentamiento IdAsentamientoNavigation { get; set; }
        public virtual ICollection<PersonaDireccion> PersonaDireccions { get; set; }
    }
}

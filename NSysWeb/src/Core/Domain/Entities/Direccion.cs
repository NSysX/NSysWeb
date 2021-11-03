using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Direccion
    {
        public Direccion()
        {
            PersonaDireccions = new HashSet<PersonaDireccion>();
        }

        public int IdDireccion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaMod { get; set; }
        public string UsuarioMod { get; set; }
        public bool EsHabilitado { get; set; }
        public string Estatus { get; set; }
        public string Calle { get; set; }
        public string NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }
        public int IdAsentamiento { get; set; }
        public Geometry CoordenadasGeo { get; set; }
        public string Referencia { get; set; }
        public string Foto { get; set; }
        public bool EsFiscal { get; set; }

        public virtual Asentamiento IdAsentamientoNavigation { get; set; }
        public virtual ICollection<PersonaDireccion> PersonaDireccions { get; set; }
    }
}

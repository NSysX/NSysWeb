using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

#nullable disable

namespace Domain.Entities
{
    public partial class Direccion
    {
        public int IdDireccion { get; set; }
        public int IdAsentamiento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool EsHabilitado { get; set; }
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
    }
}

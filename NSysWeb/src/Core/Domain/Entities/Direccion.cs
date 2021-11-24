using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Domain.Entities
{
    /// <summary>
    /// Registra todas las direcciones
    /// </summary>
    public partial class Direccion
    {
        public Direccion()
        {
            PersonaDireccions = new HashSet<PersonaDireccion>();
        }

        /// <summary>
        /// Id Numerico Consecutivo de direcciones
        /// </summary>
        public int IdDireccion { get; set; }
        /// <summary>
        /// el id de la tabla Asentamiento
        /// </summary>
        public int IdAsentamiento { get; set; }
        /// <summary>
        /// Fecha de creacion del registro
        /// </summary>
        public DateTime FechaCreacion { get; set; }
        /// <summary>
        /// Usuario que creo el registro
        /// </summary>
        public string UsuarioCreacion { get; set; } = null!;
        /// <summary>
        /// Fecha de la Ultima Modificacion
        /// </summary>
        public DateTime FechaModificacion { get; set; }
        /// <summary>
        /// Usuario que hizo la ultima modificacion
        /// </summary>
        public string UsuarioModificacion { get; set; } = null!;
        /// <summary>
        /// Si esta disponible el registro
        /// </summary>
        public bool EsHabilitado { get; set; }
        /// <summary>
        /// Estatus de la direccion
        /// </summary>
        public string Estatus { get; set; } = null!;
        public string Calle { get; set; } = null!;
        public string EntreLaCalle { get; set; } = null!;
        public string YlaCalle { get; set; } = null!;
        public string NumeroExterior { get; set; } = null!;
        public string NumeroInterior { get; set; } = null!;
        /// <summary>
        /// Coordenadas geograficas , Acepta nulos
        /// </summary>
        #nullable enable
        public Geometry? CoordenadasGeo { get; set; }

        #nullable disable
        /// <summary>
        /// Referencias para identificar la direccion
        /// </summary>
        public string Referencia { get; set; } = null!;
        /// <summary>
        /// Foto de la ubicacion
        /// </summary>
        public string Foto { get; set; } = null!;
        /// <summary>
        /// Si la direccion es fiscal para la emision de facturas
        /// </summary>
        public bool EsFiscal { get; set; }

        public virtual Asentamiento IdAsentamientoNavigation { get; set; } = null!;
        public virtual ICollection<PersonaDireccion> PersonaDireccions { get; set; }
    }
}

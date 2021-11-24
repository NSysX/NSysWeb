using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Nombre del asentamiento
    /// </summary>
    public partial class Asentamiento
    {
        public Asentamiento()
        {
            Direccions = new HashSet<Direccion>();
        }

        /// <summary>
        /// Consecutivo de Asentamiento
        /// </summary>
        public int IdAsentamiento { get; set; }
        /// <summary>
        /// El id de la tabla TipoAsentamiento 
        /// </summary>
        public int IdTipoAsentamiento { get; set; }
        /// <summary>
        /// id del municipio al que pertenece
        /// </summary>
        public int IdMunicipio { get; set; }
        /// <summary>
        /// Fecha de Creacion del Registro
        /// </summary>
        public DateTime FechaCreacion { get; set; }
        /// <summary>
        /// Usuario de Creacion del registro
        /// </summary>
        public string UsuarioCreacion { get; set; } = null!;
        /// <summary>
        /// Fecha de la Ultima Modificacion
        /// </summary>
        public DateTime FechaModificacion { get; set; }
        /// <summary>
        /// Ultimo usuario que modifico el registro
        /// </summary>
        public string UsuarioModificacion { get; set; } = null!;
        /// <summary>
        /// Si el registro esta habilitado 
        /// </summary>
        public bool EsHabilitado { get; set; }
        /// <summary>
        /// Nombre del asentamiento
        /// </summary>
        public string Nombre { get; set; } = null!;
        /// <summary>
        /// Codigo Postal
        /// </summary>
        public int CodigoPostal { get; set; }

        public virtual Municipio IdMunicipioNavigation { get; set; } = null!;
        public virtual TipoAsentamiento IdTipoAsentamientoNavigation { get; set; } = null!;
        public virtual ICollection<Direccion> Direccions { get; set; }
    }
}

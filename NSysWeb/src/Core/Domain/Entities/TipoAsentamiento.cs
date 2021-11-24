using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Los tipos de Asentamientos como Ejido, Colonia , Poblado
    /// </summary>
    public partial class TipoAsentamiento
    {
        public TipoAsentamiento()
        {
            Asentamientos = new HashSet<Asentamiento>();
        }

        /// <summary>
        /// Id Consecutivo
        /// </summary>
        public int IdTipoAsentamiento { get; set; }
        /// <summary>
        /// Fecha de Creacion del registro
        /// </summary>
        public DateTime FechaCreacion { get; set; }
        /// <summary>
        /// Usuario que creo el registro
        /// </summary>
        public string UsuarioCreacion { get; set; } = null!;
        /// <summary>
        /// Ultima Fecha de Modificacion
        /// </summary>
        public string FechaModificacion { get; set; } = null!;
        /// <summary>
        /// Ultimo usuario que modifico el registro
        /// </summary>
        public string UsuarioModificacion { get; set; } = null!;
        /// <summary>
        /// Si esta disponible el registro 
        /// </summary>
        public bool EsHabilitado { get; set; }
        /// <summary>
        /// Nombre del tipo de Asentamiento 
        /// </summary>
        public string Nombre { get; set; } = null!;
        /// <summary>
        /// Abreviatura de la descripcion de tipo de asentamiento
        /// </summary>
        public string Abreviatura { get; set; } = null!;

        public virtual ICollection<Asentamiento> Asentamientos { get; set; }
    }
}

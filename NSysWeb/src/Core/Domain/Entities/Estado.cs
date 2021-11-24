using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Estado de paises
    /// </summary>
    public partial class Estado
    {
        public Estado()
        {
            Municipios = new HashSet<Municipio>();
        }

        /// <summary>
        /// id del estado
        /// </summary>
        public int IdEstado { get; set; }
        /// <summary>
        /// Fecha de creacion del registro
        /// </summary>
        public DateTime FechaCreacion { get; set; }
        /// <summary>
        /// Usuario que creo el registro
        /// </summary>
        public string UsuarioCreacion { get; set; } = null!;
        /// <summary>
        /// Fecha de la ultima modificacion
        /// </summary>
        public DateTime FechaModificacion { get; set; }
        /// <summary>
        /// Usuario de la ultima modificacion
        /// </summary>
        public string UsuarioModificacion { get; set; } = null!;
        /// <summary>
        /// si esta disponible el registro
        /// </summary>
        public bool EsHabilitado { get; set; }
        /// <summary>
        /// codigo consecutivo para no mostrar el id usuario
        /// </summary>
        public int Codigo { get; set; }
        /// <summary>
        /// Nombre del estado del pais
        /// </summary>
        public string Nombre { get; set; } = null!;
        /// <summary>
        /// Abreviatura de nombre del estado de la republica
        /// </summary>
        public string Abreviatura { get; set; } = null!;

        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Se capturan los tipos de documentos para que esten disponibles
    /// </summary>
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            Documentos = new HashSet<Documento>();
        }

        /// <summary>
        /// El identificador unico de registro
        /// </summary>
        public int IdTipoDocumento { get; set; }
        /// <summary>
        /// Fecha en que se creo el registro
        /// </summary>
        public DateTime FechaCreacion { get; set; }
        /// <summary>
        /// Usuario que creo el registro
        /// </summary>
        public DateTime UsuarioCreacion { get; set; }
        /// <summary>
        /// Fecha de la ultima modificacion del registro
        /// </summary>
        public DateTime FechaModificacion { get; set; }
        /// <summary>
        /// El usuario de la ultima modificacion
        /// </summary>
        public DateTime UsuarioModificacion { get; set; }
        /// <summary>
        /// Si el registro esta disponible para trabajar con el
        /// </summary>
        public bool EsHabilitado { get; set; }
        /// <summary>
        /// Estatus del registro
        /// </summary>
        public string Estatus { get; set; } = null!;
        /// <summary>
        /// Nombre completo del documento 
        /// </summary>
        public string Nombre { get; set; } = null!;
        /// <summary>
        /// Abreviacion del documento
        /// </summary>
        public string Abreviacion { get; set; } = null!;
        /// <summary>
        /// La longitud de caracteres permitido para la Cadena Unica
        /// </summary>
        public string Longitud { get; set; } = null!;

        public virtual ICollection<Documento> Documentos { get; set; }
    }
}

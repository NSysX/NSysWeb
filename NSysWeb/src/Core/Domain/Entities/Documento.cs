using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Se incluyen todos los documentos que las personas fisicas y morales pueden tener
    /// </summary>
    public partial class Documento
    {
        public Documento()
        {
            PersonaDocumentos = new HashSet<PersonaDocumento>();
        }

        /// <summary>
        /// El id de la tabla Documento
        /// </summary>
        public int IdDocumento { get; set; }
        /// <summary>
        /// El identificador unico de la tabla TipoDocumento
        /// </summary>
        public int IdTipoDocumento { get; set; }
        /// <summary>
        /// Fecha de Creacion de registro
        /// </summary>
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; } = null!;
        /// <summary>
        /// Ultima Fecha de modificacion
        /// </summary>
        public DateTime FechaModificacion { get; set; }
        /// <summary>
        /// Ultimo usuario que modifico el registro
        /// </summary>
        public string UsuarioModificacion { get; set; } = null!;
        /// <summary>
        /// Si el registro esta disponible para usarlo
        /// </summary>
        public bool EsHabilitado { get; set; }
        /// <summary>
        /// algun estatus para el registro
        /// </summary>
        public string Estatus { get; set; } = null!;
        /// <summary>
        /// La cadena unica del documento
        /// </summary>
        public string CadenaUnica { get; set; } = null!;
        /// <summary>
        /// Imagen del documento
        /// </summary>
        public string Imagen { get; set; } = null!;

        public virtual TipoDocumento IdTipoDocumentoNavigation { get; set; } = null!;
        public virtual ICollection<PersonaDocumento> PersonaDocumentos { get; set; }
    }
}

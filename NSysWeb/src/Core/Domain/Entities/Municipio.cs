using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Municipios de Mexico
    /// </summary>
    public partial class Municipio
    {
        public Municipio()
        {
            Asentamientos = new HashSet<Asentamiento>();
        }

        /// <summary>
        /// id consecutivo de municipio
        /// </summary>
        public int IdMunicipio { get; set; }
        /// <summary>
        /// id que pertenece al estado
        /// </summary>
        public int IdEstado { get; set; }
        /// <summary>
        /// Fecha de Creacion del registro
        /// </summary>
        public DateTime FechaCreacion { get; set; }
        /// <summary>
        /// Usuario que creo el Registro
        /// </summary>
        public string UsuarioCreacion { get; set; } = null!;
        /// <summary>
        /// Fecha de la utlima modificacion
        /// </summary>
        public DateTime FechaModificacion { get; set; }
        /// <summary>
        /// Ultimo usuario que modifico el registro
        /// </summary>
        public string UsuarioModificacion { get; set; } = null!;
        /// <summary>
        /// Si el registro esta disponible
        /// </summary>
        public bool EsHabilitado { get; set; }
        /// <summary>
        /// Codigo visible al usuario
        /// </summary>
        public int Codigo { get; set; }
        /// <summary>
        /// Nombre del Municipio
        /// </summary>
        public string Nombre { get; set; } = null!;
        public string Abreviatura { get; set; } = null!;

        public virtual Estado IdEstadoNavigation { get; set; } = null!;
        public virtual ICollection<Asentamiento> Asentamientos { get; set; }
    }
}

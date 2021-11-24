using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Todos los Telefonos de personas y empresas
    /// </summary>
    public partial class Telefono
    {
        public Telefono()
        {
            PersonaTelefonos = new HashSet<PersonaTelefono>();
        }

        /// <summary>
        /// Identificador unico de la tabla telefono
        /// </summary>
        public int IdTelefono { get; set; }
        /// <summary>
        /// Fecha de creacion del registro
        /// </summary>
        public DateTime FechaCreacion { get; set; }
        /// <summary>
        /// Usuario que creo el registro
        /// </summary>
        public string UsuarioCreacion { get; set; } = null!;
        /// <summary>
        /// Ultima fecha de Modificacion del registro
        /// </summary>
        public DateTime FechaModificacion { get; set; }
        /// <summary>
        /// Ultimo usuario que modifico el registro
        /// </summary>
        public string UsuarioModificacion { get; set; } = null!;
        /// <summary>
        /// Si el registro esta habilitado para trabajar
        /// </summary>
        public bool EsHabilitado { get; set; }
        /// <summary>
        /// Estatus del registro
        /// </summary>
        public string Estatus { get; set; } = null!;
        /// <summary>
        /// Celular o Fijo
        /// </summary>
        public string TipoTelefono { get; set; } = null!;
        /// <summary>
        /// Codigo Telefonico del Pais
        /// </summary>
        public string CodigoPais { get; set; } = null!;
        /// <summary>
        /// Numero telefonico
        /// </summary>
        public string Numero { get; set; } = null!;

        public virtual ICollection<PersonaTelefono> PersonaTelefonos { get; set; }
    }
}

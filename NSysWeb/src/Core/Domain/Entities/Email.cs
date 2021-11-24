using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Todos lo Correos Electronicos de personas y Empresas
    /// </summary>
    public partial class Email
    {
        public Email()
        {
            PersonaEmails = new HashSet<PersonaEmail>();
        }

        /// <summary>
        /// Identificador unico
        /// </summary>
        public int IdEmail { get; set; }
        /// <summary>
        /// Fecha de Creacion del registro
        /// </summary>
        public DateTime FechaCreacion { get; set; }
        /// <summary>
        /// Usuario Creacion del registro
        /// </summary>
        public string UsuarioCreacion { get; set; } = null!;
        /// <summary>
        /// Fecha modificacion
        /// </summary>
        public DateTime FechaModificacion { get; set; }
        /// <summary>
        /// Ultimo usuario que modifico el registro
        /// </summary>
        public string UsuarioModificacion { get; set; } = null!;
        /// <summary>
        /// Si el registro esta habilitado para trabajar con el, borrado logico
        /// </summary>
        public bool EsHabilitado { get; set; }
        /// <summary>
        /// El Email o Correo electroinico
        /// </summary>
        public string Email1 { get; set; } = null!;
        /// <summary>
        /// Tipo de email personal trabajo 
        /// </summary>
        public string TipoEmail { get; set; } = null!;

        public virtual ICollection<PersonaEmail> PersonaEmails { get; set; }
    }
}

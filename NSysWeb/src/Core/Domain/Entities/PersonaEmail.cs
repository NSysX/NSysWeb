using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Los email que tiene una persona
    /// </summary>
    public partial class PersonaEmail
    {
        /// <summary>
        /// identificador unico de los registros
        /// </summary>
        public int IdPersonaEmail { get; set; }
        /// <summary>
        /// Identificador unico del registro de persona 
        /// </summary>
        public int IdPersona { get; set; }
        /// <summary>
        /// Identificador unico de la tabla de email
        /// </summary>
        public int IdEmail { get; set; }

        public virtual Email IdEmailNavigation { get; set; } = null!;
        public virtual Persona IdPersonaNavigation { get; set; } = null!;
    }
}

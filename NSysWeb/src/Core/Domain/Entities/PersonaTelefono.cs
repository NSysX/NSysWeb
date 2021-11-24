using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Los numeros de telefono de las personas
    /// </summary>
    public partial class PersonaTelefono
    {
        /// <summary>
        /// El identificador de la tabla  persona telefono
        /// </summary>
        public int IdPersonaTelefono { get; set; }
        /// <summary>
        /// El identificador de la tabla persona
        /// </summary>
        public int IdPersona { get; set; }
        /// <summary>
        /// El identificador de la tabla telefono
        /// </summary>
        public int IdTelefono { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; } = null!;
        public virtual Telefono IdTelefonoNavigation { get; set; } = null!;
    }
}

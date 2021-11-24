using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Dominios precapturados para los correos
    /// </summary>
    public partial class SysDominioEmail
    {
        /// <summary>
        /// Identificador unico 
        /// </summary>
        public int IdSysDominio { get; set; }
        /// <summary>
        /// Fecha de creacion del registro
        /// </summary>
        public DateTime FechaCreacion { get; set; }
        /// <summary>
        /// Usuario que creo el registro
        /// </summary>
        public DateTime UsuarioCreacion { get; set; }
        /// <summary>
        /// Fecha de la ultima modificacion
        /// </summary>
        public DateTime FechaModificacion { get; set; }
        /// <summary>
        /// Usuario que hizo la ultima modificacion
        /// </summary>
        public string UsuarioModificacion { get; set; } = null!;
        /// <summary>
        /// Dominio Hotmail.com, Gmail.com, etc..
        /// </summary>
        public string Dominio { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Catalogo de Nacionalidades con su bandera
    /// </summary>
    public partial class Nacionalidad
    {
        public Nacionalidad()
        {
            Personas = new HashSet<Persona>();
        }

        /// <summary>
        /// Id unico para el registro
        /// </summary>
        public int IdNacionalidad { get; set; }
        /// <summary>
        /// Fecha en que se creo el registro
        /// </summary>
        public DateTime FechaCreacion { get; set; }
        /// <summary>
        /// Usuario que creo el registro
        /// </summary>
        public string UsuarioCreacion { get; set; } = null!;
        /// <summary>
        /// fecha de la ultima modificacion
        /// </summary>
        public DateTime FechaModificacion { get; set; }
        /// <summary>
        /// El ultimo Usuario que modifico el registro
        /// </summary>
        public string UsuarioModificacion { get; set; } = null!;
        /// <summary>
        /// si esta disponible el registro 
        /// </summary>
        public bool EsHabilitado { get; set; }
        /// <summary>
        /// El Estatus del Registro
        /// </summary>
        public string Estatus { get; set; } = null!;
        /// <summary>
        /// concepto de nacionalidad de la persona
        /// </summary>
        public string Nacionalidad1 { get; set; } = null!;

        public virtual ICollection<Persona> Personas { get; set; }
    }
}

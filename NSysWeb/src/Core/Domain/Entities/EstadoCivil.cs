﻿using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Los estados Civiles de las Personas
    /// </summary>
    public partial class EstadoCivil
    {
        public EstadoCivil()
        {
            Personas = new HashSet<Persona>();
        }

        /// <summary>
        /// Id consecutivo 
        /// </summary>
        public int IdEstadoCivil { get; set; }
        /// <summary>
        /// Fecha de creacion del registro
        /// </summary>
        public DateTime FechaCreacion { get; set; }
        /// <summary>
        /// El usuario que creo el registro
        /// </summary>
        public string UsuarioCreacion { get; set; } = null!;
        /// <summary>
        /// Fecha de la ultima modificacion
        /// </summary>
        public DateTime FechaModificacion { get; set; }
        /// <summary>
        /// Ultimo usuario que modifico el registro
        /// </summary>
        public string UsuarioModificacion { get; set; } = null!;
        /// <summary>
        /// Si el registro esta habilitado
        /// </summary>
        public bool EsHabilitado { get; set; }
        /// <summary>
        /// Estatus del estado civil
        /// </summary>
        public string Estatus { get; set; } = null!;
        /// <summary>
        /// Descripcion del estado civil
        /// </summary>
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Persona> Personas { get; set; }
    }
}

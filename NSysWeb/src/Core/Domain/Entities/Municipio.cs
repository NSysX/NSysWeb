﻿using Domain.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class Municipio : EntidadBaseAuditable
    {
        public Municipio()
        {
            Asentamientos = new HashSet<Asentamiento>();
        }

        public int IdMunicipio { get; set; }
        public int IdEstado { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual ICollection<Asentamiento> Asentamientos { get; set; }
    }
}

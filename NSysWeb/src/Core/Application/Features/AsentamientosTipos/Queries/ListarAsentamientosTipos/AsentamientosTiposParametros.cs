using Application.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AsentamientosTipos.Queries.ListarAsentamientosTipos
{
    public class AsentamientosTiposParametros : PaginacionDePeticion
    {
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
    }
}

using Application.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Personas.Queries.ListarPersonasXParametros
{
    public class ListarPersonasParametros : PaginacionDePeticion
    {
        public string Estatus { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
    }
}

using Application.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Direcciones.Queries.DireccionesXParametros
{
    public class DireccionesParametros : PaginacionDePeticion
    {
        public string Calle { get; set; }
    }
}

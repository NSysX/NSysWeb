using Application.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.EstadosCiviles.Queries.ListarEstadosCivilesQuery
{
    public class ListarEstadosCivilesXParametro : ParametrosPaginacionDePeticion
    {
        // vamos a buscar x descripcion y habilitado y a la vez lo vamos a paginar
        public string Descripcion { get; set; }
        public string Estatus { get; set; }
    }
}

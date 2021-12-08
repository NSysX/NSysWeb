using Application.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TiposDocumentos.Queries.ListarTiposDocumentos
{
    public class TiposDocumentosParametros : PaginacionDePeticion
    {
        // las priopiedades por las cuales vamos a filtrar los registros
        public string Nombre { get; set; }
        public string Abreviacion { get; set; }
        public string Estatus { get; set; }
    }
}

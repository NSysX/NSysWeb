using Application.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Documentos.Queries.ListarDocumentos
{
    public class DocumentosParametros : PaginacionDePeticion
    {
        // los campos por donde vamos a hacer las busquedas
        // falta poner busqueda X TipoDoctoNombre de la tabla con left join
        public string CodigoUnico { get; set; }
    }
}

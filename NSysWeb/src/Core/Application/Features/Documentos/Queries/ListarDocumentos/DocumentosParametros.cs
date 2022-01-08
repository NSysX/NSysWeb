using Application.Parametros;

namespace Application.Features.Documentos.Queries.ListarDocumentos
{
    public class DocumentosParametros : PaginacionDePeticion
    {
        // los campos por donde vamos a hacer las busquedas
        // falta poner busqueda X TipoDoctoNombre de la tabla con left join
        public string Estatus { get; set; }
        public string CodigoUnico { get; set; }
    }
}

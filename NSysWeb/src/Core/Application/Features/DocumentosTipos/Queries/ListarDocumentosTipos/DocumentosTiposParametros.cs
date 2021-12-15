using Application.Parametros;

namespace Application.Features.DocumentosTipos.Queries.ListarDocumentosTipos
{
    public class DocumentosTiposParametros : PaginacionDePeticion
    {
        // las priopiedades por las cuales vamos a filtrar los registros
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        public string Estatus { get; set; }
    }
}

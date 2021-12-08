using Application.Parametros;

namespace Application.Features.Nacionalidades.Queries
{
    public class NacionalidadParametros : PaginacionDePeticion
    {
        public string Descripcion { get; set; }
        public string Estatus { get; set; }
    }
}

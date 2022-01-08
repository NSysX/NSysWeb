using Application.Parametros;

namespace Application.Features.Paises.Queries.PaisesXParametros
{
    public class PaisParametros : PaginacionDePeticion
    {
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
    }
}

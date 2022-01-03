using Application.Parametros;

namespace Application.Features.Municipios.Queries.MunicipiosXParametros
{
    public class MunicipioParametros : PaginacionDePeticion
    {
        public string Nombre { get; set; }
        public int Clave { get; set; }
    }
}

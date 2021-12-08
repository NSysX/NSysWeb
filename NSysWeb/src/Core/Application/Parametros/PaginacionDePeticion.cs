namespace Application.Parametros
{
    public class PaginacionDePeticion
    {
        public int NumeroDePagina { get; set; }
        public int RegistrosXPagina { get; set; }

        public PaginacionDePeticion()
        {
            NumeroDePagina = 1;
            RegistrosXPagina = 10;
        }

        public PaginacionDePeticion(int numeroDePagina, int registrosXPagina)
        {
            this.NumeroDePagina = numeroDePagina < 1 ? 1 : numeroDePagina;
            this.RegistrosXPagina = registrosXPagina > 10 ? 10 : numeroDePagina;
        }
    }
}
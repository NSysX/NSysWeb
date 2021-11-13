namespace Application.Parametros
{
    public class ParametrosPaginacionDePeticion
    {
        public int NumeroDePagina { get; set; }
        public int RegistrosXPagina { get; set; }

        public ParametrosPaginacionDePeticion()
        {
            NumeroDePagina = 1;
            RegistrosXPagina = 10;
        }

        public ParametrosPaginacionDePeticion(int numeroDePagina, int registrosXPagina)
        {
            this.NumeroDePagina = numeroDePagina < 1 ? 1 : numeroDePagina;
            this.RegistrosXPagina = registrosXPagina > 10 ? 10 : numeroDePagina;
        }
    }
}
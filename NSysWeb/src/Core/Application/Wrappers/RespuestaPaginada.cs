using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    public class RespuestaPaginada<T> : Respuesta<T>
    {
        public int NumeroDePagina { get; set; } 
        public int RegistrosXPagina { get; set; }

        public RespuestaPaginada(T data, int numeroPagina, int registrosXPagina)
        {
            this.NumeroDePagina = numeroPagina;
            this.RegistrosXPagina = registrosXPagina;
            // de Respuesta
            this.Data = data;
            this.Message = null;
            this.Succeeded = true;
            this.Errors = null;
        }
    }
}

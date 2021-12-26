using Application.Parametros;
using Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SysDominiosCorreos.Queries.ListarSysDominiosCorreosQuery
{
    public class SysDominiosCorreosParametros : PaginacionDePeticion
    {
        // solo por lo que vamos a filtrar
        public string Estatus { get; set; }
        public string Dominio { get; set; }
    }
}

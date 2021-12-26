using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Linq;

namespace Application.Specifications.Telefonos
{
    public class TelefonosPaginadosSpec : Specification<Telefono>
    {
        public TelefonosPaginadosSpec(int numeroDePagina, int registroXPagina, string estatus, string codigoPais, string numero)
        {
            Query.Skip((numeroDePagina - 1) * numeroDePagina)
                .Take(registroXPagina).OrderBy(n => n.Numero);

            if (!String.IsNullOrEmpty(estatus))
                Query.Search(e => e.Estatus, "%" + estatus + "%");

            if (!String.IsNullOrEmpty(codigoPais))
                Query.Search(c => c.CodigoPais, "%" + codigoPais + "%");

            if (!String.IsNullOrEmpty(numero))
                Query.Search(n => n.Numero, "%" + numero + "%");
        }
    }
}

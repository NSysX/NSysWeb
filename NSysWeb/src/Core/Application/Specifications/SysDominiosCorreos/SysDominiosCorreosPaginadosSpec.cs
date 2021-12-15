using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Linq;

namespace Application.Specifications.SysDominiosCorreos
{
    public class SysDominiosCorreosPaginadosSpec : Specification<SysDominioCorreo>
    {
        public SysDominiosCorreosPaginadosSpec(int registrosXPagina, int numeroPagina, string estatus, string dominio)
        {
            Query.Skip((numeroPagina - 1) * registrosXPagina)
                .Take(registrosXPagina).OrderBy(d => d.Dominio);

            if (!String.IsNullOrEmpty(estatus))
                Query.Search(e => e.Estatus, "%" + estatus + "%");

            if (!String.IsNullOrEmpty(dominio))
                Query.Search(d => d.Dominio, "%" + dominio + "%");
        }
    }
}

using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Linq;

namespace Application.Specifications.CorreosElectronicos
{
    public class CorreosElectronicosXParametrosSpec : Specification<CorreoElectronico>
    {
        public CorreosElectronicosXParametrosSpec(int registrosXPagina, int numeroDePagina, string estatus, string correo)
        {
            Query.Skip((numeroDePagina - 1) * registrosXPagina)
                .Take(registrosXPagina).OrderBy(s => s.Correo);

            if (!String.IsNullOrEmpty(estatus))
                Query.Search(e => e.Estatus, "%" + estatus + "%");

            if (!String.IsNullOrEmpty(correo))
                Query.Search(c => c.Correo, "%" + correo + "%");
        }
    }
}

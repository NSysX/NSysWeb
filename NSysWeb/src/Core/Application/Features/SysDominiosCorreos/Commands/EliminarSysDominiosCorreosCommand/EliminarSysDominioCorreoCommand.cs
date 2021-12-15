using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.SysDominiosCorreos.Commands.EliminarSysDominiosCorreosCommand
{
    public class EliminarSysDominioCorreoCommand : IRequest<Respuesta<int>>
    {
        public int IdSysDominio { get; set; }
    }

    public class EliminarSysDominio_Manejador : IRequestHandler<EliminarSysDominioCorreoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<SysDominioCorreo> _repositorioAsync;

        public EliminarSysDominio_Manejador(IRepositorioAsync<SysDominioCorreo> repositorioAsync)
        {
            this._repositorioAsync = repositorioAsync;
        }

        public async Task<Respuesta<int>> Handle(EliminarSysDominioCorreoCommand request, CancellationToken cancellationToken)
        {
            // Verificamos si existe el id a eliminar y de paso creamos el objeto para mandarlo eliminar
            SysDominioCorreo sysDominioCorreo = await _repositorioAsync.GetByIdAsync(request.IdSysDominio, cancellationToken);

            if (sysDominioCorreo == null)
                throw new KeyNotFoundException($"No se encontro el Registro con el Id = { request.IdSysDominio }");

            await _repositorioAsync.DeleteAsync(sysDominioCorreo, cancellationToken);

            return new Respuesta<int>(sysDominioCorreo.IdSysDominioCorreo);
        }
    }
}

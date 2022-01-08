using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Paises.Commands.EliminarPaisesCommand
{
    public class EliminaPaisCommand : IRequest<Respuesta<int>>
    {
        public int IdPais { get; set; }
    }

    public class EliminaPais_Manejador : IRequestHandler<EliminaPaisCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Pais> _repositorioAsync;

        public EliminaPais_Manejador(IRepositorioAsync<Pais> repositorioAsync)
        {
            this._repositorioAsync = repositorioAsync;
        }

        public async Task<Respuesta<int>> Handle(EliminaPaisCommand request, CancellationToken cancellationToken)
        {
            // verificamos que exista el pais a eliminar
            Pais pais = await _repositorioAsync.GetByIdAsync(request.IdPais, cancellationToken);
            if (pais == null)
                throw new KeyNotFoundException($"No se encontro el Pais con el Id = { request.IdPais }");

            await _repositorioAsync.DeleteAsync(pais, cancellationToken);

            return new Respuesta<int>(pais.IdPais);
        }
    }
}
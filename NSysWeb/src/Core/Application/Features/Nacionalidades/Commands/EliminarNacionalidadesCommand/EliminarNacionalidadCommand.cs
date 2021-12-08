using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Nacionalidades.Commands.EliminarNacionalidadesCommand
{
    public class EliminarNacionalidadCommand : IRequest<Respuesta<int>>
    {
        public int IdNacionalidad { get; set; }
    }

    public class EliminarNacionalidad_Manejador : IRequestHandler<EliminarNacionalidadCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Nacionalidad> _repositorioAsync;

        public EliminarNacionalidad_Manejador(IRepositorioAsync<Nacionalidad> repositorioAsync)
        {
            this._repositorioAsync = repositorioAsync;
        }

        public async Task<Respuesta<int>> Handle(EliminarNacionalidadCommand request, CancellationToken cancellationToken)
        {
            // Verifica que exista el Id
            Nacionalidad nacionalidad = await _repositorioAsync.GetByIdAsync(request.IdNacionalidad);
            if (nacionalidad == null)
                throw new KeyNotFoundException($"No se encontro el registro con el id = { request.IdNacionalidad }");

            await _repositorioAsync.DeleteAsync(nacionalidad);

            return new Respuesta<int>(nacionalidad.IdNacionalidad);
        }
    }
}

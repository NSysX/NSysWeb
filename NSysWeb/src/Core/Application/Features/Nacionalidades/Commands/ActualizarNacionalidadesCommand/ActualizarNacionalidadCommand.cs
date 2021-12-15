using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Nacionalidades.Commands.ActualizarNacionalidadesCommand
{
    public class ActualizarNacionalidadCommand : IRequest<Respuesta<int>>
    {
        public int IdNacionalidad { get; set; }
        public string Estatus { get; set; }
        public string Descripcion { get; set; }
    }

    public class ActualizaNacionalidad_Manejador : IRequestHandler<ActualizarNacionalidadCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Nacionalidad> _repositoryAsync;
        private readonly IMapper _mapper;

        // Dependency Injection
        public ActualizaNacionalidad_Manejador(IRepositorioAsync<Nacionalidad> repositoryAsync,
                                               IMapper mapper)
        {
            this._repositoryAsync = repositoryAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(ActualizarNacionalidadCommand request, CancellationToken cancellationToken)
        {
            // primero debemos saber que no exista un registro igual con un Spec
            // puede tener un costo mucha consultas a la BD
            // se puede solo controlar la excepcion


            // Verificamos que el id exista
            Nacionalidad nacionalidad = await _repositoryAsync.GetByIdAsync(request.IdNacionalidad);

            if (nacionalidad == null)
                throw new KeyNotFoundException($"No existe el registro con el Id ={request.IdNacionalidad}");

            // Si existe asignamos los valores al objeto
            nacionalidad.Estatus = request.Estatus;
            nacionalidad.Descripcion = request.Descripcion;

            // Actualizamos
            await _repositoryAsync.UpdateAsync(nacionalidad);

            //regresamos un obdjeto de respuesta con el id del objeto nacionalidad
            return new Respuesta<int>(nacionalidad.IdNacionalidad);
        }
    }
}

using Application.Exceptions;
using Application.Interfaces;
using Application.Specifications.Nacionalidades;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Nacionalidades.Commands
{
    public class InsertarNacionalidadCommand : IRequest<Respuesta<int>>
    {
        public string Estatus { get; set; }
        public string Descripcion { get; set; }
    }

    public class InsertaNacionalidad_Manejador : IRequestHandler<InsertarNacionalidadCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Nacionalidad> _repositorioAsync;
        private readonly IMapper _mapper;

        public InsertaNacionalidad_Manejador(IRepositorioAsync<Nacionalidad> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(InsertarNacionalidadCommand request, CancellationToken cancellationToken)
        {
            // Se verifica que no vengan datos duplicados
            // creamos el objeto specificacion con los datos a verificar
            var datosAVerificar = new ExisteNacionalidadSpec(request.Descripcion,0);
            // verificamos en el repositorio
            var respuesta = await _repositorioAsync.GetBySpecAsync(datosAVerificar);

            if (respuesta != null)
                throw new ExcepcionesDeAPI("No se Pueden Insertar Datos Duplicados");

            // mapeamos el objeto al tipo Nacionalidad
            Nacionalidad nacionalidad = _mapper.Map<Nacionalidad>(request);
            
            // insertamos el registro
            var resultado = await _repositorioAsync.AddAsync(nacionalidad);
            
            // regresamos el id nuevo en el wrapper respuesta
            return new Respuesta<int>(resultado.IdNacionalidad);
        }
    }
}

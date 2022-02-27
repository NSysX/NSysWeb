using Application.DTOs;
using Application.Interfaces;
using Application.Specifications.Asentamientos;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Asentamientos.Queries.AsentamientosXParametros
{
    public class AsentamientosXParametrosQuery : IRequest<RespuestaPaginada<List<AsentamientoDTO>>>
    {
        public int NumeroDePagina { get; set; }
        public int RegistrosXPaginas { get; set; }
        public string Nombre { get; set; }
        public int CodigoPostal { get; set; }
    }

    public class AsentamientoXParametros_Manejador : IRequestHandler<AsentamientosXParametrosQuery, RespuestaPaginada<List<AsentamientoDTO>>>
    {
        private readonly IRepositorioAsync<Asentamiento> _repositorioAsync;
        private readonly IDistributedCache _cacheDistribuida;
        private readonly IMapper _mapper;

        public AsentamientoXParametros_Manejador(IRepositorioAsync<Asentamiento> repositorioAsync, 
                                                 IDistributedCache cacheDistribuida,
                                                 IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._cacheDistribuida = cacheDistribuida;
            this._mapper = mapper;
        }

        public async Task<RespuestaPaginada<List<AsentamientoDTO>>> Handle(AsentamientosXParametrosQuery request, CancellationToken cancellationToken)
        {
            // para crear una llave unica les pasamos los parametros 
            var cachingKey = $"listadoAsentamientos_{ request.NumeroDePagina }_{ request.RegistrosXPaginas }_{ request.Nombre }_{ request.CodigoPostal }";

            string serializedListadoAsentamientos;
            List<Asentamiento> asentamientos;
            var redisListadoAsentamientos = await _cacheDistribuida.GetAsync(cachingKey,cancellationToken);
            
            if (redisListadoAsentamientos != null) // Si lo encuentra en la Cache
            {
                serializedListadoAsentamientos = Encoding.UTF8.GetString(redisListadoAsentamientos);
                asentamientos = JsonConvert.DeserializeObject<List<Asentamiento>>(serializedListadoAsentamientos);
            }
            else // si no lo encuentra en la cache lo consulta directo a SQLSERVER
            {
                var parametros = new AsentamientosXParametrosSpec(request.NumeroDePagina, request.RegistrosXPaginas, request.Nombre, request.CodigoPostal);

                asentamientos = await _repositorioAsync.ListAsync(parametros, cancellationToken);

                // solo para evitar el reference ciclada
                List<AsentamientoDTO> asentamientoDTOs1 = _mapper.Map<List<AsentamientoDTO>>(asentamientos);

                serializedListadoAsentamientos = JsonConvert.SerializeObject(asentamientoDTOs1);
                redisListadoAsentamientos = Encoding.UTF8.GetBytes(serializedListadoAsentamientos);

                // opciones para la duraciond e la CACHE
                DistributedCacheEntryOptions opciones = new DistributedCacheEntryOptions()
                                                         // vencimiento del objeto almacenado en cache
                                                        .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                                                        // caduca el objeto si no se solicita en el tiempo determinado
                                                        // debe ser siempre por debajo de la Absolute
                                                        .SetSlidingExpiration(TimeSpan.FromMinutes(2));


                // lo grabamos end la cache
                await _cacheDistribuida.SetAsync(cachingKey, redisListadoAsentamientos, opciones, cancellationToken);
            }

            List<AsentamientoDTO> asentamientoDTOs = _mapper.Map<List<AsentamientoDTO>>(asentamientos);

            return new RespuestaPaginada<List<AsentamientoDTO>>(asentamientoDTOs, request.NumeroDePagina, request.RegistrosXPaginas);
        }
    }
}

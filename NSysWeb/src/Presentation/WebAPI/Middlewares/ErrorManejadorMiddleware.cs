using Application.Exceptions;
using Application.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPI.Extensiones;

namespace WebAPI.Middlewares
{
    public class ErrorManejadorMiddleware
    {
        private readonly RequestDelegate _siguiente;

        private readonly IHostEnvironment environment;

        private readonly ILogger<ErrorManejadorMiddleware> logger;

        public ErrorManejadorMiddleware(RequestDelegate siguiente, IHostEnvironment environment, ILogger<ErrorManejadorMiddleware> logger)
        {
            this._siguiente = siguiente;
            this.environment = environment;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext contexto)
        {
            // la respuesta que trae ese contexto
            var respuesta = contexto.Response;
            // le decimos que la respuesta va a ser el JSON
            respuesta.ContentType = "application/json";

            // Le vamos a dar un modelo a ese response personalizado que hicimos previamente en wrappers
            // Succede es falso por que entro aqui

            Respuesta<string> modeloRespuesta = new();

            // string inner_Exception = error.InnerException.Message;
            modeloRespuesta.Succeeded = false;

            try
            {
                await _siguiente(contexto);
            }
            catch (DbUpdateException ex)
            {
                if (this.environment.IsDevelopment())
                {
                    modeloRespuesta.Message = ex.Message;
                    modeloRespuesta.Errors.Add(ex.GetAllMessages());
                }
                else
                {
                    modeloRespuesta.Message = "Fallo la operación, por favor intentelo nuevamente";
                }

                this.logger.LogError(ex, ex.GetAllMessages());

                await WriteError(respuesta, modeloRespuesta);
            }
            catch (SqlException ex) // "Microsoft.Data.SqlClient"
            {
                if (this.environment.IsDevelopment())
                {
                    modeloRespuesta.Message = ex.Message;
                    modeloRespuesta.Errors.Add(ex.GetAllMessages());
                }
                else
                {
                    modeloRespuesta.Message = "Fallo la operación, por favor intentelo nuevamente";
                }

                this.logger.LogError(ex, ex.GetAllMessages());

                await WriteError(respuesta, modeloRespuesta);
            }
            //catch (ExcepcionesDeAPI ex)
            //{

            //}
            catch (Exception error)
            {
                modeloRespuesta.Message = error?.Message;

                //switch (error.Source)
                //{
                //    //case "Microsoft.Data.SqlClient":
                //    //    // Aveces no trae innerMessage
                //    //    if (error.Message.ToLower().Contains("null values"))
                //    //    {
                //    //        modeloRespuesta.Message = "No se Pueden Consultar registros con campos NULOS";
                //    //        modeloRespuesta.Errors.Add("En la configuracion esta marcado como Requerido");
                //    //    }
                //    //    else
                //    //    {
                //    //        modeloRespuesta.Message = error.Message;
                //    //        modeloRespuesta.Errors.Add(error.InnerException.Message);
                //    //    }
                //    //    break;
                //    //case "Microsoft.EntityFrameworkCore.Relational":
                //    //    // Trae inner message
                //    //    // if (error.InnerException.Message.ToLower().Contains("duplicate key"))
                //    //    //{

                //    //    // }
                //    //    var dbUpdateException = error as DbUpdateException;


                //     //   break;
                //    default:

                //        break;
                //}

                // Luego se llena el resto del objeto
                //500, 403, 401, 200, 404, 400
                switch (error)
                {
                    case Application.Exceptions.ExcepcionesDeAPI e:
                        // Error de aplicacion personalizado
                        respuesta.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case Application.Exceptions.ExcepcionDeValidacion e:
                        // Error de Validacion Personalizado
                        respuesta.StatusCode = (int)HttpStatusCode.BadRequest;
                        modeloRespuesta.Errors = e.Errores;
                        break;
                    case KeyNotFoundException e:
                        // Sirve para arrojar el error 404 cuando no encuentre por Id el registro
                        respuesta.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // Unhandle Error
                        respuesta.StatusCode = (int)HttpStatusCode.InternalServerError;
                        //modeloRespuesta.Errors = respuesta.HttpContext.Response.StatusCode
                        break;
                }

                this.logger.LogError(error, error.GetAllMessages());

                await WriteError(respuesta, modeloRespuesta);
            }
        }

        private async Task WriteError(HttpResponse respuesta, Respuesta<string> modeloRespuesta)
        {
            var resultado = JsonSerializer.Serialize(modeloRespuesta);
            this.logger.LogError("Se genero o un error con la siguiente información: {0}", resultado);
            await respuesta.WriteAsync(resultado);
        }
    }
}

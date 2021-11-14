using Application.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebAPI.Middlewares
{
    public class ErrorManejadorMiddleware
    {
        private readonly RequestDelegate _siguiente;

        public ErrorManejadorMiddleware(RequestDelegate siguiente)
        {
            this._siguiente = siguiente;
        }

        public async Task Invoke(HttpContext contexto)
        {
            try
            {
                await _siguiente(contexto);
            }
            catch (Exception error)
            {
                // la respuesta que trae ese contexto
                var respuesta = contexto.Response;
                // le decimos que la respuesta va a ser el JSON
                respuesta.ContentType = "application/json";
                // Le vamos a dar un modelo a ese response personalizado que hicimos previamente en wrappers
                // Succede es falso por que entro aqui
                Respuesta<string> modeloRespuesta = new Respuesta<string>();
               // string inner_Exception = error.InnerException.Message;
                modeloRespuesta.Succeeded = false;

                switch (error.Source)
                {
                    case "Microsoft.Data.SqlClient":
                        // Aveces no trae innerMessage
                        if (error.Message.ToLower().Contains("null values"))
                        {
                            modeloRespuesta.Message = "No se Pueden Consultar registros con campos NULOS";
                            modeloRespuesta.Errors.Add("En la configuracion esta marcado como Requerido");
                        }
                        break;
                    case "Microsoft.EntityFrameworkCore.Relational":
                        // Trae inner message
                        if (error.InnerException.Message.ToLower().Contains("duplicate key"))
                        {
                            modeloRespuesta.Message = "No se puede Insertar Registros Duplicados";
                            modeloRespuesta.Errors.Add(error.InnerException.Message);
                        }
                        break;
                    default:
                        modeloRespuesta.Message = error?.Message;
                        break;
                }

                // Luego se llena el resto del objeto
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

                var resultado = JsonSerializer.Serialize(modeloRespuesta);

                await respuesta.WriteAsync(resultado);
            }
        }
    }
}

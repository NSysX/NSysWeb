using System;
using System.Collections.Generic;

namespace Application.Wrappers
{
    // clase generica que de un formato bonito a lo que son las respuestas JSon
    public class Respuesta<T>
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<String> Errors { get; set; }
        public T Data { get; set; }

        public Respuesta()
        {

        }

        public Respuesta(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        public Respuesta(string message)
        {
            Succeeded = false;
            Message = message;
        }
    }
}

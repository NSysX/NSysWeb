using System;
using System.Globalization;

namespace Application.Exceptions
{
    public class ExcepcionesDeAPI : Exception 
    {
        public ExcepcionesDeAPI() : base() { }

        // Otro constructor pero que reciba un msj
        public ExcepcionesDeAPI(string mensaje) : base(mensaje) { }

        public ExcepcionesDeAPI(string mensaje, params object[] argumentos) : base(String.Format(CultureInfo.CurrentCulture, mensaje, argumentos)){ }
    }
}

using System;

namespace Pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime fecha = DateTime.Now;
            var respuesta = fecha != default(DateTime);

            Console.WriteLine($"default(DateTime) = { respuesta }");
            Console.ReadKey();
        }
    }
}

using System;

namespace Pruebas
{
    class Program
    {
        static void Main(string[] args)
        {

            string frase = "The Statment Duplicate is (Casado) statment";

            int posicionInicial = frase.ToLower().IndexOf('(');

            Console.WriteLine($"hubicacion de inicio de parentesis = {posicionInicial}");
            Console.ReadKey();
        }
    }
}

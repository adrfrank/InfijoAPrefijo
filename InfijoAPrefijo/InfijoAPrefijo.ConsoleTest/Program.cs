using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfijoAPrefijo.Core;

namespace InfijoAPrefijo.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var convertidor = new ConvertidorInfijoAPrefijo();

            string infijo;

            Console.WriteLine("Ingresa la expresión infija: ");
            infijo = Console.ReadLine();
            try
            {
                Console.WriteLine("La expresión prefija es:  {0}", convertidor.Convertir(infijo));
            }
            catch (Exception ex)
            {
                Console.Write("Ocurrió un problema con la conversión: ");
                Console.WriteLine(ex.Message);
                Console.Write(ex.StackTrace);
            }
            Console.ReadKey();
        }
    }
}

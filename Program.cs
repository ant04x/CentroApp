using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMarAIzq
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion = -1;
            while (opcion != 0)
            {
                Console.WriteLine("Opciones:");
                Console.WriteLine("  1 => Administrar Grupos");
                Console.WriteLine("  2 => Administrar Alumnos");

                Console.Write("\nSeleccionar [Intro para salir]> ");
                string input = Console.ReadLine();

                // Salir
                if (input.Length == 0)
                {
                    opcion = 0;
                    break;
                }

                //Parsea a Int
                try
                {
                    opcion = (int)Convert.ChangeType(input, typeof(int));
                }
                catch
                {
                    Console.Error.WriteLine("ERROR: El valor \"" + input + "\" no es válido.\n");
                    continue;
                }

                switch (opcion)
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine();
                        VistaGrupo.Menu();
                        continue;
                    case 2:
                        Console.WriteLine();
                        VistaAlumno.Menu();
                        continue;
                    default:
                        Console.WriteLine("ERROR: El valor \"" + input + "\" no es válido.\n");
                        continue;
                }
            }
        }
    }
}

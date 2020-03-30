using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMarAIzq
{
    class VistaGrupo
    {
        public static void Menu()
        {
            int opcion = -1;
            while (opcion != 0)
            {
                Console.WriteLine("Administrar Grupos:");
                Console.WriteLine("  1 => Nuevo Grupo");
                Console.WriteLine("  2 => Modificar Grupo");
                Console.WriteLine("  3 => Eliminar Grupo");
                Console.WriteLine("  4 => Ver Todos");

                Console.Write("\nSeleccionar [Intro para salir]> ");
                string input = Console.ReadLine();

                // Salir
                if (input.Length == 0)
                    return;

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
                        NuevoGrupo();
                        continue;
                    case 2:
                        Console.WriteLine();
                        ModificarGrupo();
                        continue;
                    case 3:
                        Console.WriteLine();
                        EliminarGrupo();
                        continue;
                    case 4:
                        Console.WriteLine();
                        VerTodos();
                        continue;
                    default:
                        Console.WriteLine("ERROR: El valor \"" + input + "\" no es válido.\n");
                        continue;
                }
            }
        }

        private static void NuevoGrupo()
        {
            while (true)
            {
                int uiID = GetID();
                if (uiID == -2)
                {
                    Console.WriteLine();
                    return;
                }

                if (ServicioCentro.Servicio.BuscarGrupo(uiID) != null)
                {
                    Console.WriteLine("ERROR: Grupo " + uiID + " ya existe.");
                    continue;
                }

                string uiName = GetNombre();
                int uiCiclos = GetCiclos();
                if (uiCiclos == -2)
                    continue;
                else if (uiCiclos == 1)
                    ServicioCentro.Servicio.NuevoGrupo(uiID, uiName, true);
                else if (uiCiclos == 2)
                    ServicioCentro.Servicio.NuevoGrupo(uiID, uiName, false);
                else
                    Console.WriteLine("\nERROR INTERNO: Booleano imposible.\n");

                Console.WriteLine();
            }
        }

        private static void ModificarGrupo()
        {
            while (true)
            {
                int uiID = GetID();
                if (uiID == -2)
                {
                    Console.WriteLine();
                    return;
                }

                Grupo grupoDest = ServicioCentro.Servicio.BuscarGrupo(uiID);

                if (grupoDest == null)
                {
                    Console.WriteLine("ERROR: Grupo " + uiID + " no encontrado.");
                    continue;
                }

                string uiName = GetNombre();
                int uiCiclos = GetCiclos();

                if (uiName != null)
                    ServicioCentro.Servicio.ModificarGrupo(uiID, "Nombre", uiName);
                if (uiCiclos == -2)
                    continue;
                else if (uiCiclos == 1)
                    ServicioCentro.Servicio.ModificarGrupo(uiID, "Ciclos", true);
                else if (uiCiclos == 2)
                    ServicioCentro.Servicio.ModificarGrupo(uiID, "Ciclos", false);
                else
                    Console.WriteLine("\nERROR INTERNO: Booleano imposible.\n");

                Console.WriteLine();
            }
        }

        public static void EliminarGrupo()
        {
            while (true)
            {
                int uiID = GetID();
                if (uiID == -2)
                {
                    Console.WriteLine();
                    return;
                }

                if (ServicioCentro.Servicio.BuscarGrupo(uiID) == null)
                {
                    Console.WriteLine("ERROR: Grupo " + uiID + " no existe.");
                    continue;
                }

                ServicioCentro.Servicio.EliminarGrupo(uiID);

                Console.WriteLine();
            }
        }

        public static void VerTodos()
        {
            List<Grupo> grupos = ServicioCentro.Servicio.Grupos;

            Console.WriteLine("Nombre" + "\t" + "ID" + "\t" + "Ciclos");
            if (grupos == null)
                return;
            Grupo grupoSel;
            for (int i = 0; i < grupos.Count; i++)
            {
                grupoSel = grupos[i];
                Console.Write(grupoSel.Nombre + "\t" + grupoSel.Id.ToString() + "\t");
                if (grupoSel.Ciclos == true)
                    Console.WriteLine("Sí" + "\t");
                else
                    Console.WriteLine("No" + "\t");
            }
            Console.WriteLine();
        }

        private static int GetID()
        {
            while (true)
            {
                Console.Write("ID del Grupo [Intro para salir]> ");
                string input = Console.ReadLine();

                // Para salir
                if (input.Length == 0)
                    return -2;

                //Parsea a Int
                try
                {
                    return (int)Convert.ChangeType(input, typeof(int));
                }
                catch
                {
                    Console.WriteLine("\nERROR: El ID \"" + input + "\" no es numérico.\n");
                    continue;
                }
            }
        }

        private static string GetNombre()
        {
            while (true)
            {
                Console.Write("Cambiar nombre del Grupo [Intro para saltar]> ");
                string dato = Console.ReadLine();
                if (dato.Length == 0)
                    return null;
                return dato;
            }
        }

        private static int GetCiclos()
        {
            while (true)
            {
                Console.Write("Cambiar ciclos (Sí [s] / No [n]) [Intro para saltar]> ");
                string dato = Console.ReadLine();
                if (dato.Equals("s") || dato.Equals("S") || dato.Equals("Sí") || dato.Equals("sí") || dato.Equals("Si") || dato.Equals("si"))
                    return 1;
                else if (dato.Equals("n") || dato.Equals("N") || dato.Equals("no") || dato.Equals("No"))
                    return 2;
                else if (dato.Length == 0)
                    return -2;
                Console.WriteLine("ERROR: \"" + dato + "\" no es una expresión válida.");
            }
        }
    }
}

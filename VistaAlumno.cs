using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMarAIzq
{
    class VistaAlumno
    {
        public static void Menu()
        {
            int opcion = -1;
            while (opcion != 0)
            {
                Console.WriteLine("Administrar Alumnos:");
                Console.WriteLine("  1 => Nuevo Alumno");
                Console.WriteLine("  2 => Modificar Alumno");
                Console.WriteLine("  3 => Asignar a Grupo");
                Console.WriteLine("  4 => Eliminar Alumno");
                Console.WriteLine("  5 => Ver Todos");

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
                        NuevoAlumno();
                        continue;
                    case 2:
                        Console.WriteLine();
                        ModificarAlumno();
                        continue;
                    case 3:
                        Console.WriteLine();
                        AsignarAlGrupo();
                        continue;
                    case 4:
                        Console.WriteLine();
                        EliminarAlumno();
                        continue;
                    case 5:
                        Console.WriteLine();
                        VerTodos();
                        continue;
                    default:
                        Console.WriteLine("ERROR: El valor \"" + input + "\" no es válido.\n");
                        continue;
                }
            }
        }

        private static void NuevoAlumno()
        {
            while (true)
            {
                int uiID = GetID();
                if (uiID == -2)
                {
                    Console.WriteLine();
                    return;
                }

                if (ServicioCentro.Servicio.BuscarAlumno(uiID) != null)
                {
                    Console.WriteLine("ERROR: Alumno " + uiID + " ya existe.");
                    continue;
                }

                string uiName = GetNombre();
                DateTime uiFechaNac = GetFechaNac();

                ServicioCentro.Servicio.NuevoAlumno(uiID, uiName, uiFechaNac);

                Console.WriteLine();
            }
        }

        private static void ModificarAlumno()
        {
            while (true)
            {
                int uiID = GetID();
                if (uiID == -2)
                {
                    Console.WriteLine();
                    return;
                }

                if (ServicioCentro.Servicio.BuscarAlumno(uiID) == null)
                {
                    Console.WriteLine("ERROR: Alumno " + uiID + " no encontrado.");
                    continue;
                }

                string uiName = GetNombre();
                DateTime uiFechaNac = GetFechaNac();

                if (uiName != null)
                    ServicioCentro.Servicio.ModificarAlumno(uiID, "Nombre", uiName);
                if (uiFechaNac != DateTime.MinValue)
                    ServicioCentro.Servicio.ModificarAlumno(uiID, "FechaNac", uiFechaNac);

                Console.WriteLine();
            }
        }

        public static void AsignarAlGrupo()
        {
            while (true)
            {
                int uiID;
                // Bucle de comprobación de ID Alumno
                while (true)
                {
                    uiID = GetID();
                    if (uiID == -2)
                    {
                        Console.WriteLine();
                        return;
                    }

                    if (ServicioCentro.Servicio.BuscarAlumno(uiID) == null)
                    {
                        Console.WriteLine("ERROR: Alumno " + uiID + " no encontrado.");
                        continue;
                    }
                    break;
                }

                int uiIDGrupo;
                while (true)
                {
                    uiIDGrupo = GetIDGrupo();
                    if (uiIDGrupo == -2)
                    {
                        Console.WriteLine();
                        return;
                    }

                    if (ServicioCentro.Servicio.BuscarGrupo(uiIDGrupo) == null)
                    {
                        Console.WriteLine("ERROR: Grupo " + uiIDGrupo + " no encontrado.");
                        continue;
                    }
                    break;
                }

                ServicioCentro.Servicio.AsignarAlGrupo(uiID, uiIDGrupo);

                Console.WriteLine();
            }
        }

        public static void EliminarAlumno()
        {
            while (true)
            {
                int uiID = GetID();
                if (uiID == -2)
                {
                    Console.WriteLine();
                    return;
                }

                if (ServicioCentro.Servicio.BuscarAlumno(uiID) == null)
                {
                    Console.WriteLine("ERROR: Alumno " + uiID + " no existe.");
                    continue;
                }

                ServicioCentro.Servicio.EliminarAlumno(uiID);

                Console.WriteLine();
            }
        }

        public static void VerTodos()
        {
            List<Alumno> alumnos = ServicioCentro.Servicio.Alumnos;

            Console.WriteLine("Nombre" + "\t" + "ID" + "\t" + "FechaNac" + "\t" + "Grupo" + "\t" + "IDG");
            if (alumnos == null)
                return;
            Alumno alumnoSel;
            for (int i = 0; i < alumnos.Count; i++)
            {
                alumnoSel = alumnos[i];
                Console.Write(alumnoSel.Nombre + "\t" + alumnoSel.Id.ToString() + "\t");
                if (alumnoSel.FechaNac.Equals(DateTime.MinValue))
                    Console.Write("null      " + "\t");
                else
                    Console.Write(alumnoSel.FechaNac.ToString("dd/MM/yyyy") + "\t");
                if (alumnoSel.Grupo == null)
                    Console.WriteLine("null" + "\t" + "null");
                else if (alumnoSel.Grupo.Nombre == null)
                    Console.WriteLine(alumnoSel.Grupo.Nombre + "\t" + "null");
                else
                    Console.WriteLine(alumnoSel.Grupo.Nombre + "\t" + alumnoSel.Grupo.Id.ToString());
            }
            Console.WriteLine();
        }

        private static int GetID()
        {
            while (true)
            {
                Console.Write("ID del Alumno [Intro para salir]> ");
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

        private static int GetIDGrupo()
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
                Console.Write("Cambiar nombre del Alumno [Intro para saltar]> ");
                string dato = Console.ReadLine();
                if (dato.Length == 0)
                    return null;
                return dato;
            }
        }

        private static DateTime GetFechaNac()
        {
            while (true)
            {
                Console.Write("Cambiar fecha de nacimiento del Alumno (dd/MM/yyyy) [Intro para saltar]> ");
                string expFecha = Console.ReadLine();
                if (expFecha.Length == 0)
                    return DateTime.MinValue;

                //Parsea a DateTime
                try
                {
                    return (DateTime)Convert.ChangeType(expFecha, typeof(DateTime));
                }
                catch
                {
                    Console.WriteLine("\nERROR: El formato de fecha \"" + expFecha + "\" no es válido.\n");
                    continue;
                }
            }
        }
    }
}

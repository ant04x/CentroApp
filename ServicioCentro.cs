using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace LMarAIzq
{
    class ServicioCentro : IServicioCentro
    {
        private List<Grupo> grupos;

        public List<Alumno> Alumnos
        {
            get => alumnos;
        }

        private List<Alumno> alumnos;

        public List<Grupo> Grupos
        {
            get => grupos;
        }

        // Reemplaza getServicioSingleton y al atributo.
        private static ServicioCentro servicio;
        public static ServicioCentro Servicio
        {
            get
            {
                if (servicio == null)
                    servicio = new ServicioCentro();
                return servicio;
            }
        }

        public void AsignarAlGrupo(int idAlumno, int idGrupo)
        {
            Alumno alumnoSel = BuscarAlumno(idAlumno);
            if (alumnoSel == null)
            {
                Console.WriteLine("ERROR: Alumno " + idAlumno + " no encontrado.");
                return;
            }

            Grupo grupoSel = BuscarGrupo(idGrupo);
            if (grupoSel == null)
            {
                Console.WriteLine("ERROR: Grupo " + idAlumno + " no encontrado.");
                return;
            }

            alumnoSel.Grupo = grupoSel;
        }

        public void EliminarAlumno(int id)
        {
            Alumno alumnoSel = BuscarAlumno(id);
            if (alumnoSel == null)
            {
                Console.WriteLine("ERROR: Alumno " + id + " no encontrado.");
                return;
            }

            alumnos.Remove(alumnoSel);

            if (alumnos.Count < 0)
                alumnos = null;
        }

        public void EliminarGrupo(int id)
        {
            Grupo grupoSel = BuscarGrupo(id);
            if (grupoSel == null)
            {
                Console.WriteLine("ERROR: Grupo " + id + " no encontrado.");
                return;
            }

            grupos.Remove(grupoSel);

            if (grupos.Count < 0)
                grupos = null;
        }

        public void ModificarAlumno(int id, string nombreProp, object value)
        {
            Alumno alumnoSel = BuscarAlumno(id);
            if (alumnoSel == null)
            {
                Console.WriteLine("ERROR: Alumno " + id + " no encontrado.");
                return;
            }

            // Reflexión para modificar propiedad por propiedad sin crear varios métodos.
            try
            {
                Type type = alumnoSel.GetType();
                PropertyInfo infoPropiedad = type.GetProperty(nombreProp);
                infoPropiedad.SetValue(alumnoSel, value);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return;
            }
        }

        public void ModificarGrupo(int id, string nombreProp, object value)
        {
            Grupo grupoSel = BuscarGrupo(id);
            if (grupoSel == null)
            {
                Console.WriteLine("ERROR: Grupo " + id + " no encontrado.");
                return;
            }

            // Reflexión para modificar propiedad por propiedad sin crear varios métodos.
            try
            {
                Type type = grupoSel.GetType();
                PropertyInfo infoPropiedad = type.GetProperty(nombreProp);
                infoPropiedad.SetValue(grupoSel, value);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return;
            }
        }

        public void NuevoAlumno(int nId, string nNombre, DateTime nFechaN)
        {
            /* COMPROBAR
            DateTime fechaConv = (DateTime)Convert.ChangeType(nFechaN, typeof(DateTime));
            */

            if (alumnos == null)
                alumnos = new List<Alumno>();
            alumnos.Add(new Alumno(nId, nNombre, nFechaN));
        }

        public void NuevoGrupo(int nId, string nNombre, bool nCiclos)
        {
            /*
            bool ciclosConv;
            if (bool.TryParse(nCiclos, out ciclosConv))
            {
                Debug.WriteLine("ERROR: " + nCiclos + " no es una expresión válida, los ciclos debe ser true/1 o false/0.");
                return;
            }
            */

            if (grupos == null)
                grupos = new List<Grupo>();
            grupos.Add(new Grupo(nId, nNombre, nCiclos));
        }

        // Busca el alumno por ID
        internal Alumno BuscarAlumno(int id)
        {
            if (alumnos == null)
                return null;

            for (int i = 0; i < alumnos.Count; i++)
                if (alumnos[i].Id == id)
                    return alumnos[i];
            return null;
        }

        // Busca el grupo por ID
        internal Grupo BuscarGrupo(int id)
        {
            if (grupos == null)
                return null;

            for (int i = 0; i < grupos.Count; i++)
                if (grupos[i].Id == id)
                    return grupos[i];
            return null;
        }
    }
}

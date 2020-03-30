using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMarAIzq
{
    interface IServicioCentro
    {
        // Reemplazan a ObtenerAlumnos y Grupos
        List<Alumno> Alumnos { get; }
        List<Grupo> Grupos { get; }

        // Para no sobreescribir los datos, se cambia la propiedad por nombre
        void NuevoAlumno(int nId, string nNombre, DateTime nFechaN);
        void NuevoGrupo(int nid, string nNombre, bool nCiclos);

        void AsignarAlGrupo(int idAlumno, int idNuevoGrupo);

        void ModificarAlumno(int id, string propName, object value);
        void ModificarGrupo(int id, string propName, object value);

        void EliminarAlumno(int id);
        void EliminarGrupo(int id);
    }
}

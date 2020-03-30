using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMarAIzq
{
    class Alumno
    {

        public Alumno(int nId, string nNombre, DateTime nFechaNac)
        {
            id = nId;
            Nombre = nNombre;
            FechaNac = nFechaNac;
        }

        private int id;

        // Equivalente a los Getters y Setters
        public int Id
        {
            get { return id; }
            // El ID no debe cambiarse
        }

        private string nombre;

        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        private DateTime fechaNac;

        public DateTime FechaNac
        {
            get => fechaNac;
            set => fechaNac = value;
        }

        private Grupo grupo;

        public Grupo Grupo
        {
            get => grupo;
            set => grupo = value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMarAIzq
{
    class Grupo
    {
        public Grupo(int nId, string nNombre, bool nCiclos)
        {
            id = nId;
            Nombre = nNombre;
            Ciclos = nCiclos;
        }

        private int id;

        // Equivalente a los Getters y Setters
        public int Id
        {
            get => id;
            // El ID no debe cambiarse
        }

        private string nombre;

        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        private bool ciclos;

        public bool Ciclos
        {
            get => ciclos;
            set => ciclos = value;
        }
    }
}

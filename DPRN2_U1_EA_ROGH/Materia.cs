using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPRN2_U1_EA_ROGH
{
    class Materia
    {

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                Contract.Ensures(!String.IsNullOrWhiteSpace(value));
                nombre = value;
            }
        }


        public Materia(string nombre)
        {
            this.Nombre = nombre;
        }

        public Materia(string nombre, int calificacion)
        {
            this.Nombre = nombre;
        }

        ~Materia()
        {
            this.nombre = null;
        }


    }
}

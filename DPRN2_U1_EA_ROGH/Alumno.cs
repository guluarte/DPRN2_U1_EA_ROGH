using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPRN2_U1_EA_ROGH
{
    class Alumno
    {
        private Dictionary<Materia, int> calificaciones = new Dictionary<Materia, int>();

        public Dictionary<Materia, int> Calificaciones
        {
            get { return calificaciones; }
            set
            {
                Contract.Ensures(value != null);
                calificaciones = value;
            }
        }

        private List<Materia> materias = new List<Materia>();

        public List<Materia> Materias
        {
            get
            {
                return materias;
                
            }
            private set
            {
                materias = value;
            }
        }

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

        private int edad;

        public int Edad
        {
            get { return edad; }
            set
            {
                if (value < 0 && value > 120)
                {
                    throw new ArgumentOutOfRangeException("Edad no valida");
                }
                Contract.EndContractBlock();
                edad = value;
            }
        }

        public Alumno(string nombre)
        {
            this.Nombre = nombre;
        }

        public Alumno(string nombre, int edad)
        {
            this.Nombre = nombre;
            this.Edad = edad;
            this.Materias = new List<Materia>();
        }

        /*
         * Regresa verdadero si la materia fue agregada correctamente
         * falso si la materia ya era cursada por el alumno
         * */
        public bool AgregarMateria(Materia materia)
        {
            if (materias.IndexOf(materia) >= 0)
            {
                return false;
            }
            else
            {
                materias.Add(materia);
                return true;
            }
        }

        /*
         * Quita una materia del alumno
         * */
        public bool QuitarMateria(Materia materia)
        {
            if (materias.IndexOf(materia) >= 0)
            {
                materias.Remove(materia);
                return true;
            }
            else
            {
                return false;
            }           
        }

        public void SetCalificacion(Materia materia, int calificacion)
        {
            Contract.Ensures(calificacion >= 0 && calificacion <= 100);
            Contract.Ensures(materia != null);
            AgregarMateria(materia);
            if (calificaciones.ContainsKey(materia))
            {
                calificaciones[materia] = calificacion;
            }
            else
            {
                calificaciones.Add(materia, calificacion);
            }
            
        }

        ~Alumno()
        {
            materias = null;
            nombre = null;
            edad = 0;
        }

    }
}

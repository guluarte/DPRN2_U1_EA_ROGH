using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPRN2_U1_EA_ROGH
{
    class Escuela
    {
        private List<Materia> materias = null;

        public List<Materia> Materias
        {
            get { return materias; }
            set { materias = value; }
        }

        private List<Alumno> alumnos = null;

        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { alumnos = value; }
        }

        public Escuela()
        {
            materias = new List<Materia>();
            alumnos = new List<Alumno>();
        }

        public Escuela(List<Materia> materias)
        {
            this.Materias = materias;
        }

        public Escuela(List<Alumno> alumnos)
        {
            this.Alumnos = alumnos;
        }

        public Escuela(List<Alumno> alumnos, List<Materia> materias)
        {
            this.Alumnos = alumnos;
            this.Materias = materias;
        }

        public bool AgregarAlumno(Alumno alumno)
        {
            if (Alumnos.IndexOf(alumno) < 0 && BusrcarAlumno(alumno.Nombre) == null)
            {
                Alumnos.Add(alumno);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AgregarAlumno(List<Alumno> alumnos)
        {
            foreach (var alumno in alumnos)
            {
                AgregarAlumno(alumno);
            }
        }

        public bool AgregarMateria(Materia materia)
        {
            if (Materias.IndexOf(materia) < 0 && BuscarMateria(materia.Nombre) == null )
            {
                Materias.Add(materia);
                return true;
            }
            return false;
           
        }
        public void AgregarMateria(List<Materia> materias)
        {
            foreach (var materia in materias)
            {
                AgregarMateria(materia);
            }
            
        }


        public bool BajaMateria(string nombreMateria)
        {
            Materia materia;
            if ((materia = BuscarMateria(nombreMateria)) != null)
            {
                return BajaMateria(materia);
            }

            return false;
        }

        public bool BajaMateria(Materia materia)
        {
            if (Materias.IndexOf(materia) >= 0)
            {
                Materias.Remove(materia);
                return true;
            }

            return false;
        }

        public bool BajaAlumno(Alumno alumno)
        {
            if (Alumnos.IndexOf(alumno) >= 0)
            {
                Alumnos.Remove(alumno);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool BajaAlumno(string nombreAlumno)
        {
            Alumno alumno = BusrcarAlumno(nombreAlumno);
            if (alumno != null)
            {
                return BajaAlumno(alumno);
            }
            return false;
        }


        /*
         * Busca la materia por nombre,
         * en caso de encontrarla regresa una referencia
         * y en caso contrario un apuntador vacio
         * tener cuidado de un NullPointerException
         * */
        public Materia BuscarMateria(string nombre)
        {
            var resultado = from mat in Materias where mat.Nombre.ToLower() == nombre.ToLower() select mat;
            return resultado.FirstOrDefault();
        }
        /*
         * Busca el alumno por nombre,
         * en caso de encontrarlo regresa una referencia
         * y en caso contrario un apuntador vacio
         * tener cuidado de un NullPointerException
         * */
        public Alumno BusrcarAlumno(string nombre)
        {
            var resultado = from al in Alumnos where al.Nombre.ToLower() == nombre.ToLower() select al;
            return resultado.FirstOrDefault();
        }
        ~Escuela()
        {
            this.Alumnos = null;
            this.Materias = null;
        }


    }
}

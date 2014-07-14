using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DPRN2_U1_EA_ROGH
{
    class BoletaCalificaciones
    {
        private Alumno alumno;

        public BoletaCalificaciones(Alumno alumno)
        {
            this.alumno = alumno;
        }

        public void imprimirBoleta()
        {
            String separador = new String('#', 50);
            Console.WriteLine("BOLETA DE CALIFICACIONES");
            Console.WriteLine("Alumno: " + alumno.Nombre);
            Console.WriteLine(separador);
            string txtMateria = " MATERIA";
            string txtCalificacion = "CALIFICACION";
            Console.WriteLine("{0,-20}{1,-3}", txtMateria, txtCalificacion);
            Dictionary<Materia, int> materiasAprobadas = GetMateriasAprobadas();
            if (materiasAprobadas != null)
            {
                foreach (Materia materia in materiasAprobadas.Keys)
                {
                    Console.WriteLine("{0,-20}{1, 5}", materia.Nombre, alumno.Calificaciones[materia]);
                }
            }
            imprimirReprobadas();
            Console.WriteLine(new string('-',50));
            Console.WriteLine("Promedio: " + GetPromedio());
            Console.WriteLine(separador);
        }

        public void imprimirReprobadas()
        {
            Dictionary<Materia, int> materiasReprobadas = GetMateriasReprobadas();
            if (materiasReprobadas != null && materiasReprobadas.Count > 0)
            {
                Console.WriteLine("Materias reprobadas:");
                foreach (Materia materiasReprobada in materiasReprobadas.Keys)
                {
                    Console.WriteLine("{0,-20}{1, 5}", materiasReprobada.Nombre, alumno.Calificaciones[materiasReprobada]);
                }
            }
        }
        /*
         * Obtiene una lista de las materias aprobadas por el alumno
         */
        public Dictionary<Materia, int> GetMateriasAprobadas()
        {
            var expresion = alumno.Calificaciones.Where(k => k.Value >= 60).Select(m => m).ToDictionary(mc => mc.Key, mc => mc.Value);
            return expresion;
        }
        /*
         * Obtiene una lista de las materias reprobadas por el alumno
         * */
        public Dictionary<Materia, int> GetMateriasReprobadas()
        {
            var expresion = alumno.Calificaciones.Where(k => k.Value <= 60).Select(m => m).ToDictionary(mc => mc.Key, mc => mc.Value);
            return expresion;
        }

        /*
         * Obtiene el promedio del alumno
         * */
        public double GetPromedio()
        {
            if (alumno.Materias.Count > 0)
            {
                return alumno.Calificaciones.Average(materia => materia.Value);
            }
            return 0;
        }

        ~BoletaCalificaciones()
        {
            this.alumno = null;
        }
    }
}

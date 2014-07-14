using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPRN2_U1_EA_ROGH
{
    class Program
    {
        private Escuela escuela = new Escuela();

        static void Main(string[] args)
        {
            Program programa = new Program();
        }

        public Program()
        {
            populateData();
            Menu();
        }

        public void Menu()
        {
            string top = new string('#',20);
            Console.WriteLine(top);
            Console.WriteLine(Environment.NewLine + "MENU:");
            Console.WriteLine("1. ALTA ALUMNO");
            Console.WriteLine("2. BAJA ALUMNO");
            Console.WriteLine("3. VER ALUMNOS");
            Console.WriteLine("4. VER BOLETA ALUMNO");

            
            Console.WriteLine("5. ALTA MATERIA");
            Console.WriteLine("6. BAJA MATERIA");
            Console.WriteLine("7. VER MATERIAS");

            Console.WriteLine("8. CALIFICAR ALUMNO");

            Console.WriteLine("9. SALIR");
            int seleccion = (int) leerValorNumerico("OPCION: ");



            switch (seleccion)
            {
                case 1: // ALTA ALUMNO
                {
                    altaAlumno();
                    break;
                }
                case 2: // BAJA ALUMNO
                {
                    bajaAlumno();
                    break;
                }
                case 3: // VER ALUMNOS
                {
                    verAlumnos();
                    break;
                }
                case 4:
                {
                    verBoleta();
                    break;
                }
                case 5:
                {
                    AltaMateria();

                    break;
                }
                case 6:
                {
                    BajaMateria();
                    break;
                }
                case 7:
                {
                    ListaMaterias();
                    break;
                }
                case 8:
                {
                    CalificarAlumno();

                    break;
                }
                case 9:
                {
                    Environment.Exit(0);
                    break;
                }
            }

            Menu();
        }

        private void CalificarAlumno()
        {
            //calificar
            string nombreAlumno = leerValor("NOMBRE DEL ALUMNO:");
            Alumno alumno = escuela.BusrcarAlumno(nombreAlumno);
            if (alumno == null)
            {
                Console.WriteLine("NO SE ENCONTRO EL ALUMNO");
                return;
            }
            string nombreMateria = leerValor("NOMBRE DE LA MATERIA:");
            Materia materia = escuela.BuscarMateria(nombreMateria);
            if (materia == null)
            {
                Console.WriteLine("NO SE ENCONTRO LA MATERIA");
            }
            int calificacion = (int) leerValorNumerico("CALIFICACION:");

            alumno.SetCalificacion(materia, calificacion);

            Console.WriteLine("ALUMNO CALIFICADO");
            BoletaCalificaciones boleta = new BoletaCalificaciones(alumno);
            boleta.imprimirBoleta();
        }

        private void ListaMaterias()
        {
            Console.WriteLine("LISTA DE MATERIAS:");
            foreach (var materia in escuela.Materias)
            {
                Console.WriteLine("{0}", materia.Nombre);
            }
        }

        private void BajaMateria()
        {
            Console.WriteLine("BAJA DE MATERIA");
            string nombreMateria = leerValor("NOMBRE DE LA MATERIA:");
            if (escuela.BajaMateria(nombreMateria))
            {
                Console.WriteLine("MATERIA DADA DE BAJA");
            }
            else
            {
                Console.WriteLine("ERROR AL DAR DE BAJA LA MATERIA");
            }
            return;
        }

        private void AltaMateria()
        {
            string nombreMateria = leerValor("NOMBRE DE LA MATERIA: ");
            Materia materia = new Materia(nombreMateria);
            if (escuela.AgregarMateria(materia))
            {
                Console.WriteLine("MATERIA AGREGADA CON EXITO");
            }
            else
            {
                Console.WriteLine("LA MATERIA YA ESTABA DADA DE ALTA");
            }
        }

        private void verBoleta()
        {
//ver boleta
            string nombre = leerValor("NOMBRE DEL ALUMNO: ");
            Alumno alumno = escuela.BusrcarAlumno(nombre);
            if (alumno != null)
            {
                BoletaCalificaciones boleta = new BoletaCalificaciones(alumno);
                boleta.imprimirBoleta();
            }
            else
            {
                Console.WriteLine("NO SE ECONTRO EL ALUMNO.");
            }
        }

        private void verAlumnos()
        {
            Console.WriteLine("LISTADO DE ALUMNOS:");
            foreach (Alumno alumno in escuela.Alumnos)
            {
                Console.WriteLine("NOMBRE: {0} EDAD: {1}", alumno.Nombre, alumno.Edad);
            }
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        private void bajaAlumno()
        {
            Console.WriteLine("BAJA DE ALUMNO");
            string nombre = leerValor("NOMBRE DEL ALUMNO :");
            Alumno alumno = (from al in escuela.Alumnos where al.Nombre.ToLower() == nombre.ToLower() select al).FirstOrDefault();
            if (alumno != null)
            {
                escuela.Alumnos.Remove(alumno);
                Console.WriteLine("ALUMNO DADO DE BAJA");
            }
            else
            {
                Console.WriteLine("NO SE ENCONTRO EL ALUMNO");
            }

        }

        private void altaAlumno()
        {
            string nombre = leerValor("NOMBRE DEL ALUMNO: ");
            int edad = (int) leerValorNumerico("EDAD: ");
            Alumno alumno = new Alumno(nombre, edad);
            if (escuela.AgregarAlumno(alumno))
            {
                Console.WriteLine(" ALUMNO AGREGADO CON EXITO");
            }
            else
            {
                Console.WriteLine(" EL ALUMNO YA ESTABA DADO DE ALTA");
            }
        }

        private void populateData()
        {
            List<Materia> materias = new List<Materia>()
            {
                new Materia("Programacion NET II"),
                new Materia("Programacion Orientada a Objetos III"),
                new Materia("Español"),
                new Materia("Matematicas"),
            };

            escuela.AgregarMateria(materias);

            List<Alumno> alumnos = new List<Alumno>()
            {
                new Alumno("Rodolfo Guluarte Hale", 28),
                new Alumno("Prueba", 50),
            };

            escuela.AgregarAlumno(alumnos);
        }


        public static String leerValor(String promt)
        {
            String valorIngresado = "";
            bool cadenaEvaluaAVacia = true;
            while (cadenaEvaluaAVacia)
            {
                Console.Write(" {0}", promt);
                valorIngresado = Console.ReadLine();

                cadenaEvaluaAVacia = String.IsNullOrWhiteSpace(valorIngresado);
                if (cadenaEvaluaAVacia)
                {
                    Console.WriteLine("Por favor ingresa un valor");
                }
            }

            return valorIngresado;

        }
        public static Double leerValorNumerico(String promt)
        {
            Double valorIngresado = 0;
            while (valorIngresado <= 0)
            {
                try
                {
                    valorIngresado = Double.Parse(leerValor(promt));
                }
                catch(Exception ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                    Console.WriteLine("El valor no es valido, ingresa un valor de nuevo");

                }
            }


            return valorIngresado;
        }


    }
}

using EduRecuperacionC.Controladores;
using EduRecuperacionC.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EduRecuperacionC.Servicios
{

    /// <summary>
    /// Clase que implementa la operativa interfaz
    /// </summary>
    internal class OperativaImplementacion : OperativaInterfaz
    {

        MenuInterfaz mi = new MenuImplementacion();
        FicherosInterfaz fi = new FicherosImplementacion();

        public void darAlta()
        {

           
            
                string respuesta;
                do
                {
                    AlumnoDto alumno = new AlumnoDto();

                    alumno.IdAlumno = generarId();
                    Console.WriteLine("Introduzca su nombre");
                    alumno.NombreAlumno = Console.ReadLine();
                    Console.WriteLine("Introduzca su primer apellido");
                    alumno.Apellido1Alumno = Console.ReadLine();
                    Console.WriteLine("Introduzca su segundo apellido");
                    alumno.Apellido2Alumno = Console.ReadLine();
                    Console.WriteLine("Introduzca su DNI");
                    alumno.DNI1 = Console.ReadLine();
                    Console.WriteLine("Introduzca su direccion");
                    alumno.Direccion = Console.ReadLine();
                    Console.WriteLine("Introduzca su telefono");
                    alumno.Telefono = Console.ReadLine();
                    Console.WriteLine("Introduzca su email");
                    alumno.Email = Console.ReadLine();

                    Program.listaAlumnos.Add(alumno);

                    Console.WriteLine("¿Quieres agregar un nuevo alumno?: s/n");
                    respuesta = Console.ReadLine();

                } while (respuesta.Equals("s"));
            

            
        }


        public void borrarAlumno() {

            Console.WriteLine("Introduzca el dni del alumno a borrar");
            string dniABorrar = Console.ReadLine();
            bool borrar = false;
            string respuesta;

            do
            {
                AlumnoDto aux = new AlumnoDto();
                foreach (AlumnoDto alumno in Program.listaAlumnos)
                {
                    if (dniABorrar.Equals(alumno.DNI1))
                    {
                        aux = alumno;
                        borrar = true;
                        break;
                    }
                   
                    
                }
                if(borrar == true)
                {
                    Program.listaAlumnos.Remove(aux);
                }
                else
                {
                    Console.WriteLine("El DNI introducido no corresponde con ninguno");

                }

                Console.WriteLine("¿Quieres seguir borrando otro alumno?: s/n ");
                respuesta = Console.ReadLine();

            } while (respuesta.Equals("s"));
            
        
        }

        public void mostrarAlumnos()
        {
            foreach(AlumnoDto alumno in Program.listaAlumnos) {
                
                Console.WriteLine(alumno);

                } 
        }


        public void modificarAlumno()
        {


            foreach(AlumnoDto alumno1 in Program.listaAlumnos) {

            Console.WriteLine(alumno1);
            }



            Console.WriteLine("introduzca el DNI del usuario que quieres modificar");
            string dniIntroducido = Console.ReadLine();
            int opcionUsuario;
            string respuesta;
            bool cerrarMenu = false;


            do
            {
                try
                {

                    foreach (AlumnoDto alumno in Program.listaAlumnos)
                    {


                        if (alumno.DNI1.Equals(dniIntroducido))
                        {

                            opcionUsuario = mi.menuYSeleccionModificacion();




                            switch (opcionUsuario)
                            {

                                case 0:
                                    Console.WriteLine("Has seleccionado cerrar menu");
                                    cerrarMenu = true;
                                    break;


                                case 1:
                                    Console.WriteLine("Introduzca el nuevo nombre");
                                    alumno.NombreAlumno = Console.ReadLine();
                                    break;

                                case 2:

                                    Console.WriteLine("Introduzca primer apellido");
                                    alumno.Apellido1Alumno = Console.ReadLine();
                                    break;

                                case 3:
                                    Console.WriteLine("Introduzca segundo apellido");
                                    alumno.Apellido2Alumno = Console.ReadLine();
                                    break;

                                case 4:

                                    Console.WriteLine("Introduzca la direccion");
                                    alumno.Direccion = Console.ReadLine();
                                    break;

                                case 5:
                                    Console.WriteLine("Introduzca el telefono");
                                    alumno.Telefono = Console.ReadLine();
                                    break;

                                case 6:

                                    Console.WriteLine("Introduzca el email");
                                    alumno.NombreAlumno = Console.ReadLine();
                                    break;

                                default:
                                    Console.WriteLine("La opcion introducida no es correcta");
                                    break;


                            }

                        }
                    }
                }catch(Exception ex) {

                    fi.escribirFichero("Se ha producido un error en subMenu de modificacion de alumnos" +ex.Message);
                    Console.WriteLine("Se ha producido un error, intentelo más tarde");

                        }
            } while (!cerrarMenu) ;

            
            
        }




        /// <summary>
        /// metodo que se encarga de autogenerar un id
        /// </summary>
        /// <returns></returns>
        private long generarId()
        {
            long nuevoId;
            int tamanioLista = Program.listaAlumnos.Count;

             if( tamanioLista > 0)
            {
                nuevoId = Program.listaAlumnos[tamanioLista - 1].IdAlumno + 1;
            }
            else
            {
                nuevoId = 1;
            }
             return nuevoId;
        }
    }
}

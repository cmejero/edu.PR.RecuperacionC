using EduRecuperacionC.Dtos;
using EduRecuperacionC.Servicios;
using EduRecuperacionC.Util;

namespace EduRecuperacionC.Controladores
{
    /// <summary>
    /// Clase princicpal de la aplicacion
    /// </summary>
    internal class Program
    {
        static public string rutaCarpetaLog = "C:\\Users\\Carlos\\source\\repos\\carpetaLog\\";
        static public string  rutaFicheroLog = String.Concat(rutaCarpetaLog, Utilidades.crearNombreLog());
        static public List<AlumnoDto> listaAlumnos = new List<AlumnoDto>();
        static public string rutaFicheroAlumno = "C:\\Users\\Carlos\\source\\repos\\carpetaLog\\ficheroAlumno.txt";

        /// <summary>
        /// metodo principal de entrada de la aplicación
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            
            MenuInterfaz mi = new MenuImplementacion();
            FicherosInterfaz fi = new FicherosImplementacion();
            OperativaInterfaz oi = new OperativaImplementacion();
            int opcionUsuario;

            bool cerrarMenu = true;

            fi.leerFichero();

            do
            {
                try
                {
                    opcionUsuario = mi.menuYSeleccionPrincipal();

                    switch (opcionUsuario)
                    {

                        case 0:
                            
                            fi.escribirFichero("El usuario ha seleccionado cerrar menu");
                           
                            Console.WriteLine("Has seleccionado cerrar menu");
                            fi.escribirAlumnos();
                            cerrarMenu = false;
                            
                            break;

                        case 1:
                            
                            fi.escribirFichero("El usuario ha seleccionado dar alta alumno");
                            oi.darAlta();
                            Console.WriteLine("Has seleccionado dar alta alumno");

                            break;
                        case 2:
                            Console.WriteLine("Has seleccionado borrar alumno");
                            fi.escribirFichero("El usuario ha seleccionado borrar alumno");
                            oi.borrarAlumno();
                            break;

                        case 3:
                            Console.WriteLine("Has seleccionado mostrar alumnos");
                            fi.escribirFichero("El usuario ha seleccionado mostrar alumnos");
                            oi.mostrarAlumnos();
                            break;

                        case 4:
                            Console.WriteLine("Has seleccionado modificar alumnos");
                            fi.escribirFichero("El usuario ha seleccionado modificar alumnos");
                            oi.modificarAlumno();
                            break;

                        

                        default:                           
                            fi.escribirFichero("El usuario ha seleccionado una opcion incorrecta en menu principal");                           
                            Console.WriteLine("La opcion seleccionada no corresponde con niguna");
                            break;
                    }
                }catch (Exception ex) {
                                        
                        fi.escribirFichero("ha ocurrido un error, intentelo más tarde" + ex.Message);
                                                                        
                        Console.WriteLine("Ha ocurrido un error, intentelo más tarde" );
                }

            } while (cerrarMenu);

           
        }
    }
}

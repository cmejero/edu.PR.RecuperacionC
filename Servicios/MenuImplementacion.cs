using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduRecuperacionC.Servicios
{
    /// <summary>
    /// clase que implementa el menu interfaz
    /// </summary>
    internal class MenuImplementacion : MenuInterfaz
    {
       

        public int menuYSeleccionPrincipal()
        {
            
            
            
                int opcionUsuario;

                Console.WriteLine("############################");
                Console.WriteLine("0. Cerrar Aplicación");
                Console.WriteLine("1. Dar alta alumno");
                Console.WriteLine("2. Borrar alumno");
                Console.WriteLine("3. Mostrar alumnos");
                Console.WriteLine("4. Modificar alumnos");
            
                Console.WriteLine("############################");

                opcionUsuario = Convert.ToInt32(Console.ReadLine());
                return opcionUsuario;
                   

        }


        public int menuYSeleccionModificacion()
        {



            int opcionUsuario;

            Console.WriteLine("############################");
            Console.WriteLine("0. Volver");
            Console.WriteLine("1. Modificar nombre");
            Console.WriteLine("2. Modificar primer apellido");
            Console.WriteLine("3. Modificar  direccion");
            Console.WriteLine("4. Modificar  telefono");
            Console.WriteLine("5. Modificar  email");
            Console.WriteLine("############################");

            opcionUsuario = Convert.ToInt32(Console.ReadLine());
            return opcionUsuario;


        }

    }
}

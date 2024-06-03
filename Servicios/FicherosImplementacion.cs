using EduRecuperacionC.Controladores;
using EduRecuperacionC.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EduRecuperacionC.Servicios
{
    /// <summary>
    /// clase de que se encarga de implementar fichero interfaz
    /// </summary>
    internal class FicherosImplementacion : FicherosInterfaz
    {
        public void escribirFichero(string mensaje)
        {
            // poner en null porque debe tener un valor, se declara fuera del try ya que dentro no lo cogeria el finally.
            StreamWriter st = null;

            try
            {
                st = new StreamWriter(Program.rutaFicheroLog, true);
                st.WriteLine(mensaje);


            }
            catch (IOException io)
            {
                Console.WriteLine("Ha ocurrido un error en ficheros, intentelo más tarde. error(1001)" + io.Message);
            }
            finally
            {
                if (st != null)
                {
                    st.Close();
                }
            }
        } 
        


        public void escribirAlumnos()
        {
            
            StreamWriter st = null;

            try
            {

                st= new StreamWriter(Program.rutaFicheroAlumno);
                foreach (AlumnoDto alumno in Program.listaAlumnos)
                {

                    st.WriteLine(alumno.ToString(';'));
                    

                }
            }catch (IOException io)
            {

                // llamar al metodo escribir fichero para escribir en ficheroLog si hay algun error
                escribirFichero("ha ocurrido un error, intentelo más tarde" + io.Message);
                
                Console.WriteLine("Ha ocurrido un error en ficheros, intentelo más tarde. error(1001)");
            }finally
            {
                if (st != null)
                {
                    st.Close();
                }
            }
            

        }

        public void leerFichero()
        {
            StreamReader sr = null;


            try
            {
               sr = new StreamReader(Program.rutaFicheroAlumno);
                string lineas;

                while((lineas = sr.ReadLine()) != null)
                {

                    string[] linea = lineas.Split(';');

                    AlumnoDto alumno = new AlumnoDto(); 

                    alumno.DNI1 = linea[0];
                    alumno.NombreAlumno = linea[1];

                    Program.listaAlumnos.Add(alumno);

                }

                

            }
            catch(IOException io) {

                escribirFichero("Ha ocurrido un error en esribir ficheros" + io.Message);
                Console.WriteLine("Se ha producido un error, intentelo más tarde");

            }
            finally
            {
                if(sr != null)
                {
                    sr.Close();

                }

            }
            
        }

        private long generarId()
        {
            long nuevoId;
            int tamanioLista = Program.listaAlumnos.Count;

            if (tamanioLista > 0)
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

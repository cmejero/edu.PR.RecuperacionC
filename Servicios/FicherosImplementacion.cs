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




                foreach (AlumnoDto alumno in Program.listaAlumnos)
                {
                    for (int i = 0; i < Program.listaAlumnos.Count - 1; i++)
                    {


                        for (int j = 0; j < Program.listaAlumnos.Count - i - 1; j++)
                        {
                            if (alumno.DNI1[j] > alumno.DNI1[j + 1])
                            {

                                AlumnoDto alumn = Program.listaAlumnos[j];
                                Program.listaAlumnos[j] = Program.listaAlumnos[j + 1];
                                Program.listaAlumnos[j + 1] = alumn;



                            }

                        }






                    }

                    st = new StreamWriter(Program.rutaFicheroAlumno);


                    st.WriteLine(alumno.ToString(';'));



                }


            }
            catch (IOException io)
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

                    alumno.NombreAlumno = linea[0];
                    alumno.Apellido1Alumno = linea[1];
                    alumno.Apellido2Alumno = linea[2];
                    alumno.DNI1 = linea[3];
                    alumno.Direccion = linea[4];
                    alumno.Telefono = linea[5];
                    alumno.Email = linea[6];
                    string fecha = linea[7];
                    DateOnly fechaNa = DateOnly.Parse(fecha);
                    alumno.FechaNacimiento = fechaNa;
                    

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

       




    }
}

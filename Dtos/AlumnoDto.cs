using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EduRecuperacionC.Dtos
{
    /// <summary>
    /// clase que se encarga de guardar los datos de los alumnos
    /// </summary>
    internal class AlumnoDto
    {
        long idAlumno;
        string nombreAlumno = "aaaaaaa";
        string apellido1Alumno = "aaaaa";
        string apellido2Alumno = "aaaaa";
        string DNI = "aaaaa";
        string direccion = "aaaaa";
        string telefono = "aaaaa";
        string email = "aaaaa";
        DateOnly fechaNacimiento;

        public long IdAlumno { get => idAlumno; set => idAlumno = value; }
        public string NombreAlumno { get => nombreAlumno; set => nombreAlumno = value; }
        public string Apellido1Alumno { get => apellido1Alumno; set => apellido1Alumno = value; }
        public string Apellido2Alumno { get => apellido2Alumno; set => apellido2Alumno = value; }
        public string DNI1 { get => DNI; set => DNI = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public DateOnly FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }

        override
   public  string ToString()
        {
            string fechaNac = fechaNacimiento.ToString("dd-MM-yyyy");

            string toString = String.Concat(nombreAlumno,";", apellido1Alumno,";", apellido2Alumno,";", DNI1,";", direccion,";", telefono,";" ,email,";", fechaNac);
            return toString;

        }
       
   public string ToString(char caracter)
        {
            string fechaNac = fechaNacimiento.ToString("dd-MM-yyyy");

            string toString = String.Concat(nombreAlumno, caracter, apellido1Alumno, caracter ,apellido2Alumno, caracter, DNI1, caracter, direccion, caracter, telefono, caracter, email, caracter, fechaNac);
            return toString;

        }
    }
  
}



   


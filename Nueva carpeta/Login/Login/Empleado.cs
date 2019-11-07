using System;
using System.Collections.Generic;
using System.Text;

namespace Login
{
    public class Empleado
    {
        public int id { get; set; }
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int telefono { get; set; }
        public string  email { get; set; }
        public string direccion { get; set; }
        public Usuario usuario { get; set; }

        public Empleado(string nombre, string apellido, string email, string direccion, int telefono, int dni)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
            this.email = email;
            this.direccion = direccion;
        }

        public Empleado()
        {

        }

    }
}

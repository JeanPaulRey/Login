using System;
using System.Collections.Generic;
using System.Text;

namespace Login
{
    public class Empleado
    {
        public int dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int telefono { get; set; }
        public string  email { get; set; }
        public string direccion { get; set; }
        public Usuario usuario { get; set; }

        public Empleado()
        {
            
        }

    }
}

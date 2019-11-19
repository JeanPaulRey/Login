using System;
using System.Collections.Generic;
using System.Text;

namespace Login
{
    public class Usuario
    {
        public string idUsuario { get; set; }
        public int id { get; set; }
        public string nombreUsuario { get; set; }
        public string contrasenia { get; set; }
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }

        public Usuario(string nombreUsuario, string contrasenia)
        {
            this.nombreUsuario = nombreUsuario;
            this.contrasenia = contrasenia;
        }

        public Usuario()
        {

        }
    }
}

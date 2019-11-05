using System;
using System.Collections.Generic;
using System.Text;

namespace Login
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string contrasenia { get; set; }

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

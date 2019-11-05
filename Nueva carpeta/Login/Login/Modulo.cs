using System;
using System.Collections.Generic;
using System.Text;

namespace Login
{
    public class Modulo
    {
        public int idModulo { get; set; }
        public string nombre { get; set; }

        public float version { get; set; }

        public List<Usuario> Usuarios { get; set; }

        public Modulo()
        {

        }

    }
}

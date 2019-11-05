using System;
using System.Collections.Generic;

namespace Login
{
    public class Empresa
    {
        public int idEmpresa { get; set; }
        public string nombre { get; set; }
        public Modulo modulo { get; set; }
        public List<Empleado> Empleados { get; set; }

        public Empresa(string nombre)
        {
            Empleados = new List<Empleado>();
            this.nombre = nombre;
        }

        public Empresa()
        {

        }




    }
}

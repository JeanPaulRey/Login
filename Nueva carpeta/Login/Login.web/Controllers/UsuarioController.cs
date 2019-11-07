using Login.web.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Login.web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly LiteDBContext db;

        public UsuarioController(LiteDBContext db)
        {
            this.db = db;
        }


        [HttpGet]
        public IActionResult Index()
        {
            /* 
                 obtengo la lista de empleados con id "nomina" de la base de datos, 
                 ojo que el método GetCollection retorna una coleccion del tipo "LiteCollection" no "IEnumerable"
             */
            var usuarios = db.Context.GetCollection<Usuario>("Usuarios");

            /*
                Guardo en el ViewBag la cantidad de empleados que se encuentra en la lista
                El ViewBag es una memoria compartida entre el Controller y la View, para guardar y acceder se
                debe realizar mediante un identificador, la forma de uso es ViewBag."Identificador" se puede almacenar
                cualquier objeto
             */
            ViewBag.CantidadUsuarios = usuarios.Count();

            /*
                Retorna la vista con nombre "Index" con el contenido de la lista empleados con
                tipo de dato IEnumerable
             */
            return View("Index", usuarios.FindAll());
        }

        [HttpGet]
        public IActionResult Agregar()
        {
            return View("Agregar");
        }

        [HttpPost]
        public IActionResult Agregar(Usuario usuario)
        {
            var usuarios = db.Context.GetCollection<Usuario>("usuarios");
            usuario.idUsuario = Convert.ToString(Guid.NewGuid());
            usuarios.Insert(usuario);
            return RedirectToAction("Index", usuarios.FindAll());
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var usuarios = db.Context.GetCollection<Usuario>("usuarios").FindAll();

            /*
                Con el método FirstOrDefault busco el primer elemento que coicida con el "id" se pasa por parametro
                El "id" viene dado por el enlace que se genera al momento de procesar el listado de empleados
                en la vista "Index"
             */
            var usuario = usuarios.FirstOrDefault(x => x.id == id);

            return View("Editar", usuario);
        }

        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            var usuarios = db.Context.GetCollection<Usuario>("usuarios");

            /*
               Update: método propio de la biblioteca LiteDB, permite actualizar un objeto de tipo Empleado
               en la base de datos, como el Id viene incluido en el objeto no se necesita buscar por el mismo
               LiteDB automaticamente infiere que se trata de ese objeto y actualiza el resto de campos
            */
            usuarios.Update(usuario);

            return RedirectToAction("Index", usuarios.FindAll());
        }
        public IActionResult Eliminar(int id)
        {
            var usuarios = db.Context.GetCollection<Empleado>("usuarios");

            /*
               Delete: método propio de la biblioteca LiteDB, permite eliminar un objeto de tipo Empleado
               en la base de datos, en este caso como se tiene el objeto, pero si el Id y como este es unico
               procedo a borrar todos los objetos que posean el mismo Id.
            */
            usuarios.Delete(x => x.id == id);

            return RedirectToAction("Index", usuarios.FindAll());
        }
    }
}
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
            
            var usuarios = db.Context.GetCollection<Usuario>("Usuarios");

          
            ViewBag.CantidadUsuarios = usuarios.Count();

          
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

            var usuario = usuarios.FirstOrDefault(x => x.id == id);

            return View("Editar", usuario);
        }

        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            var usuarios = db.Context.GetCollection<Usuario>("usuarios");

         
            usuarios.Update(usuario);

            return RedirectToAction("Index", usuarios.FindAll());
        }
        public IActionResult Eliminar(int id)
        {
            var usuarios = db.Context.GetCollection<Usuario>("usuarios");

           
            usuarios.Delete(x => x.id == id);

            return RedirectToAction("Index", usuarios.FindAll());
        }
    }
}
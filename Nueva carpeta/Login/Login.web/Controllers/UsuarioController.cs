using Login.web.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

        [HttpGet]
        public IActionResult Agregar()
        {
            return View("Agregar");
        }

        [HttpPost]
        public IActionResult Agregar(Usuario usuario)
        {
            var usuarios = db.Context.GetCollection<Usuario>("usuario");
            usuarios.Insert(usuario);
            return RedirectToAction("Index", usuarios.FindAll());
        }
    }
}
using Login.web.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Login.web.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly LiteDBContext db;

        public EmpresaController(LiteDBContext db)
        {
            this.db = db;
        }


        [HttpGet]
        public IActionResult Index()
        {

            var empleados = db.Context.GetCollection<Usuario>("Usuarios");


            ViewBag.CantidadEmpleados = empleados.Count();


            return View("Index", empleados.FindAll());
        }

        [HttpPost]
        public IActionResult Agregar(Usuario usuario)
        {
            var usuarios = db.Context.GetCollection<Usuario>("Usuarios");
            usuario.idUsuario = Convert.ToString(Guid.NewGuid());
            usuarios.Insert(usuario);
            return RedirectToAction("Index", usuarios.FindAll());
        }
    }
}
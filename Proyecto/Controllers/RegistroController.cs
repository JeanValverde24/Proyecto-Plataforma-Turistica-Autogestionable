using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class RegistroController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarTurista(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                // Lógica para guardar el turista en la base de datos
                // Por ejemplo: _context.Turistas.Add(usuario);
                // _context.SaveChanges();

                TempData["Mensaje"] = "Registro exitoso. Bienvenido a la plataforma";
                return RedirectToAction("Index");
            }

            return View("Index", usuario);
        }

        [HttpPost]
        public ActionResult RegistrarDueño(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                // Lógica para guardar el dueño de local en la base de datos
                // Por ejemplo: _context.Dueños.Add(usuario);
                // _context.SaveChanges();

                TempData["Mensaje"] = "Registro exitoso. Acceso al panel de administración";
                return RedirectToAction("Index");
            }

            return View("Index", usuario);
        }
    }
}
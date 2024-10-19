using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class PerfilController : Controller
    {
        public ActionResult Historial()
        {
            // Simulación de historial del usuario, en la realidad vendría de la base de datos
            var historial = new List<HistorialServicio>
        {
            new HistorialServicio { NombreLocal = "Pacific Suites", Fecha = DateTime.Now.AddDays(-10), Servicio = "Estadía", Calificado = false },
            new HistorialServicio { NombreLocal = "Restaurante El Sabroso", Fecha = DateTime.Now.AddDays(-5), Servicio = "Almuerzo", Calificado = true }
        };

            return View(historial);
        }



        public ActionResult DejarFeedback(string local)
        {
            // Enviar el nombre del local a la vista
            ViewBag.Local = local;
            return View();
        }

        [HttpPost]
        public ActionResult EnviarFeedback(string local, string comentario, int estrellas)
        {
            // Aquí se guardaría el feedback en la base de datos
            // Simulación de almacenamiento (debes reemplazar por tu lógica de base de datos)
            var feedback = new Feedback
            {
                Local = local,
                Comentario = comentario,
                Estrellas = estrellas,
                Fecha = DateTime.Now
            };

            // Simulación de guardar en la base de datos (deberías implementar tu repositorio de datos)
            TempData["Mensaje"] = "Gracias por tu feedback, ¡nos ayuda a mejorar!";

            // Redirigir al historial una vez enviado el feedback
            return RedirectToAction("Historial");
        }
    }

}
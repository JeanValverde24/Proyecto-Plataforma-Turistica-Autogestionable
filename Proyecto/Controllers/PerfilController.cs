using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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


        // PerfilController.cs

        // Acción para redirigir a CargarInformacionDelNegocio con el negocio_id
        public ActionResult DejarFeedback(int negocio_id)
        {
            return RedirectToAction("CargarInformacionDelNegocio", new { negocioId = negocio_id });
        }

        // Acción para cargar la información del negocio desde la API y enviar los datos a la vista DejarFeedback
        public async Task<ActionResult> CargarInformacionDelNegocio(int negocioId)
        {
            ViewBag.NegocioId = negocioId;

            // Llamada a la API
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://159.223.123.38:8000/");
                var response = await client.GetAsync($"api/obtener_negocio/{negocioId}");
                System.Diagnostics.Debug.WriteLine($"Estado de respuesta de la API: {response.StatusCode}");

                if (response.IsSuccessStatusCode)
                {
                    var negocio = await response.Content.ReadAsAsync<Negocio>();
                    return View("DejarFeedback", negocio); // Envía a la vista DejarFeedback con los datos del negocio
                }
            }

            return HttpNotFound("Negocio no encontrado.");
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
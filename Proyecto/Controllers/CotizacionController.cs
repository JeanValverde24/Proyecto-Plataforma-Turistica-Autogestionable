using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class CotizacionController : Controller
    {
        // GET: Cotizacion
        private readonly HttpClient _httpClient;

        
        public ActionResult CotizacionResult()
        {
            return View();
        }

        public CotizacionController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5000/api/"); // Cambia la URL base si es necesario
        }

        [HttpPost]
        public async Task<ActionResult> CustomQuote(int dias_viaje, decimal presupuesto_usuario, string motivo_viaje, int cantidad_personas, string ubicacion_usuario)
        {
            var requestData = new
            {
                dias_viaje,
                presupuesto_usuario,
                motivo_viaje,
                cantidad_personas,
                ubicacion_usuario
            };

            var jsonContent = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("generar_cotizacion", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var cotizaciones = JsonConvert.DeserializeObject<List<CotizacionResponse>>(jsonResponse);

                return View("CotizacionResult", cotizaciones);
            }
            else
            {
                ViewBag.ErrorMessage = "No se pudo obtener la cotización. Intenta de nuevo más tarde.";
                return View("CustomQuote");
            }
        }



    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class RegistroController : Controller
    {
        

        public ActionResult Index()
        {
            return View();
        }
        
        private readonly HttpClient _httpClient;

        public RegistroController()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://159.223.123.38:8000/") };
        }
        [HttpGet]
        public async Task<ActionResult> RegistroNegocio()
        {
            ViewBag.IdSocio = Session["IdSocio"];
            // Cargar las listas para los menús desplegables
            ViewBag.TiposNegocio = await ObtenerTiposNegocioDesdeAPI();
            await Task.Delay(1000);  // Retraso de 1 segundo entre las solicitudes

            ViewBag.Provincias = await ObtenerProvinciasDesdeAPI();

         

            return View();
        }


        // Acción para procesar el registro de negocio
        [HttpPost]
        public async Task<ActionResult> RegistrarNegocio(Negocio negocio, IEnumerable<HttpPostedFileBase> TbImgRuta)
        {
            var url = "http://159.223.123.38:8000/api/registro/negocio"; // URL de la API Flask

            // Crear un objeto para enviar datos del negocio
            var requestData = new
            {
                TbNgcUsuario = negocio.TbNgcUsuario,  // Usar el valor asignado desde la vista
                TbNgcNombre = negocio.TbNgcNombre,
                TbNgcTipoNegocio = negocio.TbNgcTipoNegocio,
                TbNgcProvincia = negocio.TbNgcProvincia
            };

            var jsonContent = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

            using (var formContent = new MultipartFormDataContent())
            {
                formContent.Add(jsonContent, "negocio");

                if (TbImgRuta != null)
                {
                    foreach (var imagen in TbImgRuta)
                    {
                        if (imagen != null && imagen.ContentLength > 0)
                        {
                            byte[] fileData;
                            using (var binaryReader = new BinaryReader(imagen.InputStream))
                            {
                                fileData = binaryReader.ReadBytes(imagen.ContentLength);
                            }

                            var fileContent = new ByteArrayContent(fileData);
                            fileContent.Headers.ContentType = new MediaTypeHeaderValue(imagen.ContentType);
                            formContent.Add(fileContent, "TbImgRuta", imagen.FileName);
                        }
                    }
                }

                var response = await _httpClient.PostAsync(url, formContent);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("RegistroExitoso");
                }
                else
                {
                    TempData["Error"] = "Error en el registro del negocio. Intente nuevamente.";
                    return RedirectToAction("RegistroNegocio");
                }
            }
        }


        private async Task<IEnumerable<TipoNegocio>> ObtenerTiposNegocioDesdeAPI()
        {
            var response = await _httpClient.GetAsync("api/tipos_negocio");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<TipoNegocio>>(data);
            }
            return new List<TipoNegocio>(); // Retorna una lista vacía en caso de error
        }

        private async Task<IEnumerable<Provincia>> ObtenerProvinciasDesdeAPI()
        {
            var response = await _httpClient.GetAsync("api/provincias");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Provincia>>(data);
            }
            return new List<Provincia>(); // Retorna una lista vacía en caso de error
        }

        [HttpPost]
        public async Task<ActionResult> RegistrarTurista(Usuario usuario)
        {
            var url = "http://159.223.123.38:8000/api/registro/turista"; // URL de tu API Flask para el registro de turistas
            var requestData = new
            {
                UsrNombresCompleto = usuario.UsrNombresCompleto,
                UsrCorreo = usuario.UsrCorreo,
                UsrDniRut = usuario.UsrDniRut,
                UsrRuc = usuario.UsrRuc, // Opcional
                UsrContraseña=usuario.contraseña,
                
            };
            Session["IdTurista"] = usuario.UsrId;


            // Log para verificar los datos que se enviarán
            System.Diagnostics.Debug.WriteLine($"Llamada a la API de registro iniciada con correo: {requestData.UsrCorreo}");

            // Serialización y envío de datos a la API Flask
            var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);

            // Log para verificar el estado de la respuesta de la API
            System.Diagnostics.Debug.WriteLine($"Estado de respuesta de la API: {response.StatusCode}");

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
                string tipoUsuario = result.tipo_usuario;
                string nombre = result.nombre;

                // Guarda la información en la sesión si el registro es exitoso
                Session["PermitirAñadirServicio"] = tipoUsuario == "2";
                Session["NombreUsuario"] = nombre;
                Session["Mensaje"] = "Registro exitoso";

                return RedirectToAction("Index","Home"); // Redirige a la página de inicio
            }
            else
            {
                Session["Mensaje"] = "Error en el registro. Inténtelo nuevamente.";
                return RedirectToAction("Index", "Registro"); // Redirige a la página de registro en caso de error
            }
        }





        [HttpPost]
        public async Task<ActionResult> RegistrarSocio(Usuario usuario)
        {
            var url = "http://159.223.123.38:8000/api/registro/socio"; // URL de tu API Flask para el registro de turistas
            var requestData = new
            {
                UsrNombres = usuario.UsrNombresCompleto,
                UsrCorreo = usuario.UsrCorreo,
                
                UsrDniRut = usuario.UsrDniRut,
                UsrRuc = usuario.UsrRuc,
            };

            // Log para verificar los datos que se enviarán
            System.Diagnostics.Debug.WriteLine($"Llamada a la API de registro iniciada con correo: {requestData.UsrCorreo}");

            // Serialización y envío de datos a la API Flask
            var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);

            // Log para verificar el estado de la respuesta de la API
            System.Diagnostics.Debug.WriteLine($"Estado de respuesta de la API: {response.StatusCode}");

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
                string tipoUsuario = result.tipo_usuario;
                string nombre = result.nombre;
                int id = result.id;

                // Guarda la información en la sesión si el registro es exitoso
                Session["IdSocio"] = id;
                Session["PermitirAñadirServicio"] = tipoUsuario == "2";
                Session["NombreUsuario"] = nombre;
                Session["Mensaje"] = "Registro exitoso";

                return RedirectToAction("RegistroNegocio"); // Redirige a la página de registro en caso de error
            }
            else
            {
                Session["Mensaje"] = "Error en el registro. Inténtelo nuevamente.";
                return RedirectToAction("RegistroNegocio"); // Redirige a la página de registro en caso de error
            }
        }
    }
}

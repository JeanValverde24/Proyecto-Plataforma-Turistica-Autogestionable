using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Proyecto.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class LoginController : Controller
    {
        private static readonly HttpClient _httpClient = new HttpClient();  // Declaración estática para evitar múltiples instancias

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> IniciarSesion(Usuario usuario)
        {
            var url = "http://localhost:5000/api/login";
            var requestData = new
            {
                correo = usuario.UsrCorreo,
                password = usuario.contraseña
            };

            // Log para verificar los datos que se enviarán
            System.Diagnostics.Debug.WriteLine($"Llamada a la API iniciada con correo: {requestData.correo}");

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

                Session["IdUsuario"] = result.id;
                Session["PermitirAñadirServicio"] = tipoUsuario == "2";
                Session["NombreUsuario"] = nombre;
                Session["Mensaje"] = "Inicio de sesión exitoso";

                return RedirectToAction("Index", "Home");
            }
            else
            {
                Session["Mensaje"] = "Correo o contraseña incorrecta";
                return RedirectToAction("Index", "Login");
            }

        }


    }
}

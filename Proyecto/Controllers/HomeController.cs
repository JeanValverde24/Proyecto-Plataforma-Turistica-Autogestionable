using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Lista de elementos (hoteles, restaurantes, lugares turísticos)
            var lugares = new List<Lugar>
        {
              new Lugar { Nombre = "Pacific Suites", Descripcion = "Hotel 2 estrellas", ImagenUrl = "/Content/Images/hotel1.jpg", PrecioMin = 90, PrecioMax = 300, Categoria = "Hotel", Direccion = "Av. Vicente Dagnino 262" },
    new Lugar { Nombre = "Restaurante El Sabroso", Descripcion = "Comida tradicional", ImagenUrl = "/Content/Images/restaurante1.jpg", PrecioMin = 20, PrecioMax = 50, Categoria = "Restaurante", Direccion = "Calle Central 45" },
    new Lugar { Nombre = "Mirador del Inti", Descripcion = "Una vista espectacular de la ciudad", ImagenUrl = "/Content/Images/lugar_turistico1.jpg", PrecioMin = 0, PrecioMax = 0, Categoria = "Lugar Turístico", Direccion = "Cerro Inti 123" },
    new Lugar { Nombre = "Hotel Oasis", Descripcion = "Hotel 3 estrellas con piscina", ImagenUrl = "/Content/Images/hotel2.jpg", PrecioMin = 150, PrecioMax = 400, Categoria = "Hotel", Direccion = "Av. Bolívar 789" },
    new Lugar { Nombre = "Restaurante Mar Azul", Descripcion = "Pescados y mariscos frescos", ImagenUrl = "/Content/Images/restaurante2.jpg", PrecioMin = 30, PrecioMax = 80, Categoria = "Restaurante", Direccion = "Plaza Marina 234" },
    new Lugar { Nombre = "Parque Nacional Alto de la Alianza", Descripcion = "Lugar histórico de la batalla de Tacna", ImagenUrl = "/Content/Images/lugar_turistico2.jpg", PrecioMin = 0, PrecioMax = 0, Categoria = "Lugar Turístico", Direccion = "Av. Alto de la Alianza s/n" },
    new Lugar { Nombre = "Hotel Los Andes", Descripcion = "Hotel 4 estrellas, con desayuno buffet", ImagenUrl = "/Content/Images/hotel3.jpg", PrecioMin = 200, PrecioMax = 500, Categoria = "Hotel", Direccion = "Calle Las Lomas 345" },
    new Lugar { Nombre = "Restaurante El Buen Sabor", Descripcion = "Comida criolla y platos típicos", ImagenUrl = "/Content/Images/restaurante3.jpg", PrecioMin = 25, PrecioMax = 70, Categoria = "Restaurante", Direccion = "Jr. Los Sabores 567" },
    new Lugar { Nombre = "Catedral de Tacna", Descripcion = "Monumento arquitectónico de la ciudad", ImagenUrl = "/Content/Images/lugar_turistico3.jpg", PrecioMin = 0, PrecioMax = 0, Categoria = "Lugar Turístico", Direccion = "Plaza de Armas" },
    new Lugar { Nombre = "Hotel Gran Sol", Descripcion = "Hotel 5 estrellas, lujo y confort", ImagenUrl = "/Content/Images/hotel4.jpg", PrecioMin = 300, PrecioMax = 600, Categoria = "Hotel", Direccion = "Av. Sol Radiante 567" },
    new Lugar { Nombre = "Restaurante La Casona", Descripcion = "Comida gourmet en un ambiente elegante", ImagenUrl = "/Content/Images/restaurante4.jpg", PrecioMin = 40, PrecioMax = 120, Categoria = "Restaurante", Direccion = "Calle Colonial 789" },
    new Lugar { Nombre = "Museo Ferroviario de Tacna", Descripcion = "Descubre la historia del tren en Tacna", ImagenUrl = "/Content/Images/lugar_turistico4.jpg", PrecioMin = 10, PrecioMax = 20, Categoria = "Lugar Turístico", Direccion = "Av. Grau 123" }

        };

            // Selecciona 3 lugares aleatorios
            Random random = new Random();
            var lugaresAleatorios = lugares.OrderBy(x => random.Next()).Take(10).ToList();

            return View(lugaresAleatorios);
        }
    }

}
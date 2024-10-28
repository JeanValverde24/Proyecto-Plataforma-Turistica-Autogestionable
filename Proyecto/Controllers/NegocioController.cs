using Proyecto.Models;
using System.Collections.Generic;
using Proyecto.Models;
using System.Web.Mvc;

public class NegocioController : Controller
{
    // Método para obtener la lista de servicios
    private List<Servicio> ObtenerServicios()
    {
        // Simulación de datos
        return new List<Servicio>
        {
            new Servicio { Nombre = "Servicio 1", Precio = 100 },
            new Servicio { Nombre = "Servicio 2", Precio = 200 }
        };
    }

    // Método que devuelve la vista de gestión de negocio
    public ActionResult GestionarNegocio()
    {
        var servicios = ObtenerServicios(); // Obtener los servicios
        return View(servicios); // Pasar el modelo a la vista
    }

    // Método para guardar los cambios de precios
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class CotizacionController : Controller
    {
        // GET: Cotizacion
        public ActionResult CustomQuote()
        {
            return View();
        }
    }
}
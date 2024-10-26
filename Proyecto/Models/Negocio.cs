using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Negocio
    {
        public int negocio_id { get; set; }
        public int? TbNgcUsuario { get; set; } // Mantén esto si necesitas el ID de usuario
        public string negocio_nombre { get; set; }
        public string tipo_negocio { get; set; }
        public string provincia { get; set; }
    }

}
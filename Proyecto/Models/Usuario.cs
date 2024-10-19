using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Usuario
    {
        public string NombreCompleto { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contraseña { get; set; }
        public string DNI { get; set; } // Para turistas
        public string RUC { get; set; } // Para dueños de locales
    }

}
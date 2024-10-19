using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Feedback
    {
        public string Local { get; set; }
        public string Comentario { get; set; }
        public int Estrellas { get; set; }
        public DateTime Fecha { get; set; }
    }

}
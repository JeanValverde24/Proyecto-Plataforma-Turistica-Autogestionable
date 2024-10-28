using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Negocio
    {
        public int negocio_id { get; set; }
        public int TbNgcUsuario { get; set; }
        public string TbNgcNombre { get; set; }
        public int TbNgcTipoNegocio { get; set; }
        public string TipoNegocio { get; set; }  // Nombre del tipo de negocio

        public int TbNgcProvincia { get; set; }
        public string Provincia { get; set; }    // Nombre de la provincia

        public List<string> ImagenesUrl { get; set; } = new List<string>();  // Lista de URLs de las imágenes

    }

}
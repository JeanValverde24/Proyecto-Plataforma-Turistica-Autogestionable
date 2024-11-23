using Newtonsoft.Json;
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
        public int TbNgcTipoNegocio { get; set; }
        public int TbNgcProvincia { get; set; }

        [JsonProperty("negocio_nombre")]
        public string TbNgcNombre { get; set; }

        [JsonProperty("tipo_negocio")]
        public string TipoNegocio { get; set; }

        [JsonProperty("provincia")]
        public string Provincia { get; set; }

        [JsonProperty("direccion")]
        public string TbNgcDireccion { get; set; }

        [JsonProperty("telefono")]
        public string TbNgcTelefono { get; set; }

        public List<string> ImagenesUrl { get; set; } = new List<string>();
        public List<Feedback> Feedbacks { get; set; } // Opcional
    }



}
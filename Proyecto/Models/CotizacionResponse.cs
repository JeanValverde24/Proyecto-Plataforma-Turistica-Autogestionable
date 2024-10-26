using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class CotizacionResponse
    {
        [JsonProperty("Porcentaje del Presupuesto")]
        public string PorcentajeDelPresupuesto { get; set; }

        [JsonProperty("Hotel")]
        public HotelInfo Hotel { get; set; }

        [JsonProperty("Restaurante")]
        public RestauranteInfo Restaurante { get; set; }

        [JsonProperty("Lugares")]
        public List<string> Lugares { get; set; }

        [JsonProperty("Costo Lugares")]
        public decimal CostoLugares { get; set; }

        [JsonProperty("Presupuesto Total")]
        public decimal PresupuestoTotal { get; set; }

        [JsonProperty("Presupuesto Restante")]
        public decimal PresupuestoRestante { get; set; }
    }

    public class HotelInfo
    {
        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonProperty("Ubicación")]
        public string Ubicacion { get; set; }

        [JsonProperty("Precio por Noche")]
        public decimal PrecioPorNoche { get; set; }

        [JsonProperty("Capacidad")]
        public int Capacidad { get; set; }

        [JsonProperty("Calificación")]
        public decimal Calificacion { get; set; }

        [JsonProperty("Costo Total")]
        public decimal CostoTotal { get; set; }

        [JsonProperty("Servicios")]
        public int Servicios { get; set; }
    }

    public class RestauranteInfo
    {
        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonProperty("Ubicación")]
        public string Ubicacion { get; set; }

        [JsonProperty("Tipo de Cocina")]
        public string TipoDeCocina { get; set; }

        [JsonProperty("Precio Medio por Plato")]
        public decimal PrecioMedioPorPlato { get; set; }

        [JsonProperty("Calificación")]
        public decimal Calificacion { get; set; }

        [JsonProperty("Costo Total")]
        public decimal CostoTotal { get; set; }
    }


}
using APIDatabase.Models.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIDatabase.Models
{
    [Table("sensor_nivel", Schema = "dev")]
    public class SensorNivelModel : BaseEntity
    {

        [JsonProperty("IdReservatorio")]
        public int reservatorioid { get; set; }

        [JsonProperty("DataHora")]
        public DateTime datahora { get; set; }

        [JsonProperty("SensorNivel")]
        public decimal sensor_nivel { get; set; }

        public ReservatorioModel Reservatorio { get; set; }
    }
}

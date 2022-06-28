using APIDatabase.Models.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIDatabase.Models
{
    [Table("sensor_vazao", Schema = "dev")]
    public class SensorVazaoModel : BaseEntity
    {

        [JsonProperty("IdReservatorio")]
        public int reservatorioid { get; set; }

        [JsonProperty("DataHora")]
        public DateTime datahora { get; set; }

        [JsonProperty("SensorVazaoEntrada")]
        public decimal sensor_vazaoentrada { get; set; }

        [JsonProperty("SensorVazaoSaida")]
        public decimal sensor_vazaosaida { get; set; }

        public virtual ReservatorioModel reservatorio { get; set; }

    }
}

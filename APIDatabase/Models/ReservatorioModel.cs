using APIDatabase.Models.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIDatabase.Models
{
    [Table("reservatorio", Schema = "dev")]
    public class ReservatorioModel : BaseEntity
    {

        [JsonProperty("IdUsuario")]
        public int usuarioid { get; set; }

        [JsonProperty("AlturaReservatorio")]
        public decimal altura_reservatorio { get; set; }

        [JsonProperty("Categoria")]
        public string categoria { get; set; }

        public virtual UsuarioModel usuario { get; set; }
        public virtual List<SensorNivelModel> SensorNivel { get; set; }
        public virtual List<SensorVazaoModel> SensorVazao { get; set; }
    }
}

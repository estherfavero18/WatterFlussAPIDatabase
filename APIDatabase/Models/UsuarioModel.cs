using APIDatabase.Models.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIDatabase.Models
{
    [Table("usuario", Schema = "dev")]
    public class UsuarioModel : BaseEntity
    {
        [JsonProperty("Nome")]
        public string nome { get; set; }
        
        [JsonProperty("Cpf")]
        public string cpf { get; set; }

        [JsonProperty("Senha")]
        public string senha { get; set; }

        [JsonProperty("Endereco")]
        public string endereco { get; set; }

        [JsonProperty("Telefone")]
        public string telefone { get; set; }

        [JsonProperty("Email")]
        public string email { get; set; }

        public virtual List<ReservatorioModel> Reservatorios { get; set; }

    }
}

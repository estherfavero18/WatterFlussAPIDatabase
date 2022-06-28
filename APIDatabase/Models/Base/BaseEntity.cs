using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIDatabase.Models.Base
{
    public class BaseEntity
    {
        [JsonProperty("Id")]
        [Key]
        public int id { get; set; }
    }
}

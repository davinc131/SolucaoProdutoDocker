using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProduto.Models
{
  
  public class Produtos
  {
    [JsonProperty("produto")]
    public string produto { get; set; }
    [JsonProperty("valor")]
    public decimal valor { get; set; }
    [JsonProperty("imagem")]
    public string imagem { get; set; }
    [JsonProperty("eans")]
    public string[] eans { get; set; }
  }
}

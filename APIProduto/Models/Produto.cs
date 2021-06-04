using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIProduto.Models
{
  public class Produto
  {
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Valor { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppProduto.Models
{
  public class Produto
  {
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Column(TypeName = "decimal(7, 2)")]
    public decimal Valor { get; set; }
  }
}

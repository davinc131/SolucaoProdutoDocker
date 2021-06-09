using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIProduto.Models
{
  public class Produto
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }

    [Column(TypeName = "decimal(7, 2)")]
    public decimal Valor { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProduto.Models
{
  public class RootAPI
  {
    public string mensagem { get; set; }
    public Produtos[] Produtos { get; set; }
  }
}

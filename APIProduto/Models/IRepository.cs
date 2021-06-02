using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProduto.Models
{
  public interface IRepository
  {
    IEnumerable<Produto> Produtos { get; }
  }
}

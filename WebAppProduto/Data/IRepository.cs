using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppProduto.Models;

namespace WebAppProduto.Data
{
  public interface IRepository
  {
    IEnumerable<Produto> Produtos { get; }
    void ProdutoCreate(Produto pProduto);
    IEnumerable<Produto> ProdutoList();
  }
}

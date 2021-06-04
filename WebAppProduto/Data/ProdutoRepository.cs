using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppProduto.Models;

namespace WebAppProduto.Data
{
  public class ProdutoRepository : IRepository
  {
    List<Produto> _produtos;
    public ProdutoRepository()
    {
      _produtos = new List<Produto>();
    }
    public IEnumerable<Produto> Produtos => _produtos;

    public void ProdutoCreate(Produto pProduto)
    {
      pProduto.Id = Guid.NewGuid();
      _produtos.Add(pProduto);
    }

    public IEnumerable<Produto> ProdutoList() => Produtos;
  }
}

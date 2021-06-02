using APIProduto.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProduto.Models
{
  public class ProdutoRepository:IRepository
  {
    private APIProdutoContext context;
    public ProdutoRepository(APIProdutoContext pContext)
    {
      context = pContext;
    }

    public IEnumerable<Produto> Produtos => context.Produto;
  }
}

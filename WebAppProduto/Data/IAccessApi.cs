using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppProduto.Models;

namespace WebAppProduto.Data
{
  public interface IAccessApi
  {
    Task<ActionResult<Produto>> CriarProduto(Produto pProduto);
    Task<IActionResult> DeletarProduto(Guid pId);
    Task<IActionResult> AlterarProduto(Guid pId, Produto pProduto);
    IEnumerable<Produto> ListarTodosProdutos();
    Produto ConsultarProdutoPorId(Guid id);
    IEnumerable<Produtos> ListarProdutosAPI();
  }
}

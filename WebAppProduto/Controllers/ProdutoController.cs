using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppProduto.Data;
using WebAppProduto.Models;

namespace WebAppProduto.Controllers
{
  public class ProdutoController : Controller
  {
    private readonly IAccessApi _context;

    public ProdutoController(IAccessApi context)
    {
      _context = context;
    }

    // GET: ProdutoController
    public ActionResult Index()
    {
      var produtos = _context.ListarTodosProdutos();
      return View(produtos);
    }

    public ActionResult IndexProdutoApi()
    {
      var produtos = _context.ListarProdutosAPI();
      return View(produtos);
    }

    public ActionResult ProdutoList()
    {
      var produtos = _context.ListarTodosProdutos();
      return View(produtos);
    }

    // GET: ProdutoController/Details/5
    public ActionResult Details(Guid id)
    {
      if (id == null)
        return NotFound();

      var produto = _context.ConsultarProdutoPorId(id);

      if (produto == null)
        return NotFound();

      return View(produto);
    }

    // GET: ProdutoController/Create
    public ActionResult Create()
    {
      return View("ProdutoCreate");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Valor")] Produto pProduto)
     {
      if (ModelState.IsValid)
      {
        _context.CriarProduto(pProduto);
        //return RedirectToAction(nameof(ProdutoList));
        return RedirectToAction(nameof(Index));
      }
      return View(pProduto);
    }

    // GET: ProdutoController/Edit/5
    public async Task<IActionResult> Edit(Guid id)
    {
      if (id == null)
        return NotFound();

      var produto = _context.ConsultarProdutoPorId(id);

      if (produto == null)
        return NotFound();

      return View(produto);
    }

    // POST: ProdutoController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Guid id, [Bind("Id,Nome,Descricao,Valor")] Produto pProduto)
    {
      try
      {
        _context.AlterarProduto(id, pProduto);
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: ProdutoController/Delete/5
    public ActionResult Delete(Guid id)
    {
      if (id == null)
        return NotFound();

      var produto = _context.ConsultarProdutoPorId(id);

      if (produto == null)
        return NotFound();

      return View(produto);
    }

    // POST: ProdutoController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(Guid Id)
    {
      try
      {
        _context.DeletarProduto(Id);
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }
  }
}

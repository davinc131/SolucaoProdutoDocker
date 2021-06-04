using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppProduto.Models;

namespace WebAppProduto.Data
{
  public class AccessApi : IAccessApi
  {
    public Task<IActionResult> AlterarProduto(Guid pId, Produto pProduto)
    {
      var url = "https://localhost:44321/api/Produtos/"+pId;
      var client = new RestClient(url);
      var request = new RestRequest();
      request.AddJsonBody(pProduto);
      var response = client.Put(request);
      return null;
    }

    public Produto ConsultarProdutoPorId(Guid id)
    {
      var url = "https://localhost:44321/api/Produtos/"+id;
      var client = new RestClient(url);
      var request = new RestRequest();
      var response = client.Get(request);
      Produto produto = JsonConvert.DeserializeObject<Produto>(response.Content);

      return produto;
    }

    public Task<ActionResult<Produto>> CriarProduto(Produto pProduto)
    {
      var url = "https://localhost:44321/api/Produtos/";
      var client = new RestClient(url);
      var request = new RestRequest();
      request.AddJsonBody(pProduto);
      var response = client.Post(request);
      var produto = JsonConvert.DeserializeObject<Produto>(response.Content);
      return null;
    }

    public Task<IActionResult> DeletarProduto(Guid pId)
    {
      var url = "https://localhost:44321/api/Produtos/"+pId;
      var client = new RestClient(url);
      var request = new RestRequest();
      var response = client.Delete(request);
      return null;
    }

    public IEnumerable<Produto> ListarTodosProdutos()
    {
      var url = "https://localhost:44321/api/Produtos/";
      var client = new RestClient(url);
      var request = new RestRequest();
      var response = client.Get(request);
      var produto = JsonConvert.DeserializeObject<IEnumerable<Produto>>(response.Content);
      return produto;
    }
  }
}

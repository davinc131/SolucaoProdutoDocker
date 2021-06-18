using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIProduto.Data;
using APIProduto.Models;
using RestSharp;
using Newtonsoft.Json;

namespace APIProduto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly APIProdutoContext _context;

        public ProdutosController(APIProdutoContext context)
        {
            _context = context;
            _context.Database.Migrate();
        }

        // GET: api/Produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProduto()
        {
            var url = "https://no2gru7ua3.execute-api.us-east-1.amazonaws.com";
            return await _context.Produto.ToListAsync();
        }

    // GET: api/Produtos
    [HttpGet]
    [Route("produtonew")]
    public async Task<ActionResult<RootAPI>> GetProdutoNew()
    {
      var url = "https://no2gru7ua3.execute-api.us-east-1.amazonaws.com";
      var client = new RestClient(url);
      var request = new RestRequest();
      var response = client.Get(request);
      var produtos = JsonConvert.DeserializeObject<RootAPI>(response.Content);
      return produtos;
    }

    // GET: api/Produtos/5
    [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(Guid id)
        {
            var produto = await _context.Produto.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        // PUT: api/Produtos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(Guid id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            //produto.Valor = decimal.Parse(produto.Valor.ToString().Replace(',', '.'));
            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Produtos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            produto.Id = Guid.NewGuid();
            //produto.Valor = decimal.Parse(produto.Valor.ToString().Replace(',', '.'));
            _context.Produto.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduto", new { id = produto.Id }, produto);
        }

        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(Guid id)
        {
            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutoExists(Guid id)
        {
            return _context.Produto.Any(e => e.Id == id);
        }
    }
}

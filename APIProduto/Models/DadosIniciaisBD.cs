using APIProduto.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProduto.Models
{
  public class DadosIniciaisBD:IMigrageProduto
  {
    private readonly APIProdutoContext _context;

    public DadosIniciaisBD(APIProdutoContext context)
    {
      _context = context;
    }

    public void Migrate()
    {
      _context.Database.Migrate();
    }
  }
}

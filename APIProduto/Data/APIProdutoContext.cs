using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIProduto.Models;

namespace APIProduto.Data
{
    public class APIProdutoContext : DbContext
    {
        public APIProdutoContext (DbContextOptions<APIProdutoContext> options)
            : base(options)
        {
        }

        public DbSet<APIProduto.Models.Produto> Produto { get; set; }
    }
}

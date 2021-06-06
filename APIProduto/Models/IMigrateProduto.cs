using APIProduto.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProduto.Models
{
  public interface IMigrateProduto
  {
    void Migrate(APIProdutoContext context);
  }
}

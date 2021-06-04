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
  public class DadosIniciaisBD
  {
    private readonly IRepository _repository;
    public static void InserirDadosBD(IApplicationBuilder app)
    {
      try
      {
        InserirDadosBD(app.ApplicationServices.GetRequiredService<APIProdutoContext>());
      }
      catch (Exception ex)
      {
        throw new Exception("Origem: DadosIniciaisBD - "+ ex.Message);
      }
    }

    public static void InserirDadosBD(IRepository pRepository)
    {
      try
      {
        InserirDadosBD(pRepository);
      }
      catch (Exception ex)
      {
        throw new Exception("Origem: DadosIniciaisBD - " + ex.Message);
      }
    }

    public static void InserirDadosBD([FromServices]APIProdutoContext context)
    {
      context.Database.Migrate();
      if (!context.Produto.Any())
      {
        context.Produto.AddRange(
            new Produto() { Nome = "Álcool", Descricao = "Um ótimo desinfetante, o álcool pode ser usado em vidros e metais e é o produto ideal para as pequenas limpezas do dia a dia. Mas, sempre é bom evitar usar em pisos de madeira.", Valor = 5.6m },
            new Produto() { Nome = "Detergente", Descricao = "Esse produto é indispensável quando for fazer sua lista de material de limpeza, pois, além de lavar louças, o detergente é ideal para limpar superfícies de madeira e plástico, os azulejos da cozinha e do banheiro, paredes e mais. Lembre-se sempre de enxaguar e enxugar após a lavagem para evitar manchas.", Valor = 2.3m },
            new Produto() { Nome = "Limpador multiuso", Descricao = "Esses produtos têm grande poder desengordurantes e pode ser usado em basicamente todas as superfícies da sua casa: pias, bancadas, vidro, fogão, prateleiras etc.", Valor = 6.99m },
            new Produto() { Nome = "Desinfetante", Descricao = "Desinfetantes são indicados para superfícies de cerâmica e porcelanato, geralmente não precisam ser enxugados e nem enxaguados. Você só precisa diluir em água e passar sobre o piso com um pano limpo.", Valor = 4.59m }
          );
        context.SaveChanges();
      }
      else
      {
        System.Console.WriteLine("Dados já existem.");
      }
    }
  }
}

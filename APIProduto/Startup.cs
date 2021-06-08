using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIProduto.Data;
using APIProduto.Models;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace APIProduto
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIProduto", Version = "v1" });
      });

      //Busca a string de conexão
      var connection = Configuration["ConnectionStrings:APIProdutoContext"];

      //Configura o contexto de banco de dados
      services.AddDbContext<APIProdutoContext>(options =>
                options.UseMySql(connection, ServerVersion.AutoDetect(connection), opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)));
      services.AddScoped<APIProdutoContext, APIProdutoContext>();
      services.AddTransient<IMigrateProduto, DadosIniciaisBD>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

      // Definindo a cultura padrão: pt-BR
      var supportedCultures = new[] { new CultureInfo("pt-BR") };
      app.UseRequestLocalization(new RequestLocalizationOptions
      {
        DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
        SupportedCultures = supportedCultures,
        SupportedUICultures = supportedCultures
      });

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIProduto v1"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}

using BibliotecaJoia.Models.Contexts;
using BibliotecaJoia.Models.Contracts.Contexto;
using BibliotecaJoia.Models.Contracts.Repositories;
using BibliotecaJoia.Models.Contracts.Services;
using BibliotecaJoia.Models.Repositories;
using BibliotecaJoia.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) //modificado inje�ao de dependencia
        {
           

            ConfigureApp(services);
           
            // Inje��o de depend�ncia
            // Registra as implementa��es das interfaces ILivroRepository e ILivroService,
            // para que sejam injetadas automaticamente quando necess�rio.

            AddDependenciesRepositories(services);
            AddDependenciesServices(services);


            // Forma din�mica de indicar qual tipo de DataSource ser� utilizado 
            ConfigureDataSource(services);
        }

        public void ConfigureApp(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromSeconds(120);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        public void AddDependenciesRepositories(IServiceCollection services)
        {
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEmprestimoLivroRepository, EmprestimoLivroRepository>();
          
        }
        public void AddDependenciesServices(IServiceCollection services)
        {
            services.AddScoped<ILivroService, LivroService>(); // Implementar de acordo com o escopo da aplica��o
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IEmprestimoLivroService, EmprestimoLivroService>();
        }

        public void ConfigureDataSource(IServiceCollection services)
        {
            // M�todo que define qual tipo de banco de dados ser� usado.
            // Definindo o tipo de DataSource que ser� usado na aplica��o.
            // Obt�m a configura��o "DataSource" do arquivo de configura��o (appsettings.json) para determinar o tipo de DataSource.
            var datasource = Configuration["DataSource"];

            // Utilizando uma estrutura de switch-case para determinar o tipo de DataSource com base na configura��o obtida.
            switch (datasource) 
            {
                // Caso a configura��o seja "Local", utiliza o ContextDataFake e o ConnectionManagerFake,
                // que s�o implementa��es falsas dos contextos e conex�es para fins de desenvolvimento local e testes.
                case "Local":
                    services.AddSingleton<IContextData, ContextDataFake>();
                    break;
                // Caso a configura��o seja "SqlServer", utiliza o ContextDataSqlServer e o ConnectionManager,
                // que s�o implementa��es para conex�o com o banco de dados SQL Server.
                // O ConnectionManager � registrado como Singleton, ou seja, ser� instanciado apenas uma vez para a aplica��o inteira.
                case "SqlServer":
                    services.AddSingleton<IContextData, ContextDataSqlServer>();
                    services.AddSingleton<IConnectionManager, ConnectionManager>();//instanciando apenas uma vez a classe
                    break;
            }

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();
           
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Usuario}/{action=Index}/{id?}");
            });
        }
    }
}

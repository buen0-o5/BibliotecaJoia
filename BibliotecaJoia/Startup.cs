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
        public void ConfigureServices(IServiceCollection services) //modificado injeçao de dependencia
        {
           

            ConfigureApp(services);
           
            // Injeção de dependência
            // Registra as implementações das interfaces ILivroRepository e ILivroService,
            // para que sejam injetadas automaticamente quando necessário.

            AddDependenciesRepositories(services);
            AddDependenciesServices(services);


            // Forma dinâmica de indicar qual tipo de DataSource será utilizado 
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
            services.AddScoped<ILivroService, LivroService>(); // Implementar de acordo com o escopo da aplicação
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IEmprestimoLivroService, EmprestimoLivroService>();
        }

        public void ConfigureDataSource(IServiceCollection services)
        {
            // Método que define qual tipo de banco de dados será usado.
            // Definindo o tipo de DataSource que será usado na aplicação.
            // Obtém a configuração "DataSource" do arquivo de configuração (appsettings.json) para determinar o tipo de DataSource.
            var datasource = Configuration["DataSource"];

            // Utilizando uma estrutura de switch-case para determinar o tipo de DataSource com base na configuração obtida.
            switch (datasource) 
            {
                // Caso a configuração seja "Local", utiliza o ContextDataFake e o ConnectionManagerFake,
                // que são implementações falsas dos contextos e conexões para fins de desenvolvimento local e testes.
                case "Local":
                    services.AddSingleton<IContextData, ContextDataFake>();
                    break;
                // Caso a configuração seja "SqlServer", utiliza o ContextDataSqlServer e o ConnectionManager,
                // que são implementações para conexão com o banco de dados SQL Server.
                // O ConnectionManager é registrado como Singleton, ou seja, será instanciado apenas uma vez para a aplicação inteira.
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

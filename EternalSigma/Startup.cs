using jbDEV_Eternal.Business.Services;
using jbDEV_Eternal.Domain.Contracts;
using jbDEV_Eternal.Domain.Contracts.Repositories;
using jbDEV_Eternal.Domain.Contracts.Services;
using jbDEV_Eternal.Infra.Connections;
using jbDEV_Eternal.Infra.Uow;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace EternalSigma
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SqlServerDbContext>(opts =>
            opts.UseSqlServer("Server = DESKTOP-PSLQQ7F\\SQLEXPRESS; Database = sigma; User Id = sa; Password = 123456;", 
            server => server.MigrationsAssembly("jbDEV_Eternal.Infra")));

            services.AddMvcCore((opts) =>
            {
                opts.EnableEndpointRouting = false;
            })
            .AddNewtonsoftJson((opts) => 
            {
                opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddScoped<IUow, UnityOfWork>();
            services.AddScoped<ICharacterService, CharacterService>();

            services.AddCors((x) => x.AddPolicy("Dev", op => op.AllowAnyOrigin().AllowAnyMethod()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("Dev");
            }

            app.UseMvc();

        }
    }
}

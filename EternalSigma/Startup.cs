using jbDEV_Eternal.Domain.Constants;
using jbDEV_Eternal.Domain.Contracts;
using jbDEV_Eternal.Infra.Connections;
using jbDEV_Eternal.Infra.Uow;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

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

            services.AddCors((x) => x
                .AddPolicy("Dev", op => op
                    .AllowAnyOrigin()
                    .AllowAnyMethod()));

            services.AddAuthentication(opts => 
            {
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opst => 
            {
                opst.RequireHttpsMetadata = false;
                opst.SaveToken = true;

                opst.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = AuthenticationConfig.Issuer,
                    ValidAudience = AuthenticationConfig.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthenticationConfig.CryptKey)),
                    ValidateIssuer = true,
                    ValidateAudience = true
                };
            });
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

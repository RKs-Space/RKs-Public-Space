using GymService.Middleware;
using GymService.Models;
using GymService.Repository;
using GymService.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace GymService
{
    /*
     * This class should contain method for token validation
     * Details for token validation should be read from appsettings.json file
     */

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
            this.ValidateToken(services);
            services.AddControllers();            
            services.AddScoped<IProgramService, GymService.Service.ProgramService>();
            services.AddScoped<ProgramDbContext>();
            services.AddScoped<IProgramRepository, ProgramRepository>();
        }

        private void ValidateToken(IServiceCollection services)
        {
            var key = "secret_auth_microservice";
            var keyByteArray = Encoding.ASCII.GetBytes(key);
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            var tokenValidationParamters = new TokenValidationParameters {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateAudience = true,
                ValidAudience = "UserClient",
                ValidateIssuer = true,
                ValidIssuer = "UserAuthenticationServer",
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            services.AddAuthentication(options =>
                                       {
                                           options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                                           options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                                       }).AddJwtBearer(o => { o.TokenValidationParameters = tokenValidationParamters; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<LoggingMiddleware>();
            app.UseRouting();
            //added the auth configuration
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Project.Models.Data;
using Project.Models.Repo_s;

namespace Project.API {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            services.AddScoped<IQuizRepo, QuizRepo>();
            services.AddScoped<IQuestionRepo, QuestionRepo>();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();

            services.AddDbContext<ProjectDbContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1.0", new OpenApiInfo {
                    Title = "ToDo_API",
                    Version = "v1.0"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

            app.UseSwagger(); //enable swagger
            app.UseSwaggerUI(c => {
                c.RoutePrefix = "swagger"; //path naar de UI pagina: /swagger/index.html
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "ToDo_API v1.0");
            });
        }
    }
}

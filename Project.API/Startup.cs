using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Project.Models.Data;
using Project.Models.Repo_s;

namespace Project.API {
    public class Startup {

        private readonly IWebHostEnvironment env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env) {
            Configuration = configuration;
            this.env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            services.AddScoped<IQuizRepo, QuizRepo>();
            services.AddScoped<IQuestionRepo, QuestionRepo>();
            services.AddScoped<ISubjectRepo, SubjectRepo>();
            services.AddScoped<IAnswerRepo, AnswerRepo>();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();

            services.AddMvc(options => {
                options.EnableEndpointRouting = false;
                options.RespectBrowserAcceptHeader = true;
            }).AddNewtonsoftJson(options => {
                //circulaire referenties verhinderen door navigatie props
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddDbContext<ProjectDbContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddCors();

            services.AddCors(cfg => {
                cfg.AddPolicy("default", builder => {
                    builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins("http://howest.be , http://mct.be, http://localhost");
                    //iedereen van howest.be en mct.be krijgt access
                });
            });

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
              .AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<ProjectDbContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Tokens:Issuer"],
                        ValidAudience = Configuration["Tokens:Audience"],

                        IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                    };
                    options.SaveToken = false;
                    options.RequireHttpsMetadata = false;
                });

            services.AddSwaggerGen(
             c => {
                c.SwaggerDoc("v1.0", new OpenApiInfo { Title = "Quiz API", Version = "v1.0" });
                // Set the comments path for the Swagger JSON and UI. nodig voor xml te lezen
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                // sets authorization
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. Don't forgot Bearer {{bearertoken}}"
                });

                 c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                     {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { "Bearer "}
                     }
                 });
             });

            if (!env.IsDevelopment()) {
                services.AddHttpsRedirection(options => {
                    //default: 307 redirect
                    // options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
                    options.HttpsPort = 443;
                });

                services.AddHsts(options => {
                    options.MaxAge = TimeSpan.FromDays(40); //default 30
                });
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                //In productie 
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseCors(cfg =>
            {
                cfg.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowCredentials();
            });

            app.UseCors("default");


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger(); //enable swagger
            app.UseSwaggerUI(c => {
                c.RoutePrefix = "swagger"; //path naar de UI pagina: /swagger/index.html
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Quiz_Api v1.0");
            });

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}

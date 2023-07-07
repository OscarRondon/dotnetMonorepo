
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Series_101_5_0_webapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddControllers().AddNewtonsoftJson();
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "myWebApi", 
                    Description = "A Sample ASP.Net Web Api",
                    Contact = new OpenApiContact
                    {
                        Name = "Oscar Rondon",
                        Email = "oscar.rondon.c@treeoflifesoftware.dev",
                        Url = new Uri("https://github.com/OscarRondon")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT Licence",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    },
                    Version = "v1" 
                });

                //Generate the xml docs tha'll drive the swagger docs
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile) ;
                opt.IncludeXmlComments(xmlPath);

                opt.CustomOperationIds(apiDesc =>
                {
                    return apiDesc.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name : null;
                });

            }).AddSwaggerGenNewtonsoftSupport();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(opt =>
                {
                    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "myWebApi v1" );
                    opt.DisplayOperationId();
                });
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
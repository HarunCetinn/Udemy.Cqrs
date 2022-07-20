using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Udemy.Cqrs.CQRS.Handler;
using Udemy.Cqrs.CQRS.Handlers;
using Udemy.Cqrs.Data;

namespace Udemy.Cqrs
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<StudentContext>(opt =>
            {
                opt.UseSqlServer("server =(localdb)\\mssqllocaldb; database=StudentDb; integrated security=true;");
            });

            //services.AddScoped<GetStudentByIdQueryHandler>();
            //services.AddScoped<GetStudentsQueryHandler>();
            //services.AddScoped<CreateStudentCommandHandler>();
            //services.AddScoped<RemoveStudentCommandHandler>();
            //services.AddScoped<UpdateStudentCommandHandler>();
            services.AddMediatR(typeof(Startup));

            services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

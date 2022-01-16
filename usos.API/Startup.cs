using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using usos.API.Application.IServices;
using usos.API.Application.IServices.DegreeCourse;
using usos.API.Application.IServices.Department;
using usos.API.Application.IServices.Questionnarie;
using usos.API.Application.IServices.Subject;
using usos.API.Application.Services;
using usos.API.Application.Services.DegreeCourse;
using usos.API.Application.Services.Department;
using usos.API.Application.Services.Questionnarie;
using usos.API.Application.Services.Subject;
using usos.API.Libraries;

namespace usos.API
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
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            

            services
                .AddControllers()
                .AddNewtonsoftJson(opt => opt.SerializerSettings.Converters.Add(new StringEnumConverter()));
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "usos.API", Version = "v1"}); });

            services.AddDbContext<UsosDbContext>(options =>
                options
                    .UseNpgsql(Configuration.GetConnectionString("UsosDbConnectionString"))
                    .UseSnakeCaseNamingConvention()
            );
            
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDeaneryWorkerService, DeaneryWorkerService>();
            services.AddTransient<IAdvertService, AdvertService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<ILecturerService, LecturerService>();
            services.AddTransient<IDegreeCourseDictionaryService, DegreeCourseDictionaryService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IQuestionnarieService, QuestionnarieService>();
            services.AddTransient<ISubjectService, SubjectService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "usos.API v1");
                    c.RoutePrefix = "";
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
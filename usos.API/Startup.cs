using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using usos.API.Application.IServices;
using usos.API.Application.IServices.Auth;
using usos.API.Application.IServices.AuthHelpers;
using usos.API.Application.IServices.DegreeCourse;
using usos.API.Application.IServices.Department;
using usos.API.Application.IServices.Questionnarie;
using usos.API.Application.IServices.Subject;
using usos.API.Application.Services;
using usos.API.Application.Services.Auth;
using usos.API.Application.Services.AuthHelpers;
using usos.API.Application.Services.DegreeCourse;
using usos.API.Application.Services.Department;
using usos.API.Application.Services.Questionnarie;
using usos.API.Application.Services.Subject;
using usos.API.Configurations;
using usos.API.Extensions;

namespace usos.API
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        public Startup()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.AddAuth(Configuration);
            
            services.AddEmail(Configuration);

            services
                .AddControllers()
                .AddNewtonsoftJson(opt => opt.SerializerSettings.Converters.Add(new StringEnumConverter()));
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "usos.API", Version = "v1"}); });

            services.AddDbContext<UsosDbContext>(options =>
                options
                    .UseNpgsql(Configuration.GetConnectionString("UsosDbConnectionString"))
                    .UseSnakeCaseNamingConvention()
            );
            
            services.AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssembly(typeof(IUsosApp).Assembly);
                opt.ValidatorOptions.PropertyNameResolver = (type, info, arg3) => info?.Name.ToCamelCase();
            });
            
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDeaneryWorkerService, DeaneryWorkerService>();
            services.AddTransient<IAdvertService, AdvertService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<ILecturerService, LecturerService>();
            services.AddTransient<IDegreeCourseDictionaryService, DegreeCourseDictionaryService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IQuestionnarieService, QuestionnarieService>();
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<ICryptService, CryptService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IAuthService, AuthService>();
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

            app.UseAuthentication();
            
            app.UseAuthorization();
            
            app.UseCookiePolicy();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
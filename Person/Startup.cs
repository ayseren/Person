using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Person.Business;
using Person.Repository;
using static System.Net.WebRequestMethods;

namespace Person
{
    public class Startup
    {
        string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            // Database
            services.AddDbContext<PersonContext>();

            // Repository
            services.AddScoped<IPersonRepository, PersonRepository>();

            // Business
            services.AddScoped<IPersonBusiness, PersonBusiness>();

            //Controller
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:3000")
                                            .AllowAnyMethod()
                                            .AllowAnyHeader();
                                  });
            });

            services.AddAutoMapper(typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseRouting() yönlendirme işlemini başlatmadan önce kullanılması gereken bir metottur.
            //Yani, app.UseEndpoints() ile rotaları belirlemek ve istekleri yönlendirmek için önce
            //app.UseRouting() metodu çağrılmalıdır.

            // HTTP isteklerinin yonlendirilmesi icin;
            // yonlendirme islemini baslatir
            app.UseRouting();

            // ikisi arasinda olmali
            app.UseCors();

            // HTTP isteklerinin nasıl yönlendirileceği
            app.UseEndpoints(endpoints =>
            {
                //MapControllers, istegin HTTP metodu ile ilgilenmez,
                //sadece URL rotalarını kontrol eder ve uygun rotaya yönlendirir. 
                endpoints.MapControllers();
            });
        }
    }
}

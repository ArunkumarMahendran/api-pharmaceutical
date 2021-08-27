using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IREPOSITORY = Pharmaceutical.Abstraction.IRepository;
using DATAACCESS = Pharmaceutical.DataAccess;
using REPOSITORY = Pharmaceutical.Abstraction.Repository;
using BUSINESSICONTRACT = Pharmaceutical.BLL.IContractDetails;
using BUSINESSCONTRACT = Pharmaceutical.BLL.ContractDetails;
using System;
using CONS=Pharmaceutical.Common.Constants;
using CORE= Pharmaceutical.Core.Authentication;
using Microsoft.AspNetCore.Authentication;

namespace ToddPharmaceutical
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
           
           
            services.AddControllers().AddNewtonsoftJson();
           
            AddCORS(services);
            
            //Added this context due to reading the claims value in Helper class not from controller
            services.AddHttpContextAccessor();
            
            AddEFConfiguration(services);
            
            AddDepednencyInjection(services);
            
            AddBasicAuthentication(services);

          

        }

        private static void AddCORS(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin());
            });
        }

        private void AddBasicAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(CONS.Constant.BasicAuthentication)
                    .AddScheme<AuthenticationSchemeOptions,CORE.BasicAuthenticationHandler>(CONS.Constant.BasicAuthentication,null);
        }

        private void AddDepednencyInjection(IServiceCollection services)
        {
            services.AddScoped<IREPOSITORY.IContractRepository, REPOSITORY.ContractRepository>();
            services.AddScoped<BUSINESSICONTRACT.IContractDetail, BUSINESSCONTRACT.ContractDetail>();
        }

        private void AddEFConfiguration(IServiceCollection services)
        {
            services.AddDbContextPool<DATAACCESS.ApplicationDBContext>(
                         options => options.UseSqlServer(Configuration.GetConnectionString("PharmaceuticalDBConnection"))
                         );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }
            app.UseCors(options => options.AllowAnyOrigin()
                                         .AllowAnyHeader()
                                         .AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();         
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                .RequireAuthorization();//We can declare [Authorize] attribute in controller as well
            });
        }
    }
}

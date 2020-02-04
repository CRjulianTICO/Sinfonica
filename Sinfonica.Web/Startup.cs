using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sinfonica.Web.Areas.Admin.Data;
using Sinfonica.Web.Areas.Admin.Data.Entities;
using Sinfonica.Web.Areas.Admin.Helpers;

namespace Sinfonica.Web
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



            services.AddDbContext<Areas.Admin.Data.DataContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });




            /*se agreggo*/
            services.AddIdentity<User, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
                cfg.Password.RequireDigit = false;
                cfg.Password.RequiredUniqueChars = 0;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequiredLength = 6;
            })
        .AddEntityFrameworkStores<Areas.Admin.Data.DataContext>();




            #region ADMIN SCOPEDS

            services.AddTransient<SeedDb>();

            services.AddScoped<Sinfonica.Web.Areas.Admin.Data.Repositories.IEventosRepository, Sinfonica.Web.Areas.Admin.Data.Repositories.EventosRepository>();

            services.AddScoped<IUserHelper, UserHelper>();

            services.AddScoped<Sinfonica.Web.Areas.Admin.Data.Repositories.IInsititucionRepository, Sinfonica.Web.Areas.Admin.Data.Repositories.InstitucionRepository>();

            services.AddScoped<Sinfonica.Web.Areas.Admin.Data.Repositories.IProgramaRepository, Sinfonica.Web.Areas.Admin.Data.Repositories.ProgramaRepository>();

            services.AddScoped<Sinfonica.Web.Areas.Admin.Data.Repositories.IDepartamentoRepository, Sinfonica.Web.Areas.Admin.Data.Repositories.DepartamentoRepository>();

            services.AddScoped<Sinfonica.Web.Areas.Admin.Data.Repositories.IPuestoRepository, Sinfonica.Web.Areas.Admin.Data.Repositories.PuestoRepository>();

            services.AddScoped< Sinfonica.Web.Areas.Admin.Data.Repositories.IPruebaRepository, Sinfonica.Web.Areas.Admin.Data.Repositories.PruebaRepository> ();

            services.AddScoped<Sinfonica.Web.Areas.Admin.Data.Repositories.IDirectorRepository, Sinfonica.Web.Areas.Admin.Data.Repositories.DirectorRepository>();

            services.AddScoped<Sinfonica.Web.Areas.Admin.Data.Repositories.IEmpleadoRepository, Sinfonica.Web.Areas.Admin.Data.Repositories.EmpleadoRepository>();

            services.AddScoped<Sinfonica.Web.Areas.Admin.Data.Repositories.IConjuntoRepository, Sinfonica.Web.Areas.Admin.Data.Repositories.ConjuntoRepository>();

            services.AddScoped<ICombosHelper, CombosHelper>();


            #endregion















            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);





            // para las paginas de error, para redireccionar
        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Admin/Account/NotAuthorized";
            options.AccessDeniedPath = "/Admin/Account/NotAuthorized";
        });




        }


        






        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }



            /*se agrego*/
            app.UseAuthentication();




            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();




            app.UseMvc(routes =>
            {
                


                routes.MapRoute(
                      name: "areas",
                      template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );

                routes.MapRoute(
                      name: "areass",
                      template: "{Admin}/{controller=Account}/{action=Login}"
                    );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

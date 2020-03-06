using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FluentValidation.AspNetCore;
using FluentValidation;
using ProfileWebAPI.Models.Profiles;
using ProfileWebAPI.Validators;
using ProfileWebAPI.Filters;

namespace ProfileWebAPI
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

            #region "Validators"
            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
            });

            services.AddMvc(options => 
                {
                options.Filters.Add<ValidationFilter>();
                options.Filters.Add(new HttpResponseExceptionFilter());
                }
            )
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddFluentValidation(
                fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>()
            );

            #endregion

            #region"Data Managers Dependency Injections" 
            services.AddScoped<States.IStateManager,States.StateManagerJson > ();
            services.AddScoped<Profiles.IProfileManager, Profiles.ProfileManager>();
            #endregion

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseCors(builder =>
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseMvc();
        }
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }

        //    //app.UseCors(builder =>
        //    //builder.WithOrigins("http://localhost")
        //    //.WithMethods("GET", "POST", "PUT", "DELETE")
        //    //.AllowAnyHeader());

        //    app.UseMvc();
        //}
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }
        //    else
        //    {
        //        app.UseHsts();
        //    }

        //    app.UseHttpsRedirection();
        //    app.UseMvc();
        //}
    }
}

﻿using GraphiQl;
using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.API.SchemaTypes;
using TodoApi.Core.Repositories;

namespace TodoApi.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<TodoSchema>();
            services.AddSingleton<ITodoRepository, TodoRepository>();
            services.AddGraphQL(
                        x =>
                        {
                            x.ExposeExceptions = true; //dev only
                        })
                    .AddGraphTypes(ServiceLifetime.Scoped)
                    .AddUserContextBuilder(x => x.User)
                    .AddDataLoader();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseGraphiQl("/explore", "/v1/graphql");
            app.UseGraphQL<TodoSchema>("/v1/graphql");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

using System;
using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using MvcSample.Web.Models;
using MvcSample.DB;

namespace MvcSample.Web.ModelsHelloMvc
{
    public class Startup
    {
        
        private MyDbContext context;
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //Define entity framework, adding sqlite driver and dbContext
            services.AddEntityFramework().AddSqlite().AddDbContext<MyDbContext>();
            //create dbContext without dependency injection;
            context = new MyDbContext();
            context.Database.EnsureCreated();
            //create a test user everytime the application starts - just for testing
            this.CreateSampleDatabaseEntry();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {   
            //Standard configuration based on Microsofts supported Sample
            loggerFactory.AddConsole();
            app.UseErrorPage();
            app.UseMvcWithDefaultRoute();
            app.UseWelcomePage();
        }
        
        private void CreateSampleDatabaseEntry(){
            User user = new User()
            {   
                Id = Guid.NewGuid(),
                Name = "My name",
                Address = "My address"
            };
            context.Messages.Add( user );
            context.SaveChanges();
        }
    }
}
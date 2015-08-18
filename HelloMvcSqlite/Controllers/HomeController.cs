using System;
using System.Collections;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Sqlite;
using Microsoft.AspNet.Mvc;
using MvcSample.Web.Models;
using MvcSample.DB;

namespace MvcSample.Web
{
    public class HomeController : Controller
    {
        private MyDbContext dbContext;
        public HomeController(MyDbContext context){
            dbContext = context;
        }
        public IEnumerable Index()
        {
            //Create always a new User and store it into the database
            this.CreateUser();
            //Return all created users as JSON;
            return dbContext.Messages;
        }

        public void CreateUser()
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Name = "My name",
                Address = "My address"
            };
            if(dbContext == null){
                Console.WriteLine("IS NULL");
            }
            dbContext.Messages.Add(user);
            dbContext.SaveChanges();
        }
    }
}
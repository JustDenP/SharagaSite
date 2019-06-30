using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new StoreEntities3())
            {
                var users = context.Users.OrderBy(x => x.Id).ToList();
            }
            return View();
        }

        


        public ActionResult DeleteConfig(int UserId)
        {
            using (var context = new StoreEntities3())
            {
                var user = context.Users.FirstOrDefault(x => x.Id == UserId);
                return View(user);
            }
        }

        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (var context = new StoreEntities3())
            {
                var user = context.Users.FirstOrDefault(x => x.Id == id);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult AddConfig()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string name, int age, string description)
        {
            using (var context = new StoreEntities3())
            {
                context.Users.Add(new ShopApplication.Users
                {
                    Name = name,
                    Age = age,
                    Description = description,
                });
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        
        public ActionResult EditConfig(int UserId)
        {
            using (var context = new StoreEntities3())
            {
                var user = context.Users.FirstOrDefault(x => x.Id == UserId);
                return View(user);
            }
        }


        public ActionResult Edit(int UserId, string name, int age, string description)
        {

            using (var context = new StoreEntities3())
            {
                Users user1 = context.Users.Where(x => x.Id == UserId).FirstOrDefault();
                user1.Id = UserId;
                user1.Name = name;
                user1.Age = age;
                user1.Description = description;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

                
        
    }
}
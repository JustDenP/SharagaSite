using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopApplication.Controllers
{
    public class GoodController : Controller
    {
        // GET: Good
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Good()
        {
            using (var context = new StoreEntities3())
            {
                var goods = context.Goods.OrderBy(x => x.Id).ToList();
            }
            return View();
        }

        public ActionResult gDeleteConfig(int GoodId)
        {
            using (var context = new StoreEntities3())
            {
                var goods = context.Goods.FirstOrDefault(x => x.Id == GoodId);
                return View(goods);
            }
        }
        [HttpPost]
        public ActionResult gDelete(int id)
        {
            using (var context = new StoreEntities3())
            {
                var goods = context.Goods.FirstOrDefault(x => x.Id == id);
                if (goods != null)
                {
                    context.Goods.Remove(goods);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Good");
        }

        public ActionResult gAddConfig()
        {
            using (var context = new StoreEntities3())
            {
                return View();
            }
        }

        public ActionResult gAdd(int id, string name, string description, int cost)
        {
            using (var context = new StoreEntities3())
            {
                var good = context.Goods.Add(new ShopApplication.Goods
                {
                    Id = id,
                    Name = name,
                    Description = description,
                    Cost = cost,
                });
                context.SaveChanges();
            }
            return RedirectToAction("Good");
        }

        public ActionResult gEditConfig(int GoodId)
        {
            using (var context = new StoreEntities3())
            {
                var good = context.Goods.FirstOrDefault(x => x.Id == GoodId);
                return View(good);
            }
        }

        public ActionResult gEdit(int GoodId, string name, string description, int cost)
        {

            using (var context = new StoreEntities3())
            {
                Goods good = context.Goods.Where(x => x.Id == GoodId).FirstOrDefault();
                good.Name = name;
                good.Description = description;
                good.Cost = cost;
                context.SaveChanges();
            }
            return RedirectToAction("Good");
        }
    }
}



using Microsoft.AspNetCore.Mvc;
using SuperMarket.Models;

namespace SuperMarket.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult inventory()
        {
            return View();
        }

        public IActionResult Product()
        {
            using (UserMasterContext db = new UserMasterContext())
            {
                TempData["Product"] = db.products.ToList();
            }
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product pt)
        {
            if (!ModelState.IsValid)
            {
                using (UserMasterContext db = new UserMasterContext())
                {
                    db.products.Add(pt);
                    int count = db.SaveChanges();
                    if (count > 0)
                    {
                        TempData["AddMsg"] = "1";
                        ModelState.Clear();
                    }
                    else
                    {
                        TempData["AddMsg"] = "0";
                    }
                }
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            Product? ss = new Product();
            using (UserMasterContext db = new UserMasterContext())
            {
                ss = db.products.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(ss);
        }

        [HttpPost]
        public IActionResult Edit(Product p)
        {
            using (UserMasterContext db = new UserMasterContext())
            {
                var Result = db.products.Find(p.Id);
                Result.ProductName = p.ProductName;
                Result.ProductCategory = p.ProductCategory;
                Result.Quantity = p.Quantity;
                Result.Price = p.Price;
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["EditMsg"] = "1";
                    ModelState.Clear();
                }
                else
                {
                    TempData["EditMsg"] = "0";
                }

            }
            return RedirectToAction("Product", "Manager");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product ss = new Product();
            using (UserMasterContext db = new UserMasterContext())
            {
                ss = db.products.Where(x => x.Id == id).FirstOrDefault();
                db.products.Remove(ss);
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["DeleteMsg"] = "1";
                    ModelState.Clear();
                }

            }
            return RedirectToAction("Product", "Manager");
        }
        public IActionResult vege()
        {
            using (UserMasterContext db = new UserMasterContext())
            {
                TempData["veg"] = db.vegetables.ToList();
            }
            return View();
        }

        public IActionResult Addveg()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Addveg(Vegetable v)
        {
            if (!ModelState.IsValid)
            {
                using (UserMasterContext db = new UserMasterContext())
                {
                    db.vegetables.Add(v);
                    int count = db.SaveChanges();
                    if (count > 0)
                    {
                        TempData["AddMsg"] = "1";
                        ModelState.Clear();
                    }
                    else
                    {
                        TempData["AddMsg"] = "0";
                    }
                }
            }
            return View();
        }
        public IActionResult Editveg(int id)
        {
            Vegetable? ss = new Vegetable();
            using (UserMasterContext db = new UserMasterContext())
            {
                ss = db.vegetables.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(ss);
        }

        [HttpPost]
        public IActionResult Editveg(Vegetable vg)
        {
            using (UserMasterContext db = new UserMasterContext())
            {
                var Result = db.vegetables.Find(vg.Id);
                Result.ItemName = vg.ItemName;
                Result.Category = vg.Category;
                Result.Quantity = vg.Quantity;
                Result.Price = vg.Price;
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["EditMsg"] = "1";
                    ModelState.Clear();
                }
                else
                {
                    TempData["EditMsg"] = "0";
                }

            }
            return RedirectToAction("vege", "Manager");
        }

        [HttpGet]
        public IActionResult Deleteveg(int id)
        {
            Vegetable vs = new Vegetable();
            using (UserMasterContext db = new UserMasterContext())
            {
                vs = db.vegetables.Where(x => x.Id == id).FirstOrDefault();
                db.vegetables.Remove(vs);
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["DeleteMsg"] = "1";
                    ModelState.Clear();
                }

            }
            return RedirectToAction("vege", "Manager");
        }

        public IActionResult dairy()
        {
            using (UserMasterContext db = new UserMasterContext())
            {
                TempData["milk"] = db.dairies.ToList();
            }
            return View();
        }

        public IActionResult Adddairy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adddairy(Dairy d)
        {
            if (!ModelState.IsValid)
            {
                using (UserMasterContext db = new UserMasterContext())
                {
                    db.dairies.Add(d);
                    int count = db.SaveChanges();
                    if (count > 0)
                    {
                        TempData["AddMsg"] = "1";
                        ModelState.Clear();
                    }
                    else
                    {
                        TempData["AddMsg"] = "0";
                    }
                }
            }
            return View();
        }
        public IActionResult Editdairy(int id)
        {
            Dairy? ss = new Dairy();
            using (UserMasterContext db = new UserMasterContext())
            {
                ss = db.dairies.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(ss);
        }

        [HttpPost]
        public IActionResult Editdairy(Dairy dr)
        {
            using (UserMasterContext db = new UserMasterContext())
            {
                var Result = db.dairies.Find(dr.Id);
                Result.Item = dr.Item;
                Result.Category = dr.Category;
                Result.Quantity = dr.Quantity;
                Result.Price = dr.Price;
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["EditMsg"] = "1";
                    ModelState.Clear();
                }
                else
                {
                    TempData["EditMsg"] = "0";
                }

            }
            return RedirectToAction("Editdairy", "Manager");
        }

        [HttpGet]
        public IActionResult Del(int id)
        {
            Dairy vs = new Dairy();
            using (UserMasterContext db = new UserMasterContext())
            {
                vs = db.dairies.Where(x => x.Id == id).FirstOrDefault();
                db.dairies.Remove(vs);
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["DeleteMsg"] = "1";
                    ModelState.Clear();
                }

            }
            return RedirectToAction("del", "Manager");
        }
        public IActionResult sale()
        {
            using (UserMasterContext db = new UserMasterContext())
            {
                TempData["sale"] = db.bills.ToList();
            }
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SuperMarket.Models;

namespace SuperMarket.Controllers
{
    public class CashierController : Controller
    {
        public IActionResult Customer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Customer(CustomerDetails Customerdetail)
        {

            if (ModelState.IsValid)
            {
                using (UserMasterContext db = new UserMasterContext())
                {
                    db.CustomerDetail.Add(Customerdetail);
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

        public IActionResult Bill()
        {
            using (UserMasterContext db = new UserMasterContext())
            {
                TempData["Bill"] = db.bills.ToList();
            }
            return View();
        }
        public IActionResult AddBill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBill(Bill bill)
        {

            if (!ModelState.IsValid)
            {
                using (UserMasterContext db = new UserMasterContext())
                {
                    db.bills.Add(bill);
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

        public IActionResult EditBill(int id)
        {
            Bill? bb = new Bill();
            using (UserMasterContext db = new UserMasterContext())
            {
                bb = db.bills.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(bb);
        }

        [HttpPost]
        public IActionResult EditBill(Bill b)
        {
            using (UserMasterContext db = new UserMasterContext())
            {
                var Result = db.bills.Find(b.Id);
                Result.ProductName = b.ProductName;
                Result.ProductCategory = b.ProductCategory;
                Result.Quantity = b.Quantity;
                Result.Price = b.Price;
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
            return RedirectToAction("Bill", "Cashier");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Bill bb = new Bill();
            using (UserMasterContext db = new UserMasterContext())
            {
                bb = db.bills.Where(x => x.Id == id).FirstOrDefault();
                db.bills.Remove(bb);
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["DeleteMsg"] = "1";
                    ModelState.Clear();
                }

            }
            return RedirectToAction("Bill", "Cashier");
        }
        public IActionResult Payment()
        {
            using (UserMasterContext db = new UserMasterContext())
            {
                TempData["Bill"] = db.bills.ToList();
            }
            return View();
        }
    }
}

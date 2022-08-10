using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using SuperMarket.Models;


namespace SuperMarket.Controllers
{
    public class UserController : Controller
    {

        
        public IActionResult Category()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SignUp(UserMaster user)
        {

            using (UserMasterContext db = new UserMasterContext())
            {
                db.userMasters.Add(user);
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
            return View();
        }


        //get
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserMaster userMaster)
        {
            using (UserMasterContext db = new UserMasterContext())
            {
                var admin = db.Users.Where(x => x.UserId == userMaster.UserId && x.Password == userMaster.Password);
                if (admin.Count() > 0)
                {
                    var user1 = admin.FirstOrDefault();

                    //HttpContext.Session.SetInt32("role", user1.RoleId);
                    HttpContext.Session.SetString("name", user1.Name);
                    ModelState.Clear();

                    return RedirectToAction("Index", "User");
                }
                else
                {
                    TempData["msg"] = "Incorrect UserId/Password";
                }
            }

            using (UserMasterContext db = new UserMasterContext())
            {
                var login = db.userMasters.Where(x => x.UserId == userMaster.UserId && x.Password == userMaster.Password);
                if (login.Count() > 0)
                {
                    var user = login.FirstOrDefault();

                    HttpContext.Session.SetInt32("role", user.RoleId);
                    HttpContext.Session.SetString("name", user.Name);
                    ModelState.Clear();

                    return RedirectToAction("Index", "User");
                }
                else
                {
                    TempData["msg"] = "Incorrect UserId/Password";
                }
            }
            return View();
        }
      
        public IActionResult Register()
        {
            using (UserMasterContext db = new UserMasterContext())
            {
                TempData["Register"] = db.userMasters.ToList();
            }
            return View();
        }
        public IActionResult Approval()
        {
            using (UserMasterContext db = new UserMasterContext())
            {
                TempData["Register"] = db.userMasters.ToList();
            }
            //using (UserMasterContext db = new UserMasterContext())
            //{
            //    var approval = db.userMasters.Where(x => x.Id == id).FirstOrDefault();
            //}            
            return View();
        }
              
        [HttpGet]
        public IActionResult Cancel(int id)
        {
            UserMaster ss = new UserMaster();
            using (UserMasterContext db = new UserMasterContext())
            {
                ss = db.userMasters.Where(x => x.Id == id).FirstOrDefault();
                db.userMasters.Remove(ss);
                int count = db.SaveChanges();
                if (count > 0)
                {                    
                    TempData["CancelMsg"] = "1";
                    ModelState.Clear();
                }

            }
            return RedirectToAction("Register", "User");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

       
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "User");
        }
    }
}

//Entity Sınıfları denilen applicatipnRole ve ApplicationUser sınıflarını yönetecek bir datacontext eklememiz gerekir.
using Microsoft.AspNet.Identity; //UserManager için
using Microsoft.AspNet.Identity.EntityFramework;//UserStore için
using Microsoft.Owin.Security; //AuthenticationProperties
using e_commerce_internship.Entity;
using e_commerce_internship.Identity; // ApplicationUser için
using e_commerce_internship.Models; //Register classı 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_commerce_internship.Controllers
{
    public class AccountController : Controller
    {
        DataContext db = new DataContext(); //Veri tabanına bağlantı

        private UserManager<ApplicationUser> UserManager;//kullanıcı oluşturmaya ve var olan kullanıcıları yönetmeye yarar
        private RoleManager<ApplicationRole> RoleManager;//Rollerin yetkilerini düzenler
        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }


        public ActionResult Logout() //GET
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        // GET: Account
        public ActionResult Login() //GET
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login model, string returnUrl) //POST
        {
            if (ModelState.IsValid) 
            {
                var user = UserManager.Find(model.Username, model.Password);
                if (user!=null) //nuget paketlerinden Microsoft.Owin.Host.SystemWeb indirilir
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var IdentityClaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, IdentityClaims);
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Kullanıcı bulunamadı");
                }
            }
            return View(model);
        }

        public ActionResult Register() //GET
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register model) //POST
        {
            if (ModelState.IsValid) //Kullanıcı gerekli alanları doğru doldurmuşsa işlemleri yapsın
            {
                var user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.UserName = model.Username;
                var result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account"); //işlem vaşarılı olduysa giriş sayfasına yönlendirilir                
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturulurken bir hata oluştu.");
                }
            }
            return View(model);
        }

        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var orders = db.Orders.Where(i => i.Username == username).Select(i => new UserOrder
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderState = i.OrderState,
                OrderTime = i.OrderTime,
                TotalPrice = i.TotalPrice
            }).OrderByDescending(i => i.OrderTime).ToList();
            return View(orders);
        }

        public ActionResult Details(int id)
        {
            var model = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetails()
            {
                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                TotalPrice = i.TotalPrice,
                OrderDate = i.OrderTime,
                OrderState = i.OrderState,
                Address = i.Address,
                Sehir = i.Sehir,
                Semt = i.Semt,
                PostaKodu = i.PostaKodu,
                OrderLines = i.OrderLine.Select(x => new OrderLineModel()
                {
                    ProductId = x.ProductId,
                    Image = x.Product.image,
                    ProductName = x.Product.name,
                    Quantity = x.Quantity,
                    Price = x.Price
                }).ToList()
            }).FirstOrDefault();
            return View(model);
        }


        public ActionResult UserProfile() //GET
        {
            var id = HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId(); //Giriş yapmış olan kullanıcının idsini getirir
            var user = UserManager.FindById(id);
            var data = new UserProfile()
            {
                id = user.Id,
                name = user.Name,
                surname = user.Surname,
                username = user.UserName,
                email = user.Email
            };
            return View(data);
        }
        [HttpPost]
        public ActionResult UserProfile(UserProfile model) //POST
        {
            var user = UserManager.FindById(model.id);
            user.Name = model.name;
            user.Surname = model.surname;
            user.UserName = model.username;
            user.Email = model.email;
            UserManager.Update(user);
            return View("Update");
        }

        public ActionResult ChangePassword() //GET
        {
            
            return View();
        }
        [HttpPost]
        [Authorize] //ancak login olanlar bu sayfaya gelebilir
        public ActionResult ChangePassword(ChangePassword model) //GET
        {
            if (ModelState.IsValid)
            {
                var result = UserManager.ChangePassword(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
                return View("Update");
            }

            return View(model);
        }

        public PartialViewResult UserCount()
        {
            var u = UserManager.Users;
            return PartialView(u);
        }

        public ActionResult UserList()
        {
            var u = UserManager.Users;
            return View(u);
        }
    }
}
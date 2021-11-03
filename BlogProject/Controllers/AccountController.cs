using BlogProject.Models;
using BlogProject.Models.Entities;
using BlogProject.Models.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class AccountController : Controller
    {
        UserManager<AppUser> userManager;
        RoleManager<AppRole> roleManager;
        SignInManager<AppUser> signInManager;
        IWebHostEnvironment environment;
        BlogDbContext blogDbContext;
        public AccountController(UserManager<AppUser> um,RoleManager<AppRole> rl,SignInManager<AppUser> sm,IWebHostEnvironment whe,BlogDbContext bdc)
        {
            userManager = um;
            roleManager = rl;
            signInManager = sm;
            environment = whe;
            blogDbContext = bdc;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AccountUserVM model)
        {
            //AppUser user = new AppUser();
            //user.Email = model.Email;
            //user.UserName = model.Email;

            //modelden gelen email ile kullanıcı buluyoruz
            AppUser user = await userManager.FindByEmailAsync(model.Email); //email ile kullanıcı buluyoruz.

            if (user==null)
            {
                ViewData["Mesaj"] = "Email adresiniz hatalı";
            }
            var result=await signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded) //Başarılı ise ...
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Mesaj"] = "Hatalı şifre";
            }

            return View();

        }

        public IActionResult Register()
        {
            return View();
            
        }


        [HttpPost]
        public async Task< IActionResult> Register(AccountUserVM model)
        {
            if (!await roleManager.RoleExistsAsync("user")) // veritabanında kontrol eder.
            {
                AppRole role = new AppRole();
                role.Name = "user";

                await roleManager.CreateAsync(role);  // veri tabanına role ekle ..
            }
            AppUser user = new AppUser();
            user.UserName = model.Email;
            user.Email = model.Email;
            user.FullName = model.FullName;

            var result = await userManager.CreateAsync(user, model.Password); // kulanıcıyı veritabanına ekle
           


            if (result.Succeeded) // kayıt yapıldıysa 
            {
                var roleResult = await userManager.AddToRoleAsync(user, "user"); // kullanıcıya rol ekle 

                ViewData["Mesaj"] = "Kayıt işleminiz başaralı.";
            }
            else
            {
                ViewData["Mesaj"] = "Kayıt işleminiz yapılmadı.Litfen bilgilerini kontrol ediniz";
            }


            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home"); // anasayfaya yönlendir
        }
        public IActionResult UpdateProfile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdatePhoto(IFormFile file)
        {
            var path = Path.Combine(environment.WebRootPath, "UploadProfilePicture/")+file.FileName;
            FileStream st = new FileStream(path, FileMode.Create);
            file.CopyTo(st);

            AppUser user = blogDbContext.Users.FirstOrDefault(c => c.Email == User.Identity.Name);
            user.PicturePath = file.FileName;
            blogDbContext.SaveChanges();

            return View("UpdateProfile");
        }





    }
}

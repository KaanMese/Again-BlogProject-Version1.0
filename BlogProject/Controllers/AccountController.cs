using BlogProject.Models;
using BlogProject.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class AccountController : Controller
    {
        UserManager<AppUser> userManager;
        RoleManager<AppRole> roleManager;
        public AccountController(UserManager<AppUser> um,RoleManager<AppRole> rl)
        {
            userManager = um;
            roleManager = rl;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
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

    }
}

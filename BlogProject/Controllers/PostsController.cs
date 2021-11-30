using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogProject.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Controllers
{
    public class PostsController : Controller
    {

        BlogDbContext dbContenxt;
        public PostsController(BlogDbContext _blogDbContext)
        {
            dbContenxt = _blogDbContext;
        }

        // KategoriID gönderecğeiz..
        public IActionResult Index(int ID)
        {
            var result = dbContenxt.Contents.Include(c => c.Comments).Where(c => c.CategoryID == ID).ToList();

            return View(result);
        }

        // ContentID'yi gönderecğeiz...
        public IActionResult Detail(int ID)
        {
            var result = dbContenxt.Contents.Include(c => c.Comments).FirstOrDefault(c => c.ID == ID); // ID'si gönderilen Cntent

            // okuma sayısını arttırılaım...
            result.ViewCount = result.ViewCount + 1;

            dbContenxt.SaveChanges(); // değişikliği kaydet...

            return View(result);
        }
    }
}
using BlogProject.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        BlogDbContext blogDbContext;
        public CategoriesViewComponent(BlogDbContext db)
        {
            blogDbContext = db;
        }
        public IViewComponentResult Invoke()
        {
            List<Category> katList = blogDbContext.Categories.ToList();
            return View(katList);

        }
    }
}

using BlogProject.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Components
{
    public class ProfilePhotoViewComponent: ViewComponent
    {
        BlogDbContext blogDbContext;
        public ProfilePhotoViewComponent(BlogDbContext db)
        {
            blogDbContext = db;
        }
        public IViewComponentResult Invoke()
        {
            string filePicturePath = "/assets/images/profile.png";

            if (User.Identity.IsAuthenticated)
            {
                var user = blogDbContext.Users.FirstOrDefault(c => c.Email == User.Identity.Name);
                if (user.PicturePath != null)
                {
                    filePicturePath = "/UploadProfilePicture/" + user.PicturePath;
                }
            }
            ViewData["photoPath"] = filePicturePath;
            return View<string>(filePicturePath);
            
        }

    }
}

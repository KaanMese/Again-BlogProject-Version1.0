﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class PostsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Detail()
        {
            return View();
        }
    }
}

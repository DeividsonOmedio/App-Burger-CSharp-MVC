﻿using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
    public class MaterialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

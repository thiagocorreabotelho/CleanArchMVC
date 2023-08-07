﻿using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}

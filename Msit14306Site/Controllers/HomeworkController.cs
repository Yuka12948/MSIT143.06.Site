using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Msit14306Site.Controllers
{
    public class HomeworkController : Controller
    {
        public IActionResult Homework()
        {
            return View();
        }
    }
}

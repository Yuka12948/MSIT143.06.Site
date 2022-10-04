using Microsoft.AspNetCore.Mvc;
using Msit14306Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Msit14306Site.Controllers
{
    public class ApiController : Controller
    {
        //http://localhost.../api/index
        public IActionResult Index(string keyword)
        {
            if (String.IsNullOrEmpty(keyword))
            {
                keyword = "Ajax";
            }
            //回應單純字串 "Hello Ajax"
            return Content($"{keyword}, Hello!", "text/html", System.Text.Encoding.UTF8);
        }

        public IActionResult First()
        {
            return View();
        }

        public IActionResult Homework()
        {
            return View();
        }

        public IActionResult GetDemo()
        {
            return View();
        }
        public IActionResult AjaxEvent()
        {
            return View();
        }

        public IActionResult Sleep()
        {
            System.Threading.Thread.Sleep(5000); //停五秒鐘
            return Content("hello Ajax Event", "text/html", System.Text.Encoding.UTF8);
        }

        public IActionResult Register(Member member)
        {
            //todo 將收到會員資料寫進資料庫中

            return Content(member.Name, "text/plain");
        }

    }
}

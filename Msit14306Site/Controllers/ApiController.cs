using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Msit14306Site.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Msit14306Site.Controllers
{
    public class ApiController : Controller
    {
        private readonly IWebHostEnvironment _host;
        private readonly DemoContext _context; //宣告廣域變數

        public ApiController(IWebHostEnvironment host, DemoContext context) //相依性注入
        {
            _host = host;
            _context = context;
        }

        //http://localhost.../api/index
        public IActionResult Index(string keyword) //接收client傳過來的資料
        {
            if (String.IsNullOrEmpty(keyword))
            {
                keyword = "Ajax";
            }
            //回應單純字串 "Hello Ajax"
            return Content($"{keyword}, Hello!", "text/html", System.Text.Encoding.UTF8);
        }

        public IActionResult Sleep()
        {
            System.Threading.Thread.Sleep(5000); //停五秒鐘
            return Content("hello Ajax Event", "text/html", System.Text.Encoding.UTF8);
        }

        public IActionResult Register(Member member,IFormFile File) //用類別Member來接資料  //IFormFile的file命名要跟<input type="file" name="File">裡的Name屬性一樣
        {

            //_host.WebRootPath(//E:\C#\MSIT143.06.Site\Msit14306Site\wwwroot) + 資料夾(uploads) + 上傳的檔案名字(XXX.PNG)
            string filePath = Path.Combine(_host.WebRootPath, "uploads", File.FileName); //E:\C#\MSIT143.06.Site\Msit14306Site\wwwroot\uploads\IMG_2300.PNG           

            //將檔案存到filePath(實體資料夾)中
            using (var fileStream = new FileStream(filePath,FileMode.Create))
            {
                File.CopyTo(fileStream);
            }

            //將檔案轉成二進位存到資料庫
            byte[] imgByte = null;

            using (var memoryStream = new MemoryStream())
            {
                File.CopyTo(memoryStream);
                imgByte = memoryStream.ToArray();
            }
            member.FileName = File.FileName;
            member.FileData = imgByte;

            //檔案上傳要知道實際路徑
            //不能在程式碼中這樣寫 因為路徑可能會改變
            //C:\Inetpub\wwwroot\Msit143Site\wwwroot\uploads
            //E:\C#\MSIT143.06.Site\Msit14306Site\wwwroot\uploads\
            //要透過程式動態取得程式執行當下的實際路徑
            //取得wwwroot實際路徑
            //string info = _host.WebRootPath; //E:\C#\MSIT143.06.Site\Msit14306Site\wwwroot
            //取得專案資料夾實際路徑
            //string info = _host.ContentRootPath; //E:\C#\MSIT143.06.Site\Msit14306Site

            //string info = $"{File.FileName} - {File.ContentType} - {File.Length}";
            //return Content(info, "text/plain");

            //todo 將收到會員資料寫進資料庫中
            _context.Members.Add(member);
            _context.SaveChanges(); //資料庫Demo id PK

            return Content(filePath, "text/plain");



            //return Content(member.Name, "text/plain");
        }

        //public IActionResult checkedData(string Name)
        //{
        //    bool isExist = _context.Members.Any(m => m.Name == Name);
        //    if (string.IsNullOrEmpty(Name))
        //        return Content("姓名欄位不可為空值", "text/plain");
        //    else if (isExist)
        //        return Content("此帳號已存在", "text/plain");
        //    else
        //        return Content("" ,"text/plain");
        //}

        //讀取所有城市的資料
        public IActionResult City()
        {
            var cities = _context.Addresses.Select(a => a.City).Distinct();
            return Json(cities);
        }

        //根據城市名稱讀取鄉鎮區的資料
        public IActionResult Site(string city)
        {
            var sites = _context.Addresses.Where(a => a.City == city).Select(a=>a.SiteId).Distinct();
            return Json(sites);
        }

        //根據鄉鎮區名稱讀取路的資料
        public IActionResult Road(string site)
        {
            var roads = _context.Addresses.Where(a => a.SiteId == site).Select(a => a.Road).Distinct();
            return Json(roads);
        }
    }
}

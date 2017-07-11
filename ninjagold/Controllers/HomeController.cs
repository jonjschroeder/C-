using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace rndWordGen.Controllers
{
    public class HomeController : Controller
    {
        public string rndWord(int length)
        {
            string word="";
            char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            Random random = new Random();
            for (int i=0; i<=length; i++)
            {
                word += chars[random.Next(0, chars.Length)];
            }
            return word;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Count")==null)
            {
                HttpContext.Session.SetInt32("Count", 1);
            }
            else if(HttpContext.Session.GetObjectFromJson<DojodachiInfo>("Dojodachi") == null){
                HttpContext.Session.SetObjectAsJson("Dojodachi", new DojodachiInfo());
            }
            else  
            {
                HttpContext.Session.SetInt32("Count", HttpContext.Session.GetInt32("Count").Value+1);
            }

            ViewBag.rndWord = rndWord(14);
            ViewBag.count = HttpContext.Session.GetInt32("Count").Value;

            
            return View("Index");
        }

    }
}
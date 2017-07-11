using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace YourNamespace.Controllers
{
    public class HelloController : Controller
        {
                public string rndWord(int length){
                    string word = "";
                    char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
                    Random random = new Random();
                    for (int i=0; i<=length; i++)
            {
                    word += chars[random.Next(0, chars.Length)];
            }
            return word;

            } 

                [HttpGet]
                [Route("")]
                public IActionResult Index()
            {
            int? count = HttpContext.Session.GetInt32("Count");
            if (count ==null)
            {
                count = 1;
            }
            count += 1;

            ViewBag.rndWord = rndWord(14);
            ViewBag.count = count;
            return View("Index");
        }
    
                [HttpGet]
                [Route("/project")]
                public IActionResult Project()
        {

            //OR
            return View("Project");
            //Both of these returns will render the same view (You only need one!)
        }
                [HttpGet]
                [Route("contact")]
                public IActionResult Contact()
        {

            //OR
            return View("Contact");
            //Both of these returns will render the same view (You only need one!)
        }
                [HttpPost]
                [Route("/result")]
                public IActionResult dispaly(string firstname, string lastname, string comment)
                
        {

            //OR
            ViewBag.fname = firstname;
            ViewBag.lname = lastname;
            ViewBag.com = comment;
            
            return View("display");
            //Both of these returns will render the same view (You only need one!)

        }
    }
}
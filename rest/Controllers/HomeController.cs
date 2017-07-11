using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Data;
using rest.Models;
using System.Linq;
using rest;

namespace rest.Controllers

{
 
    public class HomeController : Controller
    {
           private YourContext _context;
 
        public HomeController(YourContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(User NewUser)
        {
    
                _context.Add(NewUser);
    // OR _context.Users.Add(NewPerson);
                _context.SaveChanges();
                return RedirectToAction("Get");
        }
        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {

            ViewBag.hello = _context.Users.OrderByDescending(x => x.date);
            return View("newpage");
            
        }
    }
}

        
       

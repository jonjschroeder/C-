using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using subway.Models;
using System.Data;
using Microsoft.AspNetCore.Server.Kestrel.Internal.Http;

namespace subway.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;
 
        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Users = _dbConnector.Query("SELECT * FROM Users");
            ViewBag.Errors = new List<string>();
            return View();
        }   
        [HttpGet]
        [Route("success")]
        public IActionResult sucpage(){
            return View("success");
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string email, string password)
        {
            var CheckUser = _dbConnector.Query($"SELECT * FROM Users WHERE email = '{email}'");
            
            
            if(CheckUser.Count != 0){
       
            if((string)CheckUser[0]["password"] == password){
                return RedirectToAction("sucpage");
                }  
            }
            return View("Index");
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(User NewUser)
        {

            TryValidateModel(NewUser);
            if(ModelState.IsValid){
                _dbConnector.Execute($"INSERT INTO Users (first_name, last_name, email, password) VALUES ('{NewUser.FirstName}', '{NewUser.LastName}', '{NewUser.Email}', '{NewUser.Password}')");
                return View("success");
            }
            ViewBag.errors = ModelState.Values;
            

            return View("Index");
            
        }    
    }
}

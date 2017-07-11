using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace quotingdojo.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Users = DbConnector.Query("SELECT * FROM Quoting");
            return View();
        }
        [HttpPost]
        [Route("add")]
        public IActionResult Add(string name, string quote)
        {
            ViewBag.Users = DbConnector.Query($"INSERT INTO Quoting (name, quote) VALUES ('{name}', '{quote}')");
            ViewBag.Users = DbConnector.Query("SELECT * FROM Quoting");
            return View("newpage");
        }
        [HttpGet]
        [Route("delete")]
        public IActionResult Delete(int idQuoting){
            DbConnector.Execute("DELETE FROM Quoting WHERE idQuoting = idQuoting");
            return RedirectToAction("Add");
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Dojodachi;
using Microsoft.AspNetCore.Http;

namespace dojodachi.Controllers
{
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
        public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetObjectFromJson<Dojo>("Dojodachi") == null){
                HttpContext.Session.SetObjectAsJson("Dojodachi", new Dojo());
            }
            if(HttpContext.Session.GetString("log") != null){
            ViewBag.log = HttpContext.Session.GetString("log");
            }
            ViewBag.Dojodachi = HttpContext.Session.GetObjectFromJson<Dojo>("Dojodachi");
            return View();
        }
    
         [HttpGet]
         [Route("feed")]
         public IActionResult Feed(){
            System.Console.WriteLine("feeding");
            Dojo dachi = HttpContext.Session.GetObjectFromJson<Dojo>("Dojodachi");
            Random rand = new Random();
            
            if(dachi.Meals == 0){
                HttpContext.Session.SetString("log", "Your Dachi is hungry and would like a meal!");
            }
            else{
                dachi.Meals -=1;
                int newfull = rand.Next(5, 11);
                dachi.Fullness += newfull;
            }
             HttpContext.Session.SetObjectAsJson("Dojodachi", dachi);
             return RedirectToAction("Index");
         }   
            
            
            // GET: /play/
        [HttpGet]
        [Route("play")]
        public IActionResult Play()
        {
            System.Console.WriteLine("playing");
            Dojo dachi = HttpContext.Session.GetObjectFromJson<Dojo>("Dojodachi");
            Random rand = new Random();

            if(dachi.Energy == 0){
                System.Console.WriteLine("out of energy....");
                HttpContext.Session.SetString("log", "Your Dachi needs a rest.  He has no more energy");
            } else {
                dachi.Energy -= 5;

                if(rand.Next(1,4) == 1){
                    HttpContext.Session.SetString("log","Your Dachi is just going to chill");
                } else {
                    int newHappiness = rand.Next(5, 11);
                    dachi.Happiness += newHappiness;
                    HttpContext.Session.SetString("log", $"Your Dachi gained {newHappiness} happiness!");
                }
                HttpContext.Session.SetObjectAsJson("Dojodachi", dachi);
                
            }
 
                return RedirectToAction("Index");
        }
                [HttpGet]
        [Route("sleep")]
        public IActionResult Sleep()
        {
            System.Console.WriteLine("sleeping");
            Dojo dachi = HttpContext.Session.GetObjectFromJson<Dojo>("Dojodachi");

            if(dachi.Fullness == 0){
                HttpContext.Session.SetString("log", "Your Dachi needs to eat something before he sleeps");
            } else if(dachi.Happiness == 0) {
                HttpContext.Session.SetString("log", "Dachi is depressed.  He needs to be more happy to sleep");
            }else  {
                dachi.Fullness -= 5;
                dachi.Happiness -= 5;
                dachi.Energy += 15;
                HttpContext.Session.SetString("log", "15 energy for a great nights sleep");
            }
            HttpContext.Session.SetObjectAsJson("Dojodachi", dachi);
            return RedirectToAction("Index");

        }
                [HttpGet]
        [Route("work")]
        public IActionResult Work()
        {
            System.Console.WriteLine("working");
            Dojo dachi = HttpContext.Session.GetObjectFromJson<Dojo>("Dojodachi");
            Random rand = new Random();

            if(dachi.Energy == 0){
                System.Console.WriteLine("out of energy....");
                HttpContext.Session.SetString("log", "No more energy!  Dachi should sleep");
            } else {
                dachi.Energy -= 5;
                int newMeals = rand.Next(1, 4);
                dachi.Meals += newMeals;
                HttpContext.Session.SetString("log", $"Dachi has earned {newMeals} meals!");
            }
            HttpContext.Session.SetObjectAsJson("Dojodachi", dachi);

            return RedirectToAction("Index");

        }
    }
}



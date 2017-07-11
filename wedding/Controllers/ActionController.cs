using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using wedding.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace wedding.Controllers
{
    public class ActionController : Controller
    {
            private YourContext _context;
 
            public ActionController(YourContext context)
    {
        _context = context;
       
       
        }  
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(WeddingViewModel model){

            List<string> allErrors = new List <string>();
            User CurrentUser = _context.Users.SingleOrDefault(person => person.UserId == (int)HttpContext.Session.GetInt32("CurrentUserId"));
            System.Console.WriteLine("In Register***********************************************");
            System.Console.WriteLine(model);
            if (ModelState.IsValid){
                Wedding newWedding = new Wedding{
                    WedderOne = model.WedderOne,
                    WedderTwo = model.WedderTwo,
                    Date = model.Date,
                    Address = model.Address,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    UserId = CurrentUser.UserId,
                };
                
                System.Console.WriteLine(newWedding);
                _context.Add(newWedding);
                _context.SaveChanges();
                // HttpContext.Session.SetInt32("CurrentUserId", newWedding.UserId); This is how to set Http Session currid to newwedding.userid...dont need this here
                return RedirectToAction("showpage", new { id = newWedding.WeddingId });
            }
                System.Console.WriteLine("Not Good***********************************************");
                ViewBag.Errors = ModelState.Values;
            {
                    foreach(var error in ViewBag.Errors)
            {
           
                    if(error.Errors.Count > 0)
            {  
                System.Console.WriteLine(error.Errors[0].ErrorMessage);  
            }
        }
    }
                System.Console.WriteLine("Hello____________________*********");
            
            return View("planpage");
        } 
        [HttpGet]
        [Route("showpage/{id}")]
        
        public IActionResult showpage(int id){
            if (HttpContext.Session.GetInt32("CurrentUserId") == null ){
                return RedirectToAction("Index", "Home");
                        }
            Wedding CurrentWedding = _context.Weddings
                .Where(WeddingId => WeddingId.WeddingId == id)
                .Include(guests => guests.Invitations)
                .ThenInclude(guest => guest.User)
                .SingleOrDefault();
            ViewBag.CurrentWedding = CurrentWedding;

            ViewBag.wedid = id;
            int? sessionid = HttpContext.Session.GetInt32("CurrentUserId");
            ViewBag.sessionid = sessionid;
            List <Invitation> invite = _context.Invitations.ToList();
            ViewBag.invite = invite;
            List <Invitation> query = _context.Invitations.Where(x => x.UserId == sessionid).Include(x => x.User).ToList();
            ViewBag.query = query;
            ViewBag.userquery = _context.Invitations
                .Where(x => x.UserId == sessionid);
            ViewBag.newquery = _context.Invitations
                .Where(x => x.WeddingId == id);
            ViewBag.querywed = _context.Weddings
                    .Where(x => x.WeddingId == id)
                    .Include(x => x.User)
                    .SingleOrDefault();
            List <Wedding> allinvites = _context.Weddings.Include(y => y.Invitations).ToList();  //Select * From Weddings and include the invitations list
            ViewBag.allinvites = allinvites;
            ViewBag.Id = HttpContext.Session.GetInt32("CurrentUserId");

           
            
            return View("showpage");
        }
        [HttpGet]
        [Route("Dashboard")]
        public IActionResult Dashboard(){
                if (HttpContext.Session.GetInt32("CurrentUserId") == null ){
                return RedirectToAction("Index", "Home");
                        }
              List <Wedding> wed = _context.Weddings.ToList();  // SELECT * FROM Weddings
              List <Invitation> invite = _context.Invitations.ToList(); // SELECT * FROM Invitations
            List <Wedding> allinvites = _context.Weddings.Include(y => y.Invitations).ToList();  //Select * From Weddings and include the invitations list
            ViewBag.allinvites = allinvites;
            ViewBag.invite = invite;
              ViewBag.AllWeddings = wed;
              ViewBag.UserName = HttpContext.Session.GetString("UserName");
              ViewBag.Id = HttpContext.Session.GetInt32("CurrentUserId");
           

        return View("Dashboard");
        }
        [HttpPost]
        [Route("RSVP/{id}")]
        public IActionResult RSVP(int id){

            int CurrentUser = (int)HttpContext.Session.GetInt32("CurrentUserId");
            
            Invitation NewInvite = new Invitation{
                UserId = CurrentUser,
                WeddingId = id
            };
            _context.Add(NewInvite);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
                [HttpPost]
        [Route("Showpage/RSVP/{id}")]
        public IActionResult RSVPshow(int id){
            if (HttpContext.Session.GetInt32("CurrentUserId") == null ){
                return RedirectToAction("Index", "Home");
                        }
            int CurrentUser = (int)HttpContext.Session.GetInt32("CurrentUserId");
            
            Invitation NewInvite = new Invitation{
                UserId = CurrentUser,
                WeddingId = id
            };
            _context.Add(NewInvite);
            _context.SaveChanges();
            return RedirectToAction("Showpage", new { id = id });
        }
        [HttpGet]
        [Route("UnRSVP/{id}")]
        public IActionResult UnRSVP(int id){
            if (HttpContext.Session.GetInt32("CurrentUserId") == null ){
                return RedirectToAction("Index", "Home");
                        }
            int CurrentUser = (int)HttpContext.Session.GetInt32("CurrentUserId");
            Invitation UnRSVP = _context.Invitations
            .Where(user => user.UserId == CurrentUser)
            .Where(wedding => wedding.WeddingId == id)
            .SingleOrDefault();
            _context.Remove(UnRSVP);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        [HttpGet]
        [Route("Showpage/UnRSVP/{id}")]
        public IActionResult UnRSVPshow(int id){
            if (HttpContext.Session.GetInt32("CurrentUserId") == null ){
                return RedirectToAction("Index", "Home");
                        }
            int CurrentUser = (int)HttpContext.Session.GetInt32("CurrentUserId");
            Invitation UnRSVP = _context.Invitations
            .Where(user => user.UserId == CurrentUser)
            .Where(wedding => wedding.WeddingId == id).SingleOrDefault();
            _context.Remove(UnRSVP);
            _context.SaveChanges();
            return RedirectToAction("Showpage", new { id = id });
        }
        [HttpGet]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id){
            if (HttpContext.Session.GetInt32("CurrentUserId") == null ){
                return RedirectToAction("Index", "Home");
                        }
            Wedding DeleteWedding = _context.Weddings
                .Where(wedding => wedding.WeddingId == id)
                .Include(a => a.Invitations)
                .SingleOrDefault();
            //Remove 
            
            _context.Remove(DeleteWedding);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        } 
        [HttpGet]
        [Route("Showpage/Delete/{id}")]
        public IActionResult Deleteshow(int id){
            if (HttpContext.Session.GetInt32("CurrentUserId") == null ){
                return RedirectToAction("Index", "Home");
                        }
            Wedding DeleteWedding = _context.Weddings
                .Where(wedding => wedding.WeddingId == id)
                .Include(a => a.Invitations)
                .SingleOrDefault();
            //Remove 
            
            _context.Remove(DeleteWedding);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }     
    }   
}

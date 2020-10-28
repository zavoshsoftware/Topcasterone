using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helpers;
using ViewModels;
using Models;

namespace TopCaster.Controllers
{
    public class HomeController : Controller
    {
       
        private DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            HomeViewModel home = new HomeViewModel();

          
            home.Sliders = db.Sliders.Where(current => current.IsDeleted == false && current.IsActive == true).ToList();
            home.UnderSliderText = db.TextTypeItems.Where(current => current.TextType.Title.ToLower()== "underslider").ToList();
            home.TeamMembers=db.Teams.Where(current => current.IsDeleted == false && current.IsActive == true).OrderBy(current=>current.CreationDate).ToList();
            home.About = db.TextTypeItems.Where(current => current.Name.ToLower().Contains("about")).FirstOrDefault();
            home.History= db.TextTypeItems.Where(current => current.Name.ToLower().Contains("history")).FirstOrDefault();
            home.Proccess = db.TextTypeItems.Where(current => current.Name.ToLower().Contains("Processing")).FirstOrDefault();
            home.TechText = db.TextTypeItems.Where(current => current.TextType.Title.ToLower().Contains("technology")).OrderBy(current=>current.CreationDate).ToList();
            home.Products = db.Products.Where(current => current.IsDeleted == false && current.IsActive == true).ToList();
            home.LatestBlogs = db.Blogs.Where(c => c.IsDeleted == false && c.IsActive)
                .OrderByDescending(c => c.CreationDate).Take(4).ToList();
            return View(home);
        }

        [Route("about")]
        public ActionResult About()
        {
            HomeViewModel home = new HomeViewModel();


            return View(home);
        }
        [Route("contact")]
        public ActionResult Contact()
        {
            ContactViewModel home = new ContactViewModel();


            return View(home);
        }

     
    }
}
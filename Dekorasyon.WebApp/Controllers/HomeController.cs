using BLL;
using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Dekorasyon.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private ContactManager contactManager = new ContactManager();
        private PostManager postManager = new PostManager();
        private AboutManager aboutManager = new AboutManager();
        // GET: Home
        public ActionResult Index()
        {
            return View(postManager.ListQueryable().Where(x => x.IsDraft == false).OrderByDescending(x => x.ModifiedOn).ToList());
        }
        public ActionResult About()
        {
            aboutManager.List();
            return RedirectToAction("_AboutPartial");
        }
        public ActionResult Banner()
        {
            aboutManager.List();
            return RedirectToAction("_");
        }
        public ActionResult Contact(Contact contact)
        {

            contactManager.Insert(contact);
            return View(contact);
        }
    }
}
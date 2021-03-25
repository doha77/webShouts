using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShouts.Entities;
using WebShouts.Models;

namespace WebShouts.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContent dbContent;

        public ProfileController(ApplicationDbContent dbContent)
        {
            this.dbContent = dbContent;
        }

        public IActionResult Index()
        {
            // gets the id of current logged in user from session
            var userId = LoggedInUserId();
            // gets the shouts from db
            var list = WebShoutsList((int)userId);
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(WebShout WebShout)
        {
            // gets the id of current logged in user from session
            var userId = LoggedInUserId();

            WebShout.ApplicationUserId = (int)userId;
            dbContent.Add(WebShout);
            dbContent.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// edit shout of current logged in user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var shout = dbContent.WebShouts.FirstOrDefault(a=>a.WebShoutId == id); // get the record from database

            // if the record is not found in db give not found response i.e 404
            if (shout == null)
            {
                return RedirectToAction("Index");
            }
            return View(shout);
        }


        /// <summary>
        /// updates shouts of a user
        /// </summary>
        /// <param name="shout"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(WebShout webShout)
        {
            dbContent.Update(webShout);
            dbContent.SaveChanges();
            return RedirectToAction("Index");
        }


        /// <summary>
        /// deletes shouts of current logged in user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // get the record from db
            var shout = dbContent.WebShouts.FirstOrDefault(a=>a.ApplicationUserId == id);

            // remove the record from db
            dbContent.WebShouts.Remove(shout);
            dbContent.SaveChanges();

            // redirects to index page
            return RedirectToAction("Index");
        }

        private List<UserWebShoutsVM> WebShoutsList(int id)
        {
            var currentUserId = LoggedInUserId();
            // create IQuerable object of shouts so we can further query on shouts
            var shouts = dbContent.WebShouts.Include(a => a.ApplicationUser).ToList();

            // checks if id is not null than load shouts of specific user againts provided ID
            if (id > 0)
            {
                shouts = shouts.Where(a => a.ApplicationUserId == id).ToList();
            }

            var shoutslist = new List<UserWebShoutsVM>();

            foreach (var item in shouts)
            {
                shoutslist.Add(new UserWebShoutsVM
                {
                    UserName = item.ApplicationUser.UserName,
                    ApplicationUserId = item.ApplicationUserId,
                    Content = item.Content,
                    WebShoutId = item.WebShoutId
                });
            }

            // returns list
            return shoutslist;
        }

        private int? LoggedInUserId()
        {
            var applicationUserId = HttpContext.Session.GetString("ApplicationUserId");
            if (applicationUserId != null)
            {
                return int.Parse(applicationUserId);
            }
            return null;
        }

    }
}

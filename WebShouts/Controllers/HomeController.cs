using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebShouts.Entities;
using WebShouts.Models;
using Microsoft.EntityFrameworkCore;

namespace WebShouts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ApplicationDbContent dbContent;

        public HomeController(ILogger<HomeController> logger,
                              ApplicationDbContent dbContent)
        {
            this.logger = logger;
            this.dbContent = dbContent;
        }

        /// <summary>
        /// returns list of shouts or list of shouts of a specific user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult AllShouts()
        {
            // when user comes check if the session is null redirect user to login page
            var applicationUserId = LoggedInUserId();

            if (applicationUserId == null)
            {
                return RedirectToAction("Account", "User");
            }
            else
            {
                ViewBag.applicationUserId = applicationUserId;
                var userWebShoutsVM = WebShoutsList();

                // return view with list of shouts
                return View(userWebShoutsVM);
            }
        }

        public IActionResult Index(int id)
        {
            // when user comes check if the session is null redirect user to login page
            var applicationUserId = LoggedInUserId();

            if (applicationUserId == null)
            {
                return RedirectToAction("Account", "User");
            }
            else
            {
                ViewBag.applicationUserId = applicationUserId;
                var userWebShoutsVM = WebShoutsList(id);

                // return view with list of shouts
                return View(userWebShoutsVM);
            }
        }


        /// <summary>
        /// method to follow a person
        /// </summary>
        /// <param name="followingUserId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult FollowStranger(int followingUserId)
        {
            // get current login user id from session
            var id = LoggedInUserId();

            // creates follow entity
            var follow = new FollowUser()
            {
                FollowerApplicationUserId = (int)id,
                FollowingApplicationUserId = followingUserId
            };

            // save the entity in db
            dbContent.FollowUsers.Add(follow);
            dbContent.SaveChanges();

            // redirects to home page
            return RedirectToAction("AllShouts", "Home");
        }


        // private method to get all shouts or specific user shouts
        private List<UserWebShoutsVM> WebShoutsList(int id = 0)
        {
            var currentUserId = LoggedInUserId();
            // create IQuerable object of shouts so we can further query on shouts
            var shouts = dbContent.WebShouts.Include(a=>a.ApplicationUser).ToList();
            
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
                    WebShoutId = item.WebShoutId,
                    HasFollowed = HasFollowed(item.ApplicationUserId, currentUserId)
                });
            }

            // returns list
            return shoutslist;
        }

        private bool HasFollowed(int followerUserId, int? followingUserId)
        {
            var result = dbContent.FollowUsers.FirstOrDefault(x => x.FollowingApplicationUserId == followerUserId  && x.FollowerApplicationUserId == followingUserId);
            return result == null ? false : true;   
        }

        private int? LoggedInUserId()
        {
            var applicationUserId = HttpContext.Session.GetString("ApplicationUserId");
            if(applicationUserId !=null)
            {
                return int.Parse(applicationUserId);
            }
            return null;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShouts.Entities;
using WebShouts.Models;

namespace WebShouts.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContent dbContent;

        public UserController(ApplicationDbContent dbContent)
        {
            this.dbContent = dbContent;
        }

        /// <summary>
        /// view page of login
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Account()
        {
            return View();
        }


        /// <summary>
        /// verify user on form submit and creates session for user on login
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Account(UserLoginVM loginViewModel)
        {

            // get the record from db using email and password fields
            var result = dbContent.ApplicationUsers.FirstOrDefault(a => 
                                   a.UserEmail.Equals(loginViewModel.UserEmail) && 
                                   a.UserPassword.Equals(loginViewModel.UserPassword));

            //if no record found than return back to the login page
            if (result == null)
            {
                return View();
            }

            //if record is found create a session for logged in user and set it's id in session
            HttpContext.Session.SetString("ApplicationUserId", result.UserId.ToString());

            //after login redirect it to home page
            return RedirectToAction("Allshouts", "Home");

        }

        /// <summary>
        /// creates account when a users signup to the application
        /// </summary>
        /// <param name="logOnVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Signup(LogOnVM logOnVM)
        {
            // creates an object for user
            var applicationUser = new ApplicationUser()
            {
                UserName = logOnVM.UserName,
                UserEmail = logOnVM.UserEmail,
                UserPassword = logOnVM.UserPassword
            };

            // save the user object in db
            dbContent.ApplicationUsers.Add(applicationUser);
            dbContent.SaveChanges();

            // save user id in session when the record is saved in db
            HttpContext.Session.SetString("ApplicationUserId", applicationUser.UserId.ToString());

            //redirects to home page
            return RedirectToAction("Allshouts", "Home");
        }

        /// <summary>
        /// clears the session 
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            // remove session and redirect user to login page
            HttpContext.Session.Clear();
            return RedirectToAction("Account", "User");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EnzoBlogDeveloper.EndSystem.EntityFramework;
using EnzoBlogDeveloper.EndSystem.EntityFramework.Models;
using EnzoBlogDeveloper.Common;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using EnzoBlogDeveloper.EndSystem.AzureStorage.Repositories;

namespace EnzoBlogDeveloper.Controllers
{
    public class ApplicationUserController : Controller
    {
        private EnzoBlogDeveloperContext db = new EnzoBlogDeveloperContext();

        // GET: ApplicationUsers
        public ActionResult Index()
        {
            return View(db.ApplicationUsers.ToList());
        }

        // GET: ApplicationUsers/Details/5
        public ActionResult Details()
        {
            LoggedUser userProfile = new LoggedUser();
            IUser loggedUser = userProfile.GetLoggedUser();
            ApplicationUser applicationUser = db.ApplicationUsers.Where(user => user.Email == loggedUser.UserPrincipalName).FirstOrDefault();
            if (applicationUser == null)
            {
                applicationUser = new ApplicationUser();
                applicationUser.Id = 0;
                applicationUser.Email = loggedUser.UserPrincipalName;
                applicationUser.DisplayName = loggedUser.DisplayName;
                applicationUser.FirstName = loggedUser.GivenName;
                applicationUser.LastName = loggedUser.Surname;
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "Email,DisplayName,FirstName,LastName,Address,ProfilePicture")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.ApplicationUsers.Add(applicationUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicationUser);
        }

        // GET: ApplicationUsers/Edit/5
        public ActionResult Edit(int id)
        {
            ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
            if (applicationUser == null)
            {
                LoggedUser userProfile = new LoggedUser();
                IUser loggedUser = userProfile.GetLoggedUser();

                applicationUser = new ApplicationUser();
                applicationUser.Email = loggedUser.UserPrincipalName;
                applicationUser.DisplayName = loggedUser.DisplayName;
                applicationUser.FirstName = loggedUser.GivenName;
                applicationUser.LastName = loggedUser.Surname;
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Email,DisplayName,FirstName,LastName,Address,ProfilePicture")] ApplicationUser applicationUser, HttpPostedFileBase file, int id)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser selectedUser = db.ApplicationUsers.Find(id);

                if (file != null)
                {
                    string imageUrl = ProfilePictureRepository.UploadImageAsync(file, applicationUser.Email);
                    //TODO : Should delete the previous image too.

                    applicationUser.ProfilePicture = imageUrl;
                }

                if (selectedUser == null)
                {
                    db.ApplicationUsers.Add(applicationUser);
                    db.SaveChanges();

                    return RedirectToAction("Details");
                }
                else
                {
                    selectedUser.DisplayName = applicationUser.DisplayName;
                    selectedUser.FirstName = applicationUser.FirstName;
                    selectedUser.LastName = applicationUser.LastName;
                    selectedUser.Address = applicationUser.Address;
                    selectedUser.ProfilePicture = applicationUser.ProfilePicture;

                    db.Entry(selectedUser).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Details");
                }
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
            db.ApplicationUsers.Remove(applicationUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

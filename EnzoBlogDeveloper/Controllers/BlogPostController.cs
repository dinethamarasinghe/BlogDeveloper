using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EnzoBlogDeveloper.EndSystem.AureDocumnetStorage.Models;
using EnzoBlogDeveloper.EndSystem.EntityFramework;
using EnzoBlogDeveloper.EndSystem.AureDocumnetStorage;
using EnzoBlogDeveloper.EndSystem.AureDocumnetStorage.Repositories;
using System.Threading.Tasks;

namespace EnzoBlogDeveloper.Controllers
{
    public class BlogPostController : Controller
    {
        private EnzoBlogDeveloperContext db = new EnzoBlogDeveloperContext();

        // GET: BlogPosts
        public async Task<ActionResult> Index()
        {

            var blogPosts = await DocumentRepository<BlogPost>.GetItemsAsync();
            return View(blogPosts);
        }

        // GET: BlogPosts/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BlogPost blogPost = await DocumentRepository<BlogPost>.GetItemAsync(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }

            return View(blogPost);
        }

        // GET: BlogPosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ActionName("Create")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Heading,Content,CreatedDateTime,CreatedUser,LastUpdatedUser")] BlogPost blogPost)
        {
            blogPost.CreatedDateTime = DateTime.Now;
            blogPost.CreatedUser = User.Identity.Name;
            blogPost.LastUpdatedUser = User.Identity.Name;
            await DocumentRepository<BlogPost>.CreateItemAsync(blogPost);
            return RedirectToAction("Index", "Home");
        }

        //// GET: BlogPosts/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BlogPost blogPost = db.BlogPosts.Find(id);
        //    if (blogPost == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(blogPost);
        //}

        //// POST: BlogPosts/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //public ActionResult Edit([Bind(Include = "Id,Heading,Content,CreatedDateTime,CreatedUser,LastUpdatedUser")] BlogPost blogPost)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(blogPost).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(blogPost);
        //}

        // GET: BlogPosts/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            await DocumentRepository<BlogPost>.DeleteItemAsync(id);
            return RedirectToAction("Index");
        }

        //// POST: BlogPosts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    BlogPost blogPost = db.BlogPosts.Find(id);
        //    db.BlogPosts.Remove(blogPost);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}

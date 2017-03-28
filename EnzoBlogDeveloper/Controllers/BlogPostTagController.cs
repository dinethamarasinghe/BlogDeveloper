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
using EnzoBlogDeveloper.EndSystem.AureDocumnetStorage.Repositories;
using System.Threading.Tasks;

namespace EnzoBlogDeveloper.Controllers
{
    public class BlogPostTagController : Controller
    {
        private EnzoBlogDeveloperContext db = new EnzoBlogDeveloperContext();

        //// GET: BlogPostTag
        //public ActionResult Index()
        //{
        //    return View(db.BlogPostTags.ToList());
        //}

        //// GET: BlogPostTag/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BlogPostTag blogPostTag = db.BlogPostTags.Find(id);
        //    if (blogPostTag == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(blogPostTag);
        //}

        // GET: BlogPostTag/Create
        public ActionResult Create(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BlogPostTag blogPostTag = new BlogPostTag();
            blogPostTag.BlogId = id;
            return View(blogPostTag);
        }

        // POST: BlogPostTag/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "BlogPostTagId,BlogId,Tag,TaggedUser,TaggedDateTime")] BlogPostTag blogPostTag)
        {
            BlogPost blogPost = await DocumentRepository<BlogPost>.GetItemAsync(blogPostTag.BlogId);
            if (ModelState.IsValid)
            {
                blogPostTag.TaggedUser = User.Identity.Name;
                blogPostTag.TaggedDateTime = DateTime.Now;

                if (blogPost.Tags == null)
                {
                    blogPost.Tags = new List<BlogPostTag>();
                }
                blogPost.Tags.Add(blogPostTag);

                await DocumentRepository<BlogPost>.UpdateItemAsync(blogPost.BlogId, blogPost);
            }
            return RedirectToAction("Details", "BlogPost", new { id = blogPost.BlogId });
        }

        //// GET: BlogPostTag/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BlogPostTag blogPostTag = db.BlogPostTags.Find(id);
        //    if (blogPostTag == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(blogPostTag);
        //}

        //// POST: BlogPostTag/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "BlogPostTagId,BlogId,Tag,TaggedUser,TaggedDateTime")] BlogPostTag blogPostTag)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(blogPostTag).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(blogPostTag);
        //}

        //// GET: BlogPostTag/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BlogPostTag blogPostTag = db.BlogPostTags.Find(id);
        //    if (blogPostTag == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(blogPostTag);
        //}

        //// POST: BlogPostTag/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    BlogPostTag blogPostTag = db.BlogPostTags.Find(id);
        //    db.BlogPostTags.Remove(blogPostTag);
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

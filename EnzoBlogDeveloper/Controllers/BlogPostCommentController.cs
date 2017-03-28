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
    public class BlogPostCommentController : Controller
    {
        private EnzoBlogDeveloperContext db = new EnzoBlogDeveloperContext();

        //// GET: BlogPostComment
        //public ActionResult Index()
        //{
        //    return View(db.BlogPostComments.ToList());
        //}

        //// GET: BlogPostComment/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BlogPostComment blogPostComment = db.BlogPostComments.Find(id);
        //    if (blogPostComment == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(blogPostComment);
        //}

        // GET: BlogPostComment/Create
        public ActionResult Create(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BlogPostComment blogPostComment = new BlogPostComment();
            blogPostComment.BlogId = id;
            return View(blogPostComment);
        }

        // POST: BlogPostComment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "BlogPostCommentId,BlogId,Comment,CommentedUser,CommentedDateTime")] BlogPostComment blogPostComment)
        {
            BlogPost blogPost = await DocumentRepository<BlogPost>.GetItemAsync(blogPostComment.BlogId);
            if (ModelState.IsValid)
            {
                blogPostComment.CommentedUser = User.Identity.Name;
                blogPostComment.CommentedDateTime = DateTime.Now;

                if (blogPost.Comments == null)
                {
                    blogPost.Comments = new List<BlogPostComment>();
                }
                blogPost.Comments.Add(blogPostComment);

                await DocumentRepository<BlogPost>.UpdateItemAsync(blogPost.BlogId, blogPost);
            }
            return RedirectToAction("Details", "BlogPost", new { id = blogPost.BlogId });
        }

        //// GET: BlogPostComment/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BlogPostComment blogPostComment = db.BlogPostComments.Find(id);
        //    if (blogPostComment == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(blogPostComment);
        //}

        //// POST: BlogPostComment/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "BlogPostCommentId,BlogId,Comment,CommentedUser,CommentedDateTime")] BlogPostComment blogPostComment)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(blogPostComment).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(blogPostComment);
        //}

        //// GET: BlogPostComment/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BlogPostComment blogPostComment = db.BlogPostComments.Find(id);
        //    if (blogPostComment == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(blogPostComment);
        //}

        //// POST: BlogPostComment/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    BlogPostComment blogPostComment = db.BlogPostComments.Find(id);
        //    db.BlogPostComments.Remove(blogPostComment);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EnzoBlogDeveloper.EndSystem.AureDocumnetStorage.Models;
using EnzoBlogDeveloper.EndSystem.EntityFramework;
using EnzoBlogDeveloper.EndSystem.AureDocumnetStorage.Repositories;
using System.Threading.Tasks;

namespace EnzoBlogDeveloper.Service.Controllers
{
    public class BlogPostServiceController : ApiController
    {
        //private EnzoBlogDeveloperContext db = new EnzoBlogDeveloperContext();

        // GET: api/BlogPostService
        public async Task<IEnumerable<BlogPost>> GetBlogPosts()
        {
            return await DocumentRepository<BlogPost>.GetItemsAsync();
        }

        // GET: api/BlogPostService/5
        [ResponseType(typeof(BlogPost))]
        public async Task<BlogPost> GetBlogPost(string id)
        {
            return await DocumentRepository<BlogPost>.GetItemAsync(id);
        }

        //// PUT: api/BlogPostService/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutBlogPost(int id, BlogPost blogPost)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != blogPost.BlogPostId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(blogPost).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BlogPostExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/BlogPostService
        //[ResponseType(typeof(BlogPost))]
        //public IHttpActionResult PostBlogPost(BlogPost blogPost)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.BlogPosts.Add(blogPost);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = blogPost.BlogPostId }, blogPost);
        //}

        //// DELETE: api/BlogPostService/5
        //[ResponseType(typeof(BlogPost))]
        //public IHttpActionResult DeleteBlogPost(int id)
        //{
        //    BlogPost blogPost = db.BlogPosts.Find(id);
        //    if (blogPost == null)
        //    {
        //        return NotFound();
        //    }

        //    db.BlogPosts.Remove(blogPost);
        //    db.SaveChanges();

        //    return Ok(blogPost);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool BlogPostExists(int id)
        //{
        //    return db.BlogPosts.Count(e => e.BlogPostId == id) > 0;
        //}
    }
}
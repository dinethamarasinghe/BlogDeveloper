using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EnzoBlogDeveloper.EndSystem.AzureSearch.Repositories;
using EnzoBlogDeveloper.EndSystem.AureDocumnetStorage.Models;

namespace EnzoBlogDeveloper.Controllers
{
    public class SearchController : Controller
    {
        SearchRepository searchRepository = new SearchRepository();

        //GET : Genaral Search
        public ActionResult GenaralSearch(string searchKey = "*")
        {
            var searchResults = searchRepository.GenaralSearch(searchKey);

            var blogPosts = new List<BlogPost>();
            if (searchResults != null)
            {
                foreach (var searchResult in searchResults.Results)
                {
                    var information = searchResult.Document.ToArray();
                    BlogPost blogPost = new BlogPost();
                    blogPost.BlogPostId = int.Parse(information[0].Value.ToString());
                    blogPost.BlogId = information[8].Value.ToString();
                    blogPost.Heading = information[1].Value.ToString();
                    blogPost.Content = information[2].Value.ToString();
                    blogPost.CreatedDateTime = DateTime.Parse(information[3].Value.ToString());
                    blogPost.CreatedUser = information[4].Value.ToString();
                    blogPost.LastUpdatedUser = information[5].Value.ToString();

                    blogPosts.Add(blogPost);
                }
            }
            return View(blogPosts);
        }

        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        // GET: Search/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Search/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Search/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Search/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Search/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Search/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Search/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

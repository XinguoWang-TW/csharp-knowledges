using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using BasicASP.NETMvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BasicASP.NETMvc.Controllers
{
    //[Authorize]
    public class MoviesController : Controller
    {
        private MovieDBContext db;
        public MoviesController(MovieDBContext context)
        {
            db = context;
        }

        // GET: Movies/Index
        public ActionResult Index(string movieGenre, string searchString)
        {
            var genreLst = new List<string>();

            var genreQry = from d in db.Movies
                orderby d.Genre
                select d.Genre;

            genreLst.AddRange(genreQry.Distinct());
            ViewBag.MovieGenre = new SelectList(genreLst);

            // # homework 3 -- read movies data from loacl-db,please use linq
            var movies = db.Movies;

            // # homework 7 -- filte movies data by conditions
            var filterMovies = movies.Where(w => w.Genre == movieGenre && w.Title.Contains(searchString));

            return View(filterMovies);
        }

        [HttpPost]
        public string Index(FormCollection fc, string searchString)
        {
            return "<h3> From [HttpPost]Index: " + searchString + "</h3>";
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return View();
            }

            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return new NotFoundResult();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(new[]{"ID","Title","ReleaseDate","Genre","Price","Rating" })]
            Movie movie)
        {
            // # homework 5 -- save data to loacl-db
            db.Movies.Add(movie);
            if (db.SaveChanges() > 0)
            {
                return View(movie);
            }
            else
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            // # homework 8 -- when you on Eidt site , you should see the movie info
            if (id == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return View();
            }

            var movie = db.Movies.Find(id);

            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(new[]{"ID","Title","ReleaseDate","Genre","Price","Rating" })]
            Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            // # homework 9 -- find data by id 
            // when id is null ,return HttpStatusCode.BadRequest;
            var movie = db.Movies.FirstOrDefault(f => f.ID == id);
            if (movie != null)
            {
                db.Movies.Remove(movie);
                db.SaveChanges();
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            
            return View();
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
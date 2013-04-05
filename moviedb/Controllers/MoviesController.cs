using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using moviedb.Models;
// dartst
using System.Web.Security;

namespace moviedb.Controllers
{
    public class MoviesController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        //
        // GET: /MoviesController/

        public ActionResult IndexOrg()
        {
            return View(db.Movies.ToList());
        }

        public ActionResult Index(string szukTitle, string szukGenre, string szukWypozycz)
        {
            // Lista gatunkow
            var GenreLst = new List<string>();
            var GenreQry = from d in db.Movies
                           orderby d.Genre
                           select d.Genre;
            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.szukGenre = new SelectList(GenreLst);

            // Cala lista
            var movies = from m in db.Movies
                         select m;

            // Po tytule
            if (!String.IsNullOrEmpty(szukTitle))
            {
                movies = movies.Where(s => s.Title.Contains(szukTitle));
            }

            // Po gatunku
            if (!String.IsNullOrEmpty(szukGenre))
            {
            //    return View(movies);
            //else
            //{
                movies = movies.Where(x => x.Genre == szukGenre);
            }

            // Kto wypozyczyl
            if (!String.IsNullOrEmpty(szukWypozycz))
            {
                movies = movies.Where(s => s.WhoBorrowed.Contains(szukWypozycz));
            }
 
            return View(movies.ToList());
        }

        //
        // GET: /MoviesController/Details/5

        public ActionResult Details(int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //
        // GET: /MoviesController/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MoviesController/Create

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                // dartst
                //MembershipUser user = Membership.GetUser(User.Identity.Name);
                //Guid guid = (Guid)user.ProviderUserKey;
                //movie.OwnerId = ;
                movie.OwnerName = User.Identity.Name;
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        //
        // GET: /MoviesController/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //
        // POST: /MoviesController/Edit/5

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        //
        // GET: /MoviesController/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //
        // POST: /MoviesController/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
using System;
using System.Web.Mvc;
using MovieList.Models;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace MovieList.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string message = null)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var qw = db.Movies;
                IEnumerable<Movie> movies = db.Movies.ToList();
                ViewBag.Movies = movies;
                ViewBag.message = message;
            }

            return View();
        }

        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string movieTitle, string movieYear)  //SearchMovie smovie
        {
            String[] titleWords = movieTitle.Split(new Char[] { ' ', '.', ',', '!', '?', ':' });

            string formattedTitle = null;
            Movie movie = null;

            foreach (string i in titleWords)
            {
                formattedTitle += "+" + i;
            }

            string url = "http://www.omdbapi.com/?t=" + formattedTitle + "&y=";

            if (movieYear != null) url += movieYear;

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);

                dynamic movieFullInfo = JsonConvert.DeserializeObject(json);
                //var currentUserId = User.Identity.GetUserId();
                //ApplicationUser AppUser = new ApplicationUser();
                //AppUser.Id = User.Identity.GetUserId();

                movie = new Movie
                {
                    Title = movieFullInfo.Title,
                    Description = movieFullInfo.Plot,
                    Poster = movieFullInfo.Poster,
                    IMDBRating = movieFullInfo.imdbRating,
                    EventDate = movieFullInfo.Released,
                    IMDBLink = "http://www.imdb.com/title/" + movieFullInfo.imdbID + "/"
                    //, User_Id = AppUser
            };

                ViewBag.movie = movie;
            }


                return View();
        }
        public string SearchInIMDB()
        {
            return "";
        }



        [HttpPost]
        public ActionResult Add(Movie movie, int Mark)
        {
            ApplicationUser AppUser = new ApplicationUser();
            AppUser.Id = User.Identity.GetUserId();
          //  AppUser.UserName = "asfasf";
                //User.Identity.GetUserName();

            using (ApplicationContext db = new ApplicationContext())
            {
               // try
               // {

                    movie.Mark = Mark.ToString();
                    movie.UserId = User.Identity.GetUserId();
                    //     movie.User = AppUser;
                    db.Movies.Add(movie);


                    db.SaveChanges();
             //   }
                //catch (DbEntityValidationException dbEx)
                //{
                //    foreach (var validationErrors in dbEx.EntityValidationErrors)
                //    {
                //        foreach (var validationError in validationErrors.ValidationErrors)
                //        {
                //            Trace.TraceInformation("Property: {0} Error: {1}",
                //                                    validationError.PropertyName,
                //                                    validationError.ErrorMessage);
                //        }
                //    }
                //}
            }

            return RedirectToAction("Index", new { message = "Movie saved" });
        }
    }
}
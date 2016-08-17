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
                List<string> authors = new List<string>();

                foreach(var i in movies)
                {
                    var authorUserName = (from users in db.Users
                                         where users.Id.Equals(i.UserId)
                                         select users.UserName).FirstOrDefault();
                   
                   authors.Add(authorUserName);
                }
                ViewBag.Movies = movies;
                ViewBag.Authors = authors;
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

                movie = new Movie
                {
                    Title = movieFullInfo.Title,
                    Description = movieFullInfo.Plot,
                    Poster = movieFullInfo.Poster,
                    IMDBRating = movieFullInfo.imdbRating,
                    EventDate = movieFullInfo.Released,
                    IMDBLink = "http://www.imdb.com/title/" + movieFullInfo.imdbID + "/"
            };

                ViewBag.movie = movie;
            }


                return View();
        }

        [HttpPost]
        public ActionResult Add(Movie movie, int Mark)
        {
            using (ApplicationContext db = new ApplicationContext())
            {

                    movie.Mark = Mark.ToString();
                    movie.UserId = User.Identity.GetUserId();
                    db.Movies.Add(movie);
                    db.SaveChanges();
            }

            return RedirectToAction("Index", new { message = "Movie saved" });
        }
    }
}
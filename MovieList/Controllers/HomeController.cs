using System;
using System.Web.Mvc;
using MovieList.Models;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;

namespace MovieList.Controllers
{
    public class HomeController : BaseController
    {
        //public string s(string s, string p)  // testing omdb api
        //{
        //    string url = "http://www.omdbapi.com/?s=" + s + "&page=" + p + "&type=movie";

        //    using (WebClient wc = new WebClient())
        //    {
        //        var json = wc.DownloadString(url);
        //        dynamic movieFullInfo = JsonConvert.DeserializeObject(json).ToString();

        //        //movie = new Movie
        //        //{
        //        //    Title = movieFullInfo.Title,
        //        //    Description = movieFullInfo.Plot,
        //        //    Poster = movieFullInfo.Poster,
        //        //    IMDBRating = movieFullInfo.imdbRating,
        //        //    EventDate = movieFullInfo.Released,
        //        //    IMDBLink = "http://www.imdb.com/title/" + movieFullInfo.imdbID + "/"
        //        //};

        //     //   ViewBag.movie = movie;

        //    return movieFullInfo;
        //    }
        //}

        // GET: Home
        public ActionResult Index(string id)
        {
            if (id == null)
            {
                 List<Movie> movies = dal.GetMovies();
                 List<string> authors = new List<string>();
 
                 foreach (var i in movies)
                 {
                     authors.Add(dal.GetUserName(i.UserId));
                 }
                 ViewBag.Movies = movies;
                 ViewBag.Authors = authors;
            }
            else
            {
                if (id == User.Identity.GetUserId())
                { 
                    ApplicationUser user = dal.GetUserInfo(id);
                    List<Movie> movies = dal.GetMovies(id);
                    ViewBag.User = user;
                    ViewBag.Movies = movies;
                }
                else
                {
                    //TODO: Create data for showing foreign profile
                   // ApplicationUser user = dal.GetUserInfo(id);
                 //   ViewBag.User = user;
                }
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
                    EventDate = movieFullInfo.Year,
                    IMDBLink = "http://www.imdb.com/title/" + movieFullInfo.imdbID + "/"
                };

                ViewBag.movie = movie;
            }


                return View();
        }

        [HttpPost]
        public ActionResult Add(Movie movie, int Mark)
        {
            movie.Mark = Mark.ToString();
            movie.UserId = User.Identity.GetUserId();
            dal.AddMovie(movie);

            return RedirectToAction("Index");
        }
    }
}
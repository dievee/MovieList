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
using Microsoft.AspNet.Identity.EntityFramework;

namespace MovieList.Controllers
{
    public class HomeController : Controller
    {
        public string s(string s, string p)  // testing omdb api
        {

            string url = "http://www.omdbapi.com/?s=" + s + "&page=" + p + "&type=movie";
            Movie movie = null;
            dynamic movieFullInfo = null;
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);

                movieFullInfo = JsonConvert.DeserializeObject(json).ToString();

                //movie = new Movie
                //{
                //    Title = movieFullInfo.Title,
                //    Description = movieFullInfo.Plot,
                //    Poster = movieFullInfo.Poster,
                //    IMDBRating = movieFullInfo.imdbRating,
                //    EventDate = movieFullInfo.Released,
                //    IMDBLink = "http://www.imdb.com/title/" + movieFullInfo.imdbID + "/"
                //};

             //   ViewBag.movie = movie;
            }

            return movieFullInfo;
        }

        // GET: Home
        public ActionResult Index(string id)
        {
            if (id == null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    IEnumerable<Movie> movies = db.Movies.ToList();
                    //List<Note> notes = new List<Note>();
                    //foreach (var i in movies)
                    //{
                    //    Note note = new Note();
                    //    note.Comment = i.Comment;
                    //    note.Description = i.Description;
                    //    note.EventDate = i.EventDate;
                    //    note.IMDBLink = i.IMDBLink;
                    //    note.IMDBRating = i.IMDBRating;
                    //    note.Mark = i.Mark;
                    //    note.MovieId = i.MovieId;
                    //    note.Poster = i.Poster;
                    //    note.Title = i.Title;

                    //    notes.Add(note);
                    //}

                    List<string> authors = new List<string>();

                    foreach (var i in movies)
                    {
                        var authorUserName = (from users in db.Users
                                              where users.Id.Equals(i.UserId)
                                              select users.UserName).FirstOrDefault();

                        authors.Add(authorUserName);
                    }
                    ViewBag.Movies = movies;
                    ViewBag.Authors = authors;
                }
            }
            else
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    IEnumerable<ApplicationUser> userInfo = (from u in db.AppUsers
                                                             where u.Id.Equals(User.Identity.GetUserId())
                                                             select u);
                    ViewBag.UserInfo = userInfo; 
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

            return RedirectToAction("Index");
        }
    }
}
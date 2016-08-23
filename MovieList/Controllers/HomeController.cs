using System.Web.Mvc;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using MovieList.Models;
using System;

namespace MovieList.Controllers
{
    public class HomeController : BaseController
    {

        // GET: Home
        public ActionResult Index(string id)
        {
            if (id == null)
            {
                 List<Movie> movies = dal.GetMoviesFull();
                 ViewBag.Movies = movies;
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
        public ActionResult Search(string IMDBLink)
        {
            if (IMDBLink != null)
            {
                string id = prs.GetMovieIdFromLink(IMDBLink);
                Movie movie = imdb.GetMovieById(id);
                ViewBag.movie = movie;
             }

            return View();
        }
        [HttpPost]
        public ActionResult Search(string movieTitle, string movieYear, string type)  //SearchMovie smovie
        {
            Movie movie = imdb.GetMovie(movieTitle, movieYear);
            movie.Type = type;
            ViewBag.Movie = movie;

            return View();
        }

        [HttpGet]
        public ActionResult AdvancedSearch()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult AdvancedSearch(string movieTitle, string movieYear, string type)  // search by s attribute
        {
            List<Movie> movies = imdb.GetMoviesByAdvancedSearch(movieTitle, movieYear, type); // TODO: Add Error message to list if errror
            ViewBag.Movies = movies;
            
            return View();
        }

        [HttpPost]
        public ActionResult Add(Movie movie, int? Mark)
        {
            if (Mark != null)
                movie.Mark = Mark.ToString();

            movie.UserId = User.Identity.GetUserId();
            movie.NotedDate = DateTime.Now.Date;

            dal.AddMovie(movie);

            return RedirectToAction("Index");
        }
    }
}
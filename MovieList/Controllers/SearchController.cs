using MovieList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieList.Controllers
{
    public class SearchController : BaseController
    {
        // GET: Search
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Result(string title)
        {
            List<Movie> movies = new List<Movie>();
            if (movies.Count == 0)
                ViewBag.Message = "There is not movies containt this characters.";
            else
                ViewBag.Movies = dal.GetMoviesByTitle(title);

            return View();
        }
    }
}

//TODO: Add search field in header to 
//searching movies/notes.
//Add filtrating in searched query.
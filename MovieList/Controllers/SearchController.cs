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
             movies = dal.GetMoviesByTitle(title);

            return View();
        }

        //[HttpPost]
        //public ActionResult Result(Movie movie)
        //{
        //    return View();
        //}
    }
}
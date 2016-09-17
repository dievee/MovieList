using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieList.Controllers
{
    public class MovieController : BaseController
    {
        // GET: Movie
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
           ViewBag.Movies = dal.GetMostPopularMovies();

            return View();
        }

        public void FastAdditionOfAMovie(int movieId)
        {
            dal.AddMovieByFastAddition(movieId);
        }
    }
}
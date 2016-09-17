using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieList.Models;
using Microsoft.AspNet.Identity;

namespace MovieList.Controllers
{
    public class MovieController : BaseController
    {
        // GET: Movie
        public ActionResult Index()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Note note = new Note();

                note.Comment = "sfa";
                note.UserId = User.Identity.GetUserId();
                note.Mark = "5";
                db.Notes.Add(note);
                db.SaveChanges();
            }
                
            return View();
        }
        //[HttpGet]
        //public ActionResult Add()
        //{
        //   ViewBag.Movies = dal.GetMostPopularMovies();

        //    return View();
        //}

        //public void FastAdditionOfAMovie(int movieId)
        //{
        //    dal.AddMovieByFastAddition(movieId);
        //}
    }
}
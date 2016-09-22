using System.Web.Mvc;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using MovieList.Models;
using System;

namespace MovieList.Controllers  // TODO: add filtration to search method
{
    public class HomeController : BaseController
    {
        public ActionResult Index(string id)
        {
            List<Note> notes;

            if (id == User.Identity.GetUserId())
            {
                notes = dal.GetNotesByUserId(id);
                ViewBag.Movies = dal.GetMoviesByUserId(id) as List<Movie>;
                ViewBag.User = dal.GetUserInfo(id) as ApplicationUser;
            }
            else
                notes = dal.GetNotes();
            
            ViewBag.Notes = notes;
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
        public ActionResult Search(string movieTitle, string movieYear, string type)
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
        //[HttpGet]
        //public ActionResult Add(string noteId) //showing note for editing to movie
        //{
        //    Movie movie = dal.GetMovie(noteId);
        //    ViewBag.Movie = movie;

        //    return View();
        //}
        [HttpPost]
        public ActionResult AddNote(Note note, int? Mark, bool IsLooked)
        {
            if (Mark != null)
                note.Mark = Mark.ToString();
            note.IsLooked = IsLooked;
            note.UserId = User.Identity.GetUserId();
            dal.AddNote(note);

            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult Update(Movie movie, int? Mark)
        //{
        //    if (Mark != null)
        //        movie.Mark = Mark.ToString();

        //    movie.NotedDate = DateTime.Now;
        //    movie.UserId = User.Identity.GetUserId();
        //    dal.UpdateMovieFromNote(movie);

        //    return RedirectToAction("Index");
        //}

        //public ActionResult Delete(string noteId)
        //{
        //    if (noteId != null)
        //    {
        //        Movie movie = dal.GetMovie(noteId);
        //        dal.DeleteMovie(movie);
        //    }

        //    return RedirectToAction("Index");
        //}

    }
}
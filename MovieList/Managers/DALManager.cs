using Microsoft.AspNet.Identity;
using MovieList.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MovieList.Managers
{
    public class DALManager
    {
        private ApplicationContext db = new ApplicationContext();

        public List<Note> GetNotes()
        {
            var query = from notes in db.Notes
                        select notes;

            return query.ToList();
        }

        public List<Note> GetNotesByUserId(string id)
        {
            var query = from notes in db.Notes
                        where notes.UserId == id
                        select notes;

            return query.ToList();
        }
        public List<Movie> GetMoviesByUserId(string id)
        {
            var query = from notes in db.Notes
                        where notes.UserId == id
                        select notes.Movie;

            return query.ToList();
        }
        public void AddNote(Note note)
        {
            db.Notes.Add(note);
            db.SaveChanges();
        }

        //public void UpdateMovieFromNote(Movie movie)
        //{
        //    db.Entry(movie).State = EntityState.Modified;
        //    SaveChanges();
        //}

        //public void AddMovie(Movie movie)
        //{
        //    db.Movies.Add(movie);
        //    db.SaveChanges();
        //}

        //public void AddMovieByFastAddition(int movieId)
        //{
        //    Movie movie = (from moviedb in db.Movies
        //                  where moviedb.MovieId == movieId
        //                  select moviedb).Single() as Movie;
        //}

        //public void DeleteMovie(Movie movie)
        //{
        //    db.Movies.Remove(movie);
        //    db.SaveChanges();
        //}

        //public void SaveChanges()
        //{
        //    db.SaveChanges();
        //}

        //public List<Movie> GetMovies(string id = null)
        //{
        //    if (id == null)
        //    {
        //        var query = from movies in db.Movies
        //                    where movies.Mark != null
        //                    select movies;
        //        return query.ToList();
        //    }
        //    else
        //    {
        //        var query = (from movies in db.Movies
        //                    where movies.UserId == id && movies.Mark != null
        //                     select movies);
        //        return query.ToList();
        //    }
        //}

        //public List<Movie> GetMoviesFull(string id = null)
        //{
        //    Movie movie;
        //    List<Movie> movies = new List<Movie>();
        //    if (id == null)
        //    {
        //        var query = (from moviesdb in db.Movies
        //                     where moviesdb.Mark != null
        //                     join users in db.Users on moviesdb.UserId equals users.Id
        //                    select new { moviesdb, users.UserName });
        //        foreach(var i in query)
        //        {
        //            movie =  i.moviesdb ;
        //            movie.UserName = i.UserName;

        //            movies.Add(movie);
        //        }

        //        return movies;
        //    }
        //    else
        //    {
        //        var query = (from moviesdb in db.Movies
        //                     where moviesdb.UserId == id && moviesdb.Mark != null
        //                     join users in db.Users on moviesdb.UserId equals users.Id
        //                     select new { moviesdb, users.UserName });

        //        foreach (var i in query)
        //        {
        //            movie = i.moviesdb;
        //            movie.UserName = i.UserName;

        //            movies.Add(movie);
        //        }

        //        return movies;
        //    }
        //}

        //public List<Movie> GetNotes(string id)
        //{
        //    List<Movie> movies = new List<Movie>();

        //    var query = (from moviesdb in db.Movies
        //                 where moviesdb.Mark == null && moviesdb.UserId == id
        //                 select moviesdb);

        //    return query.ToList();
        //}

        //public string GetUserName(string id)
        //{
        //    var query = (from users in db.Users
        //                          where users.Id.Equals(id)
        //                          select users.UserName).FirstOrDefault();

        //    return query;
        //}

        //public ApplicationUser GetUserInfo(string id)
        //{
        //    var query = (from u in db.Users
        //                 where u.Id.Equals(id)
        //                 select u);

        //    return query.Single() as ApplicationUser;
        //}

        //public int GetCountOfMovies(string id)
        //{
        //    var query = (from movies in db.Movies
        //                 where movies.UserId.Equals(id) && movies.Mark != null
        //                 select movies).Count();

        //    return query;
        //}
        //public Movie GetMovie(string id)
        //{
        //    int movieid = Int32.Parse(id);
        //    var query = (from moviesdb in db.Movies
        //                 where moviesdb.MovieId == movieid
        //                 select moviesdb);

        //    return query.Single() as Movie;
        //}

        //public List<Movie> GetMoviesByTitle(string title) // TODO: Add filtration search result( do not show not own user's notes)
        //{
        //    var query = from moviesdb in db.Movies
        //                where moviesdb.Title.Contains(title)  // && moviesdb.Mark != null
        //                select moviesdb;

        //    return query.ToList();
        //}

        //public List<Movie> GetMostPopularMovies(int count = 7, int startIndex = 0 ) // default: get (7) movies, first movie have index in db (0)
        //{
        //    var query = (from moviesdb in db.Movies
        //                orderby moviesdb.MovieId
        //                select moviesdb).Skip(startIndex).Take(count);

        //    return query.ToList();
        //}


    }
}
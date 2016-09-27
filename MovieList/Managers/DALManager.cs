using Microsoft.AspNet.Identity;
using MovieList.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace MovieList.Managers
{
    public class DALManager
    {
        private ApplicationContext db = new ApplicationContext();
        public void SaveChanges()
        {
            db.SaveChanges();
        }


        //Add..


        public void AddBindUserMovie(int movieId, string userId, bool isLooked)
        {
            UserMovie usermovie = new UserMovie()
            {
                UserId = userId,
                MovieId = movieId,
                IsLooked = isLooked
            };
            db.UserMovies.Add(usermovie);
            db.SaveChanges();
        }


        //Add Note..


        public void AddNote(Note note, string userId, bool isLooked)
        {
            AddMovieIfNotExists(note);
            int movieId = GetMovieId(note.IMDBLink);
            note.MovieId = movieId;
            db.Notes.Add(note);
            db.SaveChanges();

            AddBindUserMovie(movieId, userId, isLooked);
        }


        //Add Movie..


        public void AddMovieByFastAddition(int movieId)
        {
            Movie movie = (from moviedb in db.Movies
                           where moviedb.MovieId == movieId
                           select moviedb).Single() as Movie;
            throw new Exception();
        }
        public void AddMovieIfNotExists(Note note)
        {
            try
            {
                Movie movie = (from movies in db.Movies
                               where movies.IMDBLink == note.IMDBLink
                               select movies).Single();
            }
            catch (InvalidOperationException)
            {
                AddMovieFromNote(note);
            }
        }
        public void AddMovieFromNote(Note note)
        {
            Movie movie = new Movie()
            {
                Poster = note.Poster,
                Title = note.Title,
                Description = note.Description,
                IMDBLink = note.IMDBLink,
                EventDate = note.EventDate,
                IMDBRating = note.IMDBRating
            };
            db.Movies.Add(movie);
            db.SaveChanges();
        }


        //Get Movie..


        public int GetMovieId(string IMDBLink)
        {
            var query = (from movies in db.Movies
                         where movies.IMDBLink == IMDBLink
                         select movies.MovieId).Single();

            return query;
        }
        public List<Movie> GetMoviesByUserId(string id)
        {
            var query = from notes in db.Notes
                        where notes.UserId == id
                        select notes.Movie;

            return query.ToList();
        }
        public List<Note> GetNotesByUserId(string id)
        {
            var query = from notes in db.Notes
                        where notes.UserId == id
                        select notes;

            return query.ToList();
        }
        public List<Movie> GetMoviesByTitle(string title)
        {
            var query = from moviesdb in db.Movies
                        where moviesdb.Title.Contains(title)
                        select moviesdb;

            return query.ToList();
        }
        public List<Movie> GetMostPopularMovies(int count = 7, int startIndex = 0) // default: get (7) movies, first movie have index in db (0)
        {
            var query = (from moviesdb in db.Movies
                         orderby moviesdb.MovieId
                         select moviesdb).Skip(startIndex).Take(count);

            return query.ToList();
        }
        public List<Note> GetNotLookedMovies(string id)
        {
            Note note;
            //List<Note> notes = new List<Note>();
            var query = from notes in db.Notes
                        where notes.UserId.Equals(id) && notes.IsLooked == false
                        join usermovies in db.UserMovies on notes.UserId equals usermovies.UserId
                        where usermovies.IsLooked == false
                        select new
                        {
                            notes,
                            usermovies
                        };

            foreach (var i in query)
            {

                //Movie movie = (from movies in db.Movies
                //          where movies.MovieId.Equals(i.notesdb.MovieId)
                //          select movies).Single();
                //note.MovieId = movie.MovieId;
                //note.Poster = movie.Poster;
                Type curType = typeof(Movie);
                FieldInfo[] properties = curType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                //foreach (var j in movie)
                //{
                //    note.j = 
                //}
                //note = i.usermovies;
            }
            throw new Exception();
            return null;
        }


        //Get Note..


        public List<Note> GetNotes()
        {
            Note note;
            List<Note> notes = new List<Note>();
            var query = from notesdb in db.Notes
                        join movies in db.Movies on notesdb.MovieId equals movies.MovieId
                        select new { notesdb, movies };

            foreach (var i in query)
            {
                note = i.notesdb;
                note.Movie = i.movies;
                notes.Add(note);          
            }

            return notes;
        }
        public Note GetNote(int noteId)
        {
            var query = (from notes in db.Notes
                         where notes.NoteId == noteId
                         select notes).Single();

            return query as Note;
        }


        //Get User..


        public string GetUserNickName(string userId)
        {
            var query = (from users in db.Users
                         where users.Id == userId
                         select users.NickName).Single();
            return query;
        }
        public ApplicationUser GetUserInfo(string id)
        {
            var query = (from u in db.Users
                         where u.Id.Equals(id)
                         select u);

            return query.Single() as ApplicationUser;
        }


        //Delete Note..


        public void DeleteNote(Note note)
        {
            db.Notes.Remove(note);
            db.SaveChanges();
        }






        

        





        


    }
}
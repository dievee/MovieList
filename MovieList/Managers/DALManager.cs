using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MovieList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieList.Managers
{
    public class DALManager
    {
        private ApplicationContext db = new ApplicationContext();

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        //public Movie GetMovieByIMDBId(string id)
        //{

        //    return null;
        //}

        public List<Movie> GetMovies(string id = null)
        {
            if (id == null)
            {
                var query = from movies in db.Movies
                            select movies;
                return query.ToList();
            }
            else
            {
                var query = (from movies in db.Movies
                            where movies.UserId == id
                            select movies);
                return query.ToList();
            }
        }

        public List<Movie> GetMoviesFull(string id = null)  // TODO: finish join query
        {
            if (id == null)
            {
                var query = (from movies in db.Movies
                             join users in db.Users on movies.UserId equals users.Id
                            select new { movies, users.UserName });
                foreach(var i in query)
                {
                    i.GetType();
                }
                query.ToList();
                foreach (var i in query)
                {
                    i.GetType();
                }
                return null;
                // return query.ToList();
            }
            else
            {
                var query = (from movies in db.Movies
                             where movies.UserId == id
                             join users in db.Users on movies.UserId equals users.Id
                             select new { movies, users.UserName });
                return null;
                //return query.ToList();
            }
        }

        public string GetUserName(string id)
        {
            var query = (from users in db.Users
                                  where users.Id.Equals(id)
                                  select users.UserName).FirstOrDefault();

            return query;
        }

        public ApplicationUser GetUserInfo(string id)
        {
            var query = (from u in db.Users
                         where u.Id.Equals(id)
                         select u);

            return query.FirstOrDefault() as ApplicationUser;
        }

        public int GetCountOfMovies(string id)
        {
            var query = (from movies in db.Movies
                         where movies.UserId.Equals(id)
                         select movies).Count();

            return query;
        }

        public void AddMovie(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
        }
    }
}
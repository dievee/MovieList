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

        public void AddMovie(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
        }
    }
}
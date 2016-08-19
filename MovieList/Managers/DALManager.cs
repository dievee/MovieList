using Microsoft.AspNet.Identity;
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

        public List<Movie> GetMovies()
        {
            var query = from movies in db.Movies
                        select movies;

            return query.ToList();
        }

        public string GetAuthorOfMovie(string id)
        {
            var query = (from users in db.Users
                                  where users.Id.Equals(id)
                                  select users.UserName).FirstOrDefault();

            return query;
        }

        //public ApplicationUser GetUserInfo(string id)
        //{
        //    var query = (from u in db.AppUsers
        //                 where u.Id.Equals(id)
        //                 select u);

        //    return query.FirstOrDefault() as ApplicationUser;
        //}

        public void AddMovie(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using MovieList.Models;
using System.Net;
using Newtonsoft.Json;
using MovieList.Models.JsonModels;

namespace MovieList.Managers
{
    public class IMDBManager
    {
        private WebClient wc = new WebClient();

        public Movie GetMovieById(string id, string plot = "short", string result = "json")
        {
            Movie movie;
            string url = String.Format("http://www.omdbapi.com/?i={0}&plot={1}&r={2}", id, plot, result);
            try
            {             
                var json = wc.DownloadString(url);
                dynamic movieFullInfo = JsonConvert.DeserializeObject(json);
                bool status = movieFullInfo.Response;

                if (!status)
                {
                    movie = new Movie
                    {
                        Error = movieFullInfo.Error
                    };
                }
                else
                {
                    movie = new Movie
                    {
                        Title = movieFullInfo.Title,
                        Description = movieFullInfo.Plot,
                        Poster = movieFullInfo.Poster,
                        IMDBRating = movieFullInfo.imdbRating,
                        EventDate = movieFullInfo.Year,
                        IMDBLink = "http://www.imdb.com/title/" + movieFullInfo.imdbID + "/"
                    };
                }
            }
            catch(Exception)
            {
                return null;
            }

            return movie;
            
        }

        public Movie GetMovie(string movieTitle, string movieYear)
        {
            Movie movie;
            String[] titleWords = movieTitle.Split(new Char[] { ' ', '.', ',', '!', '?', ':' });
            string formattedTitle = null;

            foreach (string i in titleWords)
                formattedTitle += "+" + i;

            string url = "http://www.omdbapi.com/?t=" + formattedTitle + "&y=";
            if (movieYear != null) url += movieYear;

            try
            {
                var json = wc.DownloadString(url);
                dynamic movieFullInfo = JsonConvert.DeserializeObject(json);
                bool status = movieFullInfo.Response;

                if (!status)
                {
                    movie = new Movie
                    {
                        Error = movieFullInfo.Error
                    };
                }
                else
                {
                    movie = new Movie
                    {
                        Title = movieFullInfo.Title,
                        Description = movieFullInfo.Plot,
                        Poster = movieFullInfo.Poster,
                        IMDBRating = movieFullInfo.imdbRating,
                        EventDate = movieFullInfo.Year,
                        IMDBLink = "http://www.imdb.com/title/" + movieFullInfo.imdbID + "/"
                    };
                }
            }
            catch(Exception)
            {
                return null;
            }

            return movie;
        }

        public List<Movie> GetMoviesByAdvancedSearch(string movieTitle, string movieYear, string type)
        {
            int i = 0;
            Movie movie;
            List<Movie> movies = new List<Movie>();
            string url = String.Format("http://www.omdbapi.com/?s={0}&page={1}&y={2}&type={3}", movieTitle, "1", movieYear, type);

            try
            {
                var json = wc.DownloadString(url);
                Movies movieFullInfo = JsonConvert.DeserializeObject<Movies>(json);

                foreach (var m in movieFullInfo.Search)
                {
                    if (m.Poster != "N/A")
                    {
                        if (i >= 7) return movies;

                        movie = new Movie
                        {
                            Title = m.Title,
                            Poster = m.Poster,
                            EventDate = m.Year,
                            IMDBLink = "http://www.imdb.com/title/" + m.imdbID + "/"
                        };
                        movies.Add(movie);
                        i++;
                    }
                }
            }
            catch(Exception)
            {
                return null;
            }
            

            return movies;
        }
    }
}
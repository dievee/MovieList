using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieList.Managers
{
    public class ParseManager
    {
        public string GetMovieIdFromLink(string IMDBLink)
        {
            //http://www.imdb.com/title/tt1345836/
            String[] linkWords = IMDBLink.Split(new Char[] { '/' });
            string id = linkWords[ 4 ];

            return id;
        }
    }
}
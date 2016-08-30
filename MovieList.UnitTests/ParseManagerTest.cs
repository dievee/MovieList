using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieList.Managers;

namespace MovieList.UnitTests
{
    [TestClass]
    public class ParseManagerTest
    {
        [TestMethod]
        public void GetMovieIdFromLink_IMDBLink_IMDBIdReturned()
        {
            var pm = new ParseManager();

            var res = pm.GetMovieIdFromLink("http://www.imdb.com/title/tt0345836/");


            StringAssert.StartsWith(res, "tt");
            try
            {
                int id = Int32.Parse( res.Remove(0, 2) );
            }
            catch(Exception ex)
            {
                Assert.Fail("Got Exception. Can't convert part of id to int. M:" + ex.Message);
            }
        }
    }
}

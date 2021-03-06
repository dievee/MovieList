﻿using System.Web.Mvc;
using MovieList.Managers;
namespace MovieList.Controllers
{
    public class BaseController : Controller
    {
        protected DALManager dal = new DALManager();

        protected ParseManager prs = new ParseManager();

        protected IMDBManager imdb = new IMDBManager();
    }
}
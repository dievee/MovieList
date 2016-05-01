using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ML.Domain.Abstract;
using ML.Domain.Entities;

namespace ML.WebUI.Controllers
{
    public class MovieController : Controller
    {
        private IProductRepository repository;
        public MovieController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        // GET: Movie
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult List()
        {
            return View(repository.Movies);
        }

    }
}
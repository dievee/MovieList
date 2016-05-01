﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Ninject;
using ML.Domain.Abstract;
using ML.Domain.Entities;

namespace ML.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Movies).Returns(new List<Movie> {
             new Movie { Title = "Inception", Description = "desc inception" },
             new Movie { Title = "Insomnia", Description = "desc insomnia"  },
             new Movie { Title = "Interstellar", Description = "desc interstellar"  }
             });
            kernel.Bind<IProductRepository>().ToConstant(mock.Object);
        }
    }
}
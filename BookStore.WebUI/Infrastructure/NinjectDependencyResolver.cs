using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Moq;
using Ninject;
using BookStore.Domain.Abstract;
using BookStore.Domain.Entities;

namespace BookStore.WebUI.Infrastructure
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
            // Здесь размещаются привязки
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns(new List<Book>
            {
                new Book { Name = "Odoblar xazinasi", Price = 160000 },
                new Book { Name = "Til ofatlari", Price=22900 },
                new Book { Name = "Baxtiyor oila", Price=65000 },
                new Book { Name = "Baxtli oila qurishning 5 qoidasi", Price = 1499 },

                new Book { Name = "C# dasturlashlashni o'rganamiz", Price=130000 },
                new Book { Name = "Dasturlash asoslari", Price=87000 },
                new Book { Name = "JavaScript va uning fremvorklari", Price = 140000 },
                new Book { Name = "Html va CSS asoslari", Price=45000 },

                new Book { Name = "Moliy asoslari", Price=210000 },
                new Book { Name = "Buxgalteriya xisobini yuritish", Price = 70000 },
                new Book { Name = "Audit", Price=110000 },
                new Book { Name = "Korxona xisobni yuritish", Price=95000 },
                new Book { Name = "Iqtisod", Price = 132000 },

                new Book { Name = "Boy ota v kambaxal ota", Price=75000 },
                new Book { Name = "Million dollorlik xatolar", Price=190000 },
                new Book { Name = "Muomala sirlari", Price=35000}
            });
            kernel.Bind<IBookRepository>().ToConstant(mock.Object);
        }
    }
}
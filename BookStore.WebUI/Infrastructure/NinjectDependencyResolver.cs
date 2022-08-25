using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Moq;
using Ninject;
using BookStore.Domain.Abstract;
using BookStore.Domain.Entities;
using BookStore.Domain.Concrete;

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
            kernel.Bind<IBookRepository>().To<EFBookRepository>();
        }

        /*private void AddBindings()
        {
            // Здесь размещаются привязки
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns(new List<Book>
            {
                new Book { Name = "Одоблар Хазинази", Price = 160000 },
                new Book { Name = "Тил Офатлари", Price=22900 },
                new Book { Name = "Бахтиёр Оила", Price=65000 },
                new Book { Name = "Бахтли оила киришнинг 5 коидаси", Price = 15000 },

                new Book { Name = "C# Дастурлаш тили", Price=130000 },
                new Book { Name = "Дастурлаш асослари", Price=87000 },
                new Book { Name = "JavaScript ва унинг Фреймворклари", Price = 140000 },
                new Book { Name = "Html ва CSS асослари", Price=45000 },

                new Book { Name = "Молия асослари", Price=210000 },
                new Book { Name = "Бухгалтерия хисобини юритиш", Price = 70000 },
                new Book { Name = "Аудит", Price=110000 },
                new Book { Name = "Корхона хисобни юритиш", Price=95000 },
                new Book { Name = "Иктисод ва Молия", Price = 132000 },

                new Book { Name = "Бой Ота ва Камбахал Ота", Price=75000 },
                new Book { Name = "Миллион долларлик хатолар", Price=190000 },
                new Book { Name = "Муомала сирлари", Price=35000},
                new Book { Name = "Мен ва пул", Price=45000}
            });
            kernel.Bind<IBookRepository>().ToConstant(mock.Object);
        }
        */
    }
}
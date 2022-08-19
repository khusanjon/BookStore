using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Domain.Abstract;
using BookStore.Domain.Entities;

namespace BookStore.WebUI.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository repository;
        public BookController(IBookRepository repo)
        {
            repository = repo;
        }

        public ViewResult List()
        {
            return View(repository.Books);
        }
    }
}
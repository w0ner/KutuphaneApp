using BL.Repositories;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneApp.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Book> repoBook;
        public HomeController(IRepository<Book> _repoBook)
        {
            repoBook = _repoBook;
        }

        public IActionResult Index()
        {
            return View(repoBook.GetAll().OrderBy(x => x.Name));
        }
    }
}

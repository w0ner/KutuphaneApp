using BL.Repositories;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneApp.Areas.admin.Controllers
{
    [Authorize, Area("admin"), Route("/admin/[controller]/[action]/{id?}")]
    public class BookController : Controller
    {

        IRepository<Book> repoBook;
        IRepository<Members> repoMembers;
        public BookController(IRepository<Book> _repoBook, IRepository<Members> _repoMembers)
        {
            repoBook = _repoBook;
            repoMembers = _repoMembers;
        }

        public IActionResult Index()
        {
            return View(repoBook.GetAll().Include(x=>x.Members).OrderBy(x => x.Name));
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New(Book model)
        {
            if (Request.Form.Files.Any())
            {
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "img", "book"))) Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "img", "book"));
                string dosyaAdi = (repoBook.GetAll().Count() + 1) + Request.Form.Files["Picture"].FileName;
                using (FileStream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "img", "book", dosyaAdi), FileMode.Create))
                {
                    await Request.Form.Files["Picture"].CopyToAsync(stream);
                }
                model.Picture = "/assets/img/book/" + dosyaAdi;
                TempData["Ekleme"] = "Başarılı Şekilde Eklendi";
            }
            model.Status = false;
            repoBook.Add(model);
            return RedirectToAction("Index");
        }

        public IActionResult Give(int id)
        {
            ViewBag.Members = repoMembers.GetAll().OrderBy(x => x.Name).Select(x => new SelectListItem { Text = x.Name, Value = x.ID.ToString() });
            return View(repoBook.GetBy(x => x.ID == id));
        }

        [HttpPost]
        public IActionResult Give(Book model)
        {
         
            model.Status = true;           
            repoBook.Update(model);
            return RedirectToAction("Index");
        }

    }
}

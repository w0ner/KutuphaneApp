using BL.Repositories;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KutuphaneApp.Areas.admin.Controllers
{
    [Authorize, Area("admin"), Route("/admin/[controller]/[action]")]
    public class MembersController : Controller
    {

        IRepository<Members> repoMembers;
        public MembersController( IRepository<Members> _repoMembers)
        {
           
            repoMembers = _repoMembers;
        }

        public IActionResult Index()
        {
            return View(repoMembers.GetAll().OrderBy(x => x.Name));
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(Members model)
        {
                     
            repoMembers.Add(model);
            return RedirectToAction("Index");
        }
   
    }
}

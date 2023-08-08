using BL.Repositories;
using DAL.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using KutuphaneApp.Tools;

namespace KutuphaneApp.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class HomeController : Controller
    {
        IRepository<Admin> repoAdmin;
        public HomeController(IRepository<Admin> _repoAdmin)
        {
            repoAdmin = _repoAdmin;
        }

        [Route("/admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/admin/giris"), AllowAnonymous]
        public IActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [Route("/admin/giris"), AllowAnonymous, HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string Username, string Password, string ReturnUrl)
        {

            Admin admin = repoAdmin.GetBy(x => x.Username == Username && x.Password == GeneralTool.getMD5(Password)) ?? null;
            if (admin != null)//böyle bir admin varsa
            {
                List<Claim> claims = new List<Claim> {
                    new Claim(ClaimTypes.PrimarySid, admin.ID.ToString()),
                    new Claim(ClaimTypes.Name,admin.Name+" "+admin.Surname) 
                   
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "KutuphaneApp");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties { IsPersistent = true });
                if (string.IsNullOrEmpty(ReturnUrl)) return Redirect("/admin");
                else return Redirect(ReturnUrl);
            }
            else TempData["Bilgi"] = "Kullanıcı adı veya şifre hatalı";
            return View();
        }

        [Route("/admin/cikis")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}

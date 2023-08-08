using BL.Repositories;
using DAL.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped(typeof(IRepository<>), typeof(SQLRepository<>));
builder.Services.AddDbContext<SqlContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CS1")));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    opt.LoginPath = "/admin/giris";
    opt.LogoutPath = "/admin/cikis";
    opt.ExpireTimeSpan = TimeSpan.FromMinutes(60); //60dk hareketsiz kal�nca panelden c�k��� sa�lamas�
});    
var app = builder.Build();
if (!app.Environment.IsDevelopment()) app.UseStatusCodePagesWithRedirects("/hata/{0}");
app.UseStaticFiles(); //statik dosyalar�n cal�smas�
app.UseRouting();
app.UseAuthentication(); //kimlik do�rulama
app.UseAuthorization(); //kimlik yetkilendirme 
app.MapControllerRoute(name: "default", pattern: "{controller=home}/{action=index}/{id?}");
app.MapControllerRoute(name: "area", pattern: "{area:exists}/{controller=home}/{action=index}/{id?}");

app.Run();
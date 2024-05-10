using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using MVC_Personel.Models;
using Personel_Mvc.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MVC_Personel.Controllers
{
    public class AccountController : Controller
    {
        Context x = new Context();
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Login (Admin p)
        {          
            if (!ModelState.IsValid) 
            { 
               return View(p);
			}

			var bilgiler = x.Admins.FirstOrDefault(c => c.Kullanici == p.Kullanici && c.Sifre == p.Sifre);
			if (bilgiler != null)
			{
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.Kullanici)
                };
				var useridentity = new ClaimsIdentity(claims, "Login");
				ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
				await HttpContext.SignInAsync(principal);
                var userName = bilgiler.Kullanici;
                TempData["UserName"] = userName;
                return RedirectToAction("Index", "Birim");
			}
			else
			{

                ViewBag.Hata = "Kullanıcı adı veya şifre yanlış";

                return View();
			}
		}

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> NewLogin(Admin YeniKullanici)
        {
            if (!ModelState.IsValid)
            {
                return View(YeniKullanici);
            }

            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");
            if (!regex.IsMatch(YeniKullanici.Sifre))
            {
                ModelState.AddModelError("Sifre", "Şifreniz en az 8 karakterden oluşmalı ve en az bir büyük harf, bir küçük harf, bir sayı ve bir özel karakter içermelidir.");
                return View(YeniKullanici);
            }

            var bilgiler = x.Admins.FirstOrDefault(c => c.Kullanici == YeniKullanici.Kullanici && c.Sifre == YeniKullanici.Sifre);
            if (bilgiler != null)
            {
				ViewBag.KullaniciHata = "Girdiğiniz Bilgilere Dair Kayıt Bulunmaktadır Lütfen Bilgilerinizi Kontrol Ediniz!";
				return View();
			}		

			x.Admins.Add(YeniKullanici);
			x.SaveChanges();

			return RedirectToAction("Index", "Birim");
		}

    }
}

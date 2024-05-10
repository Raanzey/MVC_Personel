using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Personel.Models;
using Personel_Mvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Personel.Controllers
{
    public class PersonelController : Controller
    {
        Context x = new Context();
		[Authorize]
		public IActionResult Index()
        {
            var degerler= x.PersonelBilgis.Include(x=>x.Birim).ToList();
            var userName = HttpContext.User.Identity.Name;
            TempData["UserName"] = userName;
            return View(degerler);
        }
        [HttpGet]
        public IActionResult PersonelEkle()
        {          
            List<SelectListItem> degerler=(from c in x.Birims.ToList()
                                          select new SelectListItem
                                          {
                                              Text = c.Ad,
                                              Value = c.BirimID.ToString()
                                          }).ToList();  
            ViewBag.Degerler = degerler;
            var userName = HttpContext.User.Identity.Name;
            TempData["UserName"] = userName;
            return View();
        }
        [HttpPost]
        public IActionResult PersonelEkle(PersonelBilgi EklePersonel)
        {
            if (!ModelState.IsValid)
            {
                var userName = HttpContext.User.Identity.Name;
                TempData["UserName"] = userName;
                return View(EklePersonel);
            }
            x.PersonelBilgis.Add(EklePersonel);
            x.SaveChanges();    

            return RedirectToAction("Index");
        }
        public IActionResult PersonelSil(int id)
        {
            var PersonelSil = x.PersonelBilgis.Find(id);
            x.PersonelBilgis.Remove(PersonelSil);
            x.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]

        public IActionResult PersonelGetir(int id)
		{            
            List<SelectListItem> degerler = (from c in x.Birims.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = c.Ad,
                                                 Value = c.BirimID.ToString()
                                             }).ToList();
            ViewBag.Degerler = degerler;
			var PersonelGetir = x.PersonelBilgis.Find(id);
            var userName = HttpContext.User.Identity.Name;
            TempData["UserName"] = userName;
            return View("PersonelGetir", PersonelGetir);


        }

        public IActionResult PersonelGuncelle(PersonelBilgi YeniPersonel)
		{
            if (!ModelState.IsValid)
            {
                var userName = HttpContext.User.Identity.Name;
                TempData["UserName"] = userName;
                return View(YeniPersonel);
            }
            var PersonelGuncelle = x.PersonelBilgis.Find(YeniPersonel.PersonelID);
            PersonelGuncelle.Ad = YeniPersonel.Ad;
            PersonelGuncelle.Soyad = YeniPersonel.Soyad;
            PersonelGuncelle.Sehir = YeniPersonel.Sehir;
            PersonelGuncelle.BirimID = YeniPersonel.BirimID;
            x.SaveChanges();

            return RedirectToAction("Index");
        }
	}
}

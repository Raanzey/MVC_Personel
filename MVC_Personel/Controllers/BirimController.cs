using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Personel.Models;
using Personel_Mvc.Models;
using System.Linq;

namespace MVC_Personel.Controllers
{
    public class BirimController : Controller
    {
        Context x = new Context();
        [Authorize]
        public IActionResult Index()
        {
            var degerler = x.Birims.ToList();
           
            var userName = HttpContext.User.Identity.Name;
            TempData["UserName"] = userName;
            return View(degerler);
        }
        [HttpGet]
        public IActionResult YeniBirim()
        {
            var userName = HttpContext.User.Identity.Name;
            TempData["UserName"] = userName;
            return View();
        }
        [HttpPost]
        public IActionResult YeniBirim(Birim EkleBirim)
        {
            if (!ModelState.IsValid)
            {
                var userName = HttpContext.User.Identity.Name;
                TempData["UserName"] = userName;
                return View(EkleBirim);
            }
            x.Birims.Add(EkleBirim);
            x.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult BirimSil(int id)
        {
            var BirimSil = x.Birims.Find(id);
            x.Birims.Remove(BirimSil);
            x.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimGetir(int id)
        {
            var BirimGetir = x.Birims.Find(id);
            var userName = HttpContext.User.Identity.Name;
            TempData["UserName"] = userName;
            return View("BirimGetir", BirimGetir);
        }
        public IActionResult BirimGuncelle(Birim YeniBirim)
        {
            if (!ModelState.IsValid)
            {
                var userName = HttpContext.User.Identity.Name;
                TempData["UserName"] = userName;
                return View(YeniBirim);
            }
            var BirimGuncelle = x.Birims.Find(YeniBirim.BirimID);
            BirimGuncelle.Ad = YeniBirim.Ad;
            x.SaveChanges();
            return RedirectToAction("Index");          
        }
        public IActionResult BirimDetaylar( int id ) 
        {
            var degerler = x.PersonelBilgis.Where(x => x.BirimID == id).ToList();
            ViewBag.birimAd = x.Birims.Find(id).Ad;
            var userName = HttpContext.User.Identity.Name;
            TempData["UserName"] = userName;
            return View(degerler);
            
        } 
    }
}
